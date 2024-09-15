using X4.SaveFile.Extensions;

namespace X4.SaveFile.Objects.Interfaces
{
    public interface ISeededXmlSaveFileElement : IXmlSaveFileElement
    {
        public long Seed
        {
            get
            {
                var rawValue = this
                    .Node
                    .SelectSingleNode("npcseed/@seed")
                    !.Value!;
                if (long.TryParse(rawValue, out var output))
                {
                    return output;
                }
                return 0;
            }
            set
            {
                this.Node
                    .ResolveOrCreate(this.Node.OwnerDocument!, "npcseed/@seed")
                    .Value = value.ToString();
            }
        }
    }
}