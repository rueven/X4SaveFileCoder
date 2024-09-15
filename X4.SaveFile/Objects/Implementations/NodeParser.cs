using System.Text;

namespace X4.SaveFile.Objects.Implementations
{
    internal class NodeParser
    {
        public static NodeParser Parse(string value)
        {
            if (value == null) throw new ArgumentNullException("value");
            return new NodeParser()
            {
                RawName = NodeParser.ValueOrNull(value),
                Predicates = NodeParser.ExtractPredicates(ref value),
                Prefix = NodeParser.ExtractPrefix(ref value),
                Value = NodeParser.ExtractValue(ref value),
                IsAttribute = value.StartsWith("@"),
                Name = (NodeParser.ValueOrNull(value) ?? string.Empty).TrimStart('@', '/', '.'),
            };
        }

        public string Name { get; private set; }
        public string? Prefix { get; private set; }
        public string? RawName { get; private set; }
        public string? Value { get; private set; }
        public bool IsAttribute { get; private set; }
        public IEnumerable<string> Predicates { get; private set; }

        #region Static Methods

        public static IEnumerable<string> ExtractPredicates(ref string value)
        {
            var output = new List<string>();
            var predicate = NodeParser.ExtractFirstPredicate(ref value);
            while (string.IsNullOrEmpty(predicate).Equals(false))
            {
                var parts = NodeParser.SeperateAndedPredicates(predicate);
                output.AddRange(parts);
                predicate = NodeParser.ExtractFirstPredicate(ref value);
            }
            return output;
        }

        private static string ExtractFirstPredicate(ref string value)
        {
            var revisedvalue = new StringBuilder();
            var output = new StringBuilder();
            var toggledepth = 0;
            var recording = false;
            var completed = false;
            foreach (var character in value)
            {
                var istransition = false;
                if (character == '[')
                {
                    toggledepth += 1;
                    if (completed.Equals(false) && toggledepth == 1)
                    {
                        recording = true;
                        istransition = true;
                    }
                }
                if (character == ']')
                {
                    toggledepth -= 1;
                    if (completed.Equals(false) && toggledepth == 0)
                    {
                        istransition = true;
                        recording = false;
                        completed = true;
                    }
                }
                if (istransition.Equals(false))
                {
                    if (recording) { output.Append(character); }
                    else
                    {
                        revisedvalue.Append(character);
                    }
                }
            }
            value = revisedvalue.ToString();
            return output.ToString();
        }

        private static IEnumerable<string> SeperateAndedPredicates(string value)
        {
            var output = new List<string>();
            var depth = 0;
            var possible = new StringBuilder();
            var current = new StringBuilder();
            foreach (var character in value)
            {
                if (character == '[') { depth += 1; }
                if (character == ']') { depth -= 1; }
                if (depth == 0)
                {
                    if (character == ' ' && possible.Length == 0)
                    {
                        possible.Append(character);
                        continue;
                    }
                    if (character == 'a' && possible.Length == 1 && possible[0] == ' ')
                    {
                        possible.Append(character);
                        continue;
                    }
                    if (character == 'n' && possible.Length == 2 && possible[0] == ' ' && possible[1] == 'a')
                    {
                        possible.Append(character);
                        continue;
                    }
                    if (character == 'd' && possible.Length == 3 && possible[0] == ' ' && possible[1] == 'a' && possible[2] == 'n')
                    {
                        possible.Append(character);
                        continue;
                    }
                    if (character == ' ' && possible.Length == 4 && possible[0] == ' ' && possible[1] == 'a' && possible[2] == 'n' && possible[3] == 'd')
                    {
                        output.Add(current.ToString());
                        current.Clear();
                        possible.Clear();
                        continue;
                    }
                }
                current.Append(character);
            }
            if (current.Length > 0)
            {
                output.Add(current.ToString());
            }
            return output.ToArray();
        }

        public static string? ExtractPrefix(ref string value)
        {
            var index = value.IndexOf(':');
            if (index > -1)
            {
                var prefix = value.Substring(0, index + 1);
                value = value.Substring(index + 1);
                return prefix.Substring(0, index);
            }
            return null;
        }

        public static string? ExtractValue(ref string value)
        {
            var index = value.LastIndexOf('=');
            if (index == -1) return null;
            var subpredicateindex = value.IndexOf(']');
            if (subpredicateindex > index) return null;
            var output = value.Substring(index);
            value = value.Substring(0, index);
            output = output.Substring(1);
            return NodeParser.ValueOrNull(output.TrimStart('\'').TrimEnd('\''));
        }

        public static string? ValueOrNull(string value)
        {
            return string.IsNullOrEmpty(value) ? null : value.Trim();
        }

        #endregion
    }
}
