using System.Xml;
using X4.SaveFile.Objects.Implementations;
using X4.SaveFile.Objects.Interfaces;
using X4.SaveFile.Objects.Interfaces.SelectorVectors;

namespace X4.SaveFile.Extensions
{
    public partial class ShipExtensions
    {
        private static TShip ForEachShield<TShip>(this TShip ship, Action<XmlNode> method)
            where TShip : IShip
        {
            var nodes = ship
                .Node
                .SelectNodes("connections/connection[starts-with(@connection, 'con_') and contains(@connection, 'shield')]/component[@class='shieldgenerator']/..");
            if (nodes != null && nodes.Count == 0)
            {
                foreach (XmlNode node in nodes)
                {
                    method?.Invoke(node);
                }
            }
            return ship;
        }

        #region Shields Overloads

        public static IAnonymousShip Shields(this IAnonymousShip ship, Func<Selector<IShieldEquipmentType>, string> selector)
        {
            var start = new Selector<IShieldEquipmentType>()
            {
                Ship = ship
            };
            var type = selector(start);
            return ship
                .Shields(type + "_macro");
        }

        public static IExtraLargeShip Shields(this IExtraLargeShip ship, Func<Selector<IShieldEquipmentType, IExtraLargeSize>, string> selector)
            => ship.Shields(x => x.ExtraLarge(), selector);

        public static ILargeShip Shields(this ILargeShip ship, Func<Selector<IShieldEquipmentType, ILargeSize>, string> selector)
            => ship.Shields(x => x.Large(), selector);

        public static IMediumShip Shields(this IMediumShip ship, Func<Selector<IShieldEquipmentType, IMediumSize>, string> selector)
            => ship.Shields(x => x.Medium(), selector);

        public static ISmallShip Shields(this ISmallShip ship, Func<Selector<IShieldEquipmentType, ISmallSize>, string> selector)
            => ship.Shields(x => x.Small(), selector);

        private static TShip Shields<TShip, TSize>(this TShip ship, Func<Selector<IShieldEquipmentType>, Selector<IShieldEquipmentType, TSize>> startModifier, Func<Selector<IShieldEquipmentType, TSize>, string> selector)
            where TShip : IShip
            where TSize : ISize
        {
            var start = startModifier(new Selector<IShieldEquipmentType>()
            {
                Ship = ship
            });
            var type = selector(start);
            return ship
                .Shields(type + "_macro");
        }

        public static TShip Shields<TShip>(this TShip ship, string macro)
            where TShip : IShip
        {
            return ship
                .ForEachShield(node =>
                {
                    var component = node
                        .SelectSingleNode("component");
                    if (component != null)
                    {
                        component.ResolveOrCreate(ship.Node.OwnerDocument!, "@macro").Value = macro;
                    }
                });
        }

        #endregion

        #region ShieldReplacements Overloads

        public static IAnonymousShip ShieldReplacements(this IAnonymousShip ship, Func<Selector<IShieldEquipmentType>, string> findSelector, Func<Selector<IShieldEquipmentType>, string> replaceSelector)
        {
            var start = new Selector<IShieldEquipmentType>()
            {
                Ship = ship
            };
            var findType = findSelector(start);
            var replaceType = replaceSelector(start);
            return ship
                .ShieldReplacements(findType + "_macro", replaceType + "_macro");
        }

        public static IExtraLargeShip ShieldReplacements(this IExtraLargeShip ship, Func<Selector<IShieldEquipmentType, IExtraLargeSize>, string> findSelector, Func<Selector<IShieldEquipmentType, IExtraLargeSize>, string> replaceSelector)
            => ship.ShieldReplacements(x => x.ExtraLarge(), findSelector, replaceSelector);

        public static ILargeShip ShieldReplacements(this ILargeShip ship, Func<Selector<IShieldEquipmentType, ILargeSize>, string> findSelector, Func<Selector<IShieldEquipmentType, ILargeSize>, string> replaceSelector)
            => ship.ShieldReplacements(x => x.Large(), findSelector, replaceSelector);

        public static IMediumShip ShieldReplacements(this IMediumShip ship, Func<Selector<IShieldEquipmentType, IMediumSize>, string> findSelector, Func<Selector<IShieldEquipmentType, IMediumSize>, string> replaceSelector)
            => ship.ShieldReplacements(x => x.Medium(), findSelector, replaceSelector);

        public static ISmallShip ShieldReplacements(this ISmallShip ship, Func<Selector<IShieldEquipmentType, ISmallSize>, string> findSelector, Func<Selector<IShieldEquipmentType, ISmallSize>, string> replaceSelector)
            => ship.ShieldReplacements(x => x.Small(), findSelector, replaceSelector);

        private static TShip ShieldReplacements<TShip, TSize>(this TShip ship, Func<Selector<IShieldEquipmentType>, Selector<IShieldEquipmentType, TSize>> startModifier, Func<Selector<IShieldEquipmentType, TSize>, string> findSelector, Func<Selector<IShieldEquipmentType, TSize>, string> replaceSelector)
            where TShip : IShip
            where TSize : ISize
        {
            var start = startModifier(new Selector<IShieldEquipmentType>()
            {
                Ship = ship
            });
            var findType = findSelector(start);
            var replaceType = replaceSelector(start);
            return ship
                .ShieldReplacements(findType + "_macro", replaceType + "_macro");
        }

        public static TShip ShieldReplacements<TShip>(this TShip ship, string findMacro, string replaceMacro)
            where TShip : IShip
        {
            return ship
                .ForEachShield(node =>
                {
                    var component = node
                        .SelectSingleNode("component");
                    if (component != null)
                    {
                        var macroNode = component
                            .SelectSingleNode("@macro")!;
                        if (macroNode.Value == findMacro)
                        {
                            macroNode.Value = replaceMacro;
                        }
                    }
                });
        }

        #endregion

        public static TShip ModifyShields<TShip>(this TShip ship, double capacity = 1.3D, double rechargeDelay = .7D, double rechargeRate = 1.7D)
            where TShip : IShip
        {
            var shieldsNode = ship
                .Node
                .ResolveOrCreate(ship.Node.OwnerDocument!, "shields");
            var groupNode = shieldsNode
                .SelectSingleNode("group[not(@*)]");
            if (groupNode == null)
            {
                groupNode = ship
                    .Node
                    .OwnerDocument
                    !.CreateElement(null, "group", null);
                shieldsNode
                    .AppendChild(groupNode);
            }
            var newNode = groupNode
                .ResolveOrCreate(ship.Node.OwnerDocument!, "modification");
            newNode.ResolveOrCreate(ship.Node.OwnerDocument!, "@ware").Value = "mod_shield_capacity_02_mk3";
            newNode.ResolveOrCreate(ship.Node.OwnerDocument!, "@capacity").Value = capacity.ToString();
            newNode.ResolveOrCreate(ship.Node.OwnerDocument!, "@rechargedelay").Value = rechargeDelay.ToString();
            newNode.ResolveOrCreate(ship.Node.OwnerDocument!, "@rechargerate").Value = rechargeRate.ToString();
            newNode = newNode
                .ParentNode
                !.ParentNode;
            newNode
                .SelectSingleNode("group")
                !.Attributes
                !.RemoveNamedItem("context");
            ship.Node
                .RemoveChild(newNode);
            var placementNode = ship
                .Node
                .SelectSingleNode("ammunition");
            if (placementNode != null)
            {
                placementNode
                    !.ParentNode
                    !.InsertBefore(newNode, placementNode);
            }
            return ship;
        }

        public static TShip RemoveAnyShieldsModifications<TShip>(this TShip ship)
            where TShip : IShip
        {
            var shieldsNode = ship
                .Node
                .ResolveOrCreate(ship.Node.OwnerDocument!, "shields");
            var groupNode = shieldsNode
                .SelectSingleNode("group[not(@*)]");
            if (groupNode == null)
            {
                groupNode = ship
                    .Node
                    .OwnerDocument
                    !.CreateElement(null, "group", null);
                shieldsNode
                    .AppendChild(groupNode);
            }
            var shieldModification = groupNode
                .SelectSingleNode("modification");
            shieldModification
                !.ParentNode
                !.RemoveChild(shieldModification);
            return ship;
        }
    }
}