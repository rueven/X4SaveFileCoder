using System.Xml;
using X4.SaveFile.Objects.Implementations;
using X4.SaveFile.Objects.Interfaces;
using X4.SaveFile.Objects.Interfaces.SelectorVectors;

namespace X4.SaveFile.Extensions
{
    public static partial class ShipExtensions
    {
        private static TShip ForEachEngine<TShip>(this TShip ship, Action<XmlNode> method)
            where TShip : IShip
        {
            var nodes = ship
                .Node
                .SelectNodes("connections/connection[starts-with(@connection, 'con_') and contains(@connection, 'engine')]/component[@class='engine']/..");
            if (nodes != null && nodes.Count == 0)
            {
                foreach (XmlNode node in nodes)
                {
                    method?.Invoke(node);
                }
            }
            return ship;
        }

        public static IAnonymousShip Engines(this IAnonymousShip ship, Func<Selector<IEngineEquipmentType>, string> selector)
        {
            var start = new Selector<IEngineEquipmentType>()
            {
                Ship = ship
            };
            var type = selector(start);
            return ship
                .Engines(type + "_macro");
        }

        public static IExtraLargeShip Engines(this IExtraLargeShip ship, Func<Selector<IEngineEquipmentType, IExtraLargeSize>, string> selector)
            => ship.Engines(x => x.ExtraLarge(), selector);

        public static ILargeShip Engines(this ILargeShip ship, Func<Selector<IEngineEquipmentType, ILargeSize>, string> selector)
            => ship.Engines(x => x.Large(), selector);

        public static IMediumShip Engines(this IMediumShip ship, Func<Selector<IEngineEquipmentType, IMediumSize>, string> selector)
            => ship.Engines(x => x.Medium(), selector);

        public static ISmallShip Engines(this ISmallShip ship, Func<Selector<IEngineEquipmentType, ISmallSize>, string> selector)
            => ship.Engines(x => x.Small(), selector);

        private static TShip Engines<TShip, TSize>(this TShip ship, Func<Selector<IEngineEquipmentType>, Selector<IEngineEquipmentType, TSize>> startModifier, Func<Selector<IEngineEquipmentType, TSize>, string> selector)
            where TShip : IShip
            where TSize : ISize
        {
            var start = startModifier(new Selector<IEngineEquipmentType>()
            {
                Ship = ship
            });
            var type = selector(start);
            return ship
                .Engines(type + "_macro");
        }

        public static TShip Engines<TShip>(this TShip ship, string type)
            where TShip : IShip
        {
            return ship
                .ForEachEngine(node =>
                {
                    var component = node
                        .SelectSingleNode("component");
                    if (component != null)
                    {
                        component.ResolveOrCreate(ship.Node.OwnerDocument!, "@macro").Value = type;
                    }
                });
        }

        public static TShip ModifyEnginesSpeed<TShip>(this TShip ship, double forwardThrust = 1.3, double strafeThrust = 1.45, double rotationThrust = 1.2, double travelThrust = 1.3, double travelStartThrust = 1.2, double travelAttackTime = .7, double travelReleaseTime = 1, double travelChargeTime = .8)
            where TShip : IShip
        {
            var engine = ship
                .Node
                .ResolveOrCreate(ship.Node.OwnerDocument!, "modification/engine");
            engine.ResolveOrCreate(ship.Node.OwnerDocument!, "@ware").Value = "mod_engine_travelthrust_01_mk3";
            engine.ResolveOrCreate(ship.Node.OwnerDocument!, "@forwardthrust").Value = forwardThrust.ToString();
            engine.ResolveOrCreate(ship.Node.OwnerDocument!, "@strafethrust").Value = strafeThrust.ToString();
            engine.ResolveOrCreate(ship.Node.OwnerDocument!, "@rotationthrust").Value = rotationThrust.ToString();
            engine.ResolveOrCreate(ship.Node.OwnerDocument!, "@travelthrust").Value = travelThrust.ToString();
            engine.ResolveOrCreate(ship.Node.OwnerDocument!, "@travelstartthrust").Value = travelStartThrust.ToString();
            engine.ResolveOrCreate(ship.Node.OwnerDocument!, "@travelattacktime").Value = travelAttackTime.ToString();
            engine.ResolveOrCreate(ship.Node.OwnerDocument!, "@travelreleasetime").Value = travelReleaseTime.ToString();
            engine.ResolveOrCreate(ship.Node.OwnerDocument!, "@travelchargetime").Value = travelChargeTime.ToString();
            return ship;
        }

        public static TShip ModifyEnginesRotation<TShip>(this TShip ship, double forwardThrust, double strafeThrust, double rotationThrust)
            where TShip : IShip
        {
            var engine = ship
                .Node
                .ResolveOrCreate(ship.Node.OwnerDocument!, "modification/engine");
            engine.ResolveOrCreate(ship.Node.OwnerDocument!, "@ware").Value = "mod_engine_rotationthrust_01_mk3";
            engine.ResolveOrCreate(ship.Node.OwnerDocument!, "@forwardthrust").Value = forwardThrust.ToString();
            engine.ResolveOrCreate(ship.Node.OwnerDocument!, "@strafethrust").Value = strafeThrust.ToString();
            engine.ResolveOrCreate(ship.Node.OwnerDocument!, "@rotationthrust").Value = rotationThrust.ToString();
            return ship;
        }
    }
}
