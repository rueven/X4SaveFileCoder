namespace X4.SaveFile.Objects.Interfaces
{
    public interface IFaction : IXmlSaveFileElement
    {
        public string Id => this
            .Node
            .SelectSingleNode("@id")!
            .Value!;

        public long Money
        {
            get
            {
                var node = this
                    .Node
                    .SelectSingleNode("account/@amount")!;
                if (long.TryParse(node.Value, out var output))
                {
                    return output;
                }
                return 0;
            }
            set
            {
                var node = this
                    .Node
                    .SelectSingleNode("account/@amount");
                if (node != null)
                {
                    node.Value = value.ToString();
                }
            }
        }
    }
}