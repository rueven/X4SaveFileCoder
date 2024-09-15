using System.Xml;
using X4.SaveFile.Objects.Implementations;
using X4.SaveFile.Objects.Interfaces;

namespace X4.SaveFile.Extensions
{
    public static partial class ShipExtensions
    {
        public static IExtraLargeShip AsExtraLargeShip(this IAnonymousShip ship) => (IExtraLargeShip)ship;
        public static ILargeShip AsLargeShip(this IAnonymousShip ship) => (ILargeShip)ship;
        public static IMediumShip AsMediumShip(this IAnonymousShip ship) => (IMediumShip)ship;
        public static ISmallShip AsSmallShip(this IAnonymousShip ship) => (ISmallShip)ship;

        public static TShip Pilot<TShip>(this TShip ship, Action<IPilot> method)
            where TShip : IShip
        {
            var node = ship
                .Node
                .SelectSingleNode(@"connections/connection[@connection='con_cockpit'][@macro='con_cockpit']/component[@class='cockpit']/connections/connection[component[@class='npc']]/component[@class='npc'][entity[@type='officer'][@post='aipilot']]");
            if (node != null)
            {
                var element = new XmlSaveFileElement()
                {
                    Node = node
                };
                method(element);
            }
            return ship;
        }

        public static TShip Paint<TShip>(this TShip ship, string paintModification)
            where TShip : IShip
        {
            var paintNode = ship
                .Node
                .ResolveOrCreate(ship.Node.OwnerDocument!, $"modification/paint");
            paintNode.ResolveOrCreate(ship.Node.OwnerDocument!, "@ware").Value = paintModification;
            paintNode.Attributes!.RemoveNamedItem("generated");
            return ship;
        }

        public static TShip ModifyChassisWithStreamlinedHull<TShip>(this TShip ship, double mass = .8D, double drag = .7D)
            where TShip : IShip
        {
            var modification = ship
                .Node
                .ResolveOrCreate(ship.Node.OwnerDocument!, $"modification/ship");
            modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@ware").Value = "mod_ship_mass_01_mk3";
            modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@mass").Value = mass.ToString();
            modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@drag").Value = drag.ToString();
            return ship;
        }

        public static TShip RemoveChassisModifications<TShip>(this TShip ship)
            where TShip : IShip
        {
            var nodes = ship
                .Node
                .SelectNodes("modification/ship");
            if (nodes != null && nodes.Count > 0)
            {
                foreach (XmlNode node in nodes)
                {
                    node.ParentNode!
                        .RemoveChild(node);
                }
            }
            return ship;
        }

        public static TShip ModifyChassisForScanProtection<TShip>(this TShip ship)
            where TShip : IShip
        {
            var modification = ship
                .Node
                .ResolveOrCreate(ship.Node.OwnerDocument!, $"modification/ship");
            modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@ware").Value = "mod_ship_hidecargo_01";
            modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@hidecargochance").Value = "1";
            return ship;
        }
    }
}