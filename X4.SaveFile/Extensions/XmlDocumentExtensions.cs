using System.Text;
using System.Xml;
using X4.SaveFile.Objects.Implementations;

namespace X4.SaveFile.Extensions
{
    internal static class XmlDocumentExtensions
    {
        public static XmlNode ResolveOrCreate(this XmlDocument document, string xpath, XmlNamespaceManager? manager = null)
        {
            ArgumentNullException.ThrowIfNull(document, nameof(document));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(xpath, nameof(xpath));
            return document.ResolveOrCreate(document, xpath, manager);
        }

        public static XmlNode ResolveOrCreate(this XmlNode root, XmlDocument document, string xpath, XmlNamespaceManager? manager = null)
        {
            ArgumentNullException.ThrowIfNull(document, nameof(document));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(xpath, nameof(xpath));
            var output = manager == null ? root.SelectSingleNode(xpath) : root.SelectSingleNode(xpath, manager);
            if (output != null) { return output; }
            var element = document.ExtractNext(root, ref xpath, manager);
            while (element != null)
            {
                output = element;
                element = document.ExtractNext(element, ref xpath, manager);
            }
            return output!;
        }

        private static XmlNode? ExtractNext(this XmlDocument document, XmlNode root, ref string xpath, XmlNamespaceManager? manager)
        {
            ArgumentNullException.ThrowIfNull(document, nameof(document));
            ArgumentNullException.ThrowIfNull(root, nameof(root));
            if (string.IsNullOrEmpty(xpath))
            {
                return null;
            }
            var nextsection = XmlDocumentExtensions.GetNextSection(xpath);
            xpath = xpath.Substring(nextsection.Length);
            if (nextsection.StartsWith("/"))
            {
                nextsection = nextsection.Substring(1);
            }
            var nextnode = root.SelectSingleNode(nextsection, manager);
            if (nextnode != null)
            {
                return nextnode;
            }
            nextnode = document.FabricateNode(root, nextsection, manager);
            return nextnode;
        }

        private static XmlNode FabricateNode(this XmlDocument document, XmlNode current, string singlepath, XmlNamespaceManager? manager)
        {
            ArgumentNullException.ThrowIfNull(document, nameof(document));
            ArgumentNullException.ThrowIfNull(current, nameof(current));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(singlepath, nameof(singlepath));
            var parsed = NodeParser.Parse(singlepath);
            var node = document.FabricateNode(current, singlepath, parsed, manager);
            if (node == null)
            {
                throw new Exception("Node was null and that is bad");
            }
            if (!string.IsNullOrEmpty(parsed.Value))
            {
                node.InnerText = parsed.Value;
            }
            if (parsed.Predicates != null)
            {
                document.ResolvePredicate(node, parsed, manager);
            }
            return node;
        }

        private static XmlNode? FabricateNode(this XmlDocument document, XmlNode current, string singlepath, NodeParser parsed, XmlNamespaceManager? manager)
        {
            var namespaceuri = string.IsNullOrEmpty(parsed.Prefix) || manager == null ? null : manager.LookupNamespace(parsed.Prefix);
            if (singlepath.StartsWith("./"))
            {
                singlepath = singlepath.Substring(2, singlepath.Length - 2);
            }
            if (singlepath.StartsWith("@"))
            {
                if (current.Attributes != null)
                {
                    var attribute = document.CreateAttribute(parsed.Prefix, parsed.Name, namespaceuri);
                    attribute.Prefix = parsed.Prefix!;
                    return current
                        .Attributes
                        .Append(attribute);
                }
                return null;
            }
            var element = document.CreateElement(parsed.Prefix, parsed.Name, namespaceuri);
            element.Prefix = parsed.Prefix!;
            return current.AppendChild(element);
        }

        private static void ResolvePredicate(this XmlDocument document, XmlNode root, NodeParser parsed, XmlNamespaceManager? manager)
        {
            ArgumentNullException.ThrowIfNull(document, nameof(document));
            ArgumentNullException.ThrowIfNull(root, nameof(root));
            ArgumentNullException.ThrowIfNull(parsed, nameof(parsed));
            foreach (var predicate in parsed.Predicates)
            {
                if (int.TryParse(predicate, out var _)) { continue; }
                var subpredicate = NodeParser.Parse(predicate.Trim());
                document.FabricateNode(root, subpredicate.RawName, manager);
            }
        }

        private static string GetNextSection(string xpath)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(xpath, nameof(xpath));
            var next = new StringBuilder();
            var toggledepth = 0;
            var skipfirst = xpath.StartsWith("/");
            foreach (var character in xpath)
            {
                if (character == '[') toggledepth += 1;
                if (character == ']') toggledepth -= 1;
                if (skipfirst && character == '/') { skipfirst = false; }
                else
                {
                    if (character == '/' && toggledepth == 0)
                    {
                        return next.ToString();
                    }
                }
                next.Append(character);
            }
            return next.ToString();
        }

        public static XmlNode? SelectFirstSingleNonNullNode(this XmlNode node, params string[] paths)
        {
            foreach (var path in paths)
            {
                var matchingNode = node
                    .SelectSingleNode(path);
                if (matchingNode != null)
                {
                    return matchingNode;
                }
            }
            return null;
        }
    }
}
