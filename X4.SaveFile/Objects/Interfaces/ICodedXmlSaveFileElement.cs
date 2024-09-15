using X4.SaveFile.Extensions;
using CodeDataType = X4.SaveFile.Objects.Implementations.Code;

namespace X4.SaveFile.Objects.Interfaces
{
    public interface ICodedXmlSaveFileElement : IXmlSaveFileElement
    {
        public CodeDataType Code
        {
            get
            {
                if (CodeDataType.TryParse(this.Node.SelectSingleNode("@code")?.Value, out var output))
                {
                    return output;
                }
                return CodeDataType.Empty;
            }
            set
            {
                this.Node
                    .ResolveOrCreate(this.Node.OwnerDocument!, "@code")
                    .Value = value.Value;
            }
        }
    }
}