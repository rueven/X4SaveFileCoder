using System.Xml;
using X4.SaveFile.Objects.Interfaces;

namespace X4.SaveFile.Objects.Implementations
{
    internal class XmlSaveFileElement :
        IFaction,
        IAnonymousShip, IExtraLargeShip, ILargeShip, IMediumShip, ISmallShip,
        IStation,
        IPilot, IManager, IShipTrader, IInventoryTrader, IPlayer
    {
        public required XmlNode Node { get; init; }
    }
}