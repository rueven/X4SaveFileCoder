using X4.SaveFile.Constants;
using X4.SaveFile.Extensions;

namespace X4.SaveFile.Objects.Interfaces
{
    public interface IShip : INamedXmlSaveFileElement, IOwnedXmlSaveFileElement, ICodedXmlSaveFileElement, IMacroedXmlSaveFileElement
    {
        public string Class
        {
            get => this.Node.SelectSingleNode("@class")!.Value!;
            set
            {
                this.Node
                    .ResolveOrCreate(this.Node.OwnerDocument!, "@class")
                    .Value = value;
            }
        }

        public ShipSize? Size
        {
            get
            {
                switch (this.Class)
                {
                    case "ship_s": return ShipSize.Small;
                    case "ship_m": return ShipSize.Medium;
                    case "ship_l": return ShipSize.Large;
                    case "ship_xl": return ShipSize.ExtraLarge;
                    default: return null;
                }
            }
        }
    }

    public interface IAnonymousShip : IShip
    { }

    public interface IExtraLargeShip : IShip
    { }

    public interface ILargeShip : IShip
    { }

    public interface IMediumShip : IShip
    { }

    public interface ISmallShip : IShip
    { }
}