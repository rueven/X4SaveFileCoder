using X4.SaveFile.Extensions;

namespace X4.SaveFile.Objects.Interfaces
{
    public interface IMacroedXmlSaveFileElement : IXmlSaveFileElement
    {
        public string? Macro
        {
            get => this.Node.SelectSingleNode("@macro")?.Value;
            set
            {
                this.Node
                    .ResolveOrCreate(this.Node.OwnerDocument!, "@macro")
                    .Value = value;
            }
        }
    }
}