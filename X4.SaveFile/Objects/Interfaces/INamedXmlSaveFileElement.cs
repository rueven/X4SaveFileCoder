using X4.SaveFile.Extensions;

namespace X4.SaveFile.Objects.Interfaces
{
    public interface INamedXmlSaveFileElement : IXmlSaveFileElement
    {
        public string? Name
        {
            get => this.Node.SelectSingleNode("@name")?.Value;
            set
            {
                this.Node
                    .ResolveOrCreate(this.Node.OwnerDocument!, "@name")
                    .Value = value;
            }
        }
    }
}