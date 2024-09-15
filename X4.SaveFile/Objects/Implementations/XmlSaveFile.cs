using System.Xml;

namespace X4.SaveFile.Objects.Implementations
{
    public sealed class XmlSaveFile
    {
        internal XmlSaveFile(bool isCompressed, string filePath, XmlDocument document)
        {
            this.Document = document;
            this.IsCompressed = isCompressed;
            this.Filepath = filePath;
        }

        public bool IsCompressed { get; private set; }
        public string Filepath { get; private set; }
        internal XmlDocument Document { get; private set; }
    }
}