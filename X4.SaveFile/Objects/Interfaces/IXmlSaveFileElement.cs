using System.Xml;

namespace X4.SaveFile.Objects.Interfaces
{
    public interface IXmlSaveFileElement
    {
        XmlNode Node { get; }
    }
}