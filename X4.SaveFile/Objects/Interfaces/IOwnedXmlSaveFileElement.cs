using X4.SaveFile.Extensions;

namespace X4.SaveFile.Objects.Interfaces
{
    public interface IOwnedXmlSaveFileElement : IXmlSaveFileElement
    {
        public string? Owner
        {
            get => this.Node.SelectSingleNode("@owner")?.Value;
            set
            {
                this.Node
                    .ResolveOrCreate(this.Node.OwnerDocument!, "@owner")
                    .Value = value;
            }
        }
    }
}