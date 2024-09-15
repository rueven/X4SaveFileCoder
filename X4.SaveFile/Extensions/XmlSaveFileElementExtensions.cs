using X4.SaveFile.Constants;
using X4.SaveFile.Objects.Implementations;
using X4.SaveFile.Objects.Interfaces;

namespace X4.SaveFile.Extensions
{
    public static class XmlSaveFileElementExtensions
    {
        public static T Owner<T>(this T component, string owner)
            where T : IOwnedXmlSaveFileElement
        {
            ArgumentNullException.ThrowIfNull(component, nameof(component));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(owner, nameof(owner));
            component.Owner = owner;
            return component;
        }

        public static bool IsOwnedBy<T>(this T component, Faction faction)
            where T : IOwnedXmlSaveFileElement
        {
            ArgumentNullException.ThrowIfNull(component, nameof(component));
            return string.Equals(component.Owner, Enum.GetName(faction)!, StringComparison.OrdinalIgnoreCase);
        }

        public static T Macro<T>(this T component, string macro)
            where T : IMacroedXmlSaveFileElement
        {
            ArgumentNullException.ThrowIfNull(component, nameof(component));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(macro, nameof(macro));
            component.Macro = macro;
            return component;
        }

        public static T Name<T>(this T component, string name)
            where T : INamedXmlSaveFileElement
        {
            ArgumentNullException.ThrowIfNull(component, nameof(component));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            component.Name = name;
            return component;
        }

        public static T Code<T>(this T component, Code code)
            where T : ICodedXmlSaveFileElement
        {
            ArgumentNullException.ThrowIfNull(component, nameof(component));
            ArgumentNullException.ThrowIfNullOrWhiteSpace(code.Value, nameof(code));
            component.Code = code;
            return component;
        }
    }
}