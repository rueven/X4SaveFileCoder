using X4.SaveFile.Objects.Implementations;
using X4.SaveFile.Objects.Interfaces;
using X4.SaveFile.Objects.Interfaces.SelectorVectors;

namespace X4.SaveFile.Extensions
{
    public partial class ShipExtensions
    {
        public static IAnonymousShip Thrusters(this IAnonymousShip ship, Func<Selector<IThrusterEquipmentType>, string> selector)
        {
            var start = new Selector<IThrusterEquipmentType>()
            {
                Ship = ship
            };
            var type = selector(start);
            return ship
                .Thrusters(type + "_macro");
        }

        public static IExtraLargeShip Thrusters(this IExtraLargeShip ship, Func<Selector<IThrusterEquipmentType, IExtraLargeSize>, string> selector)
            => ship.Thrusters(x => x.ExtraLarge(), selector);

        public static ILargeShip Thrusters(this ILargeShip ship, Func<Selector<IThrusterEquipmentType, ILargeSize>, string> selector)
            => ship.Thrusters(x => x.Large(), selector);

        public static IMediumShip Thrusters(this IMediumShip ship, Func<Selector<IThrusterEquipmentType, IMediumSize>, string> selector)
            => ship.Thrusters(x => x.Medium(), selector);

        public static ISmallShip Thrusters(this ISmallShip ship, Func<Selector<IThrusterEquipmentType, ISmallSize>, string> selector)
            => ship.Thrusters(x => x.Small(), selector);

        private static TShip Thrusters<TShip, TSize>(this TShip ship, Func<Selector<IThrusterEquipmentType>, Selector<IThrusterEquipmentType, TSize>> startModifier, Func<Selector<IThrusterEquipmentType, TSize>, string> selector)
            where TShip : IShip
            where TSize : ISize
        {
            var start = startModifier(new Selector<IThrusterEquipmentType>()
            {
                Ship = ship
            });
            var type = selector(start);
            return ship
                .Thrusters(type + "_macro");
        }

        public static TShip Thrusters<TShip>(this TShip ship, string macro)
            where TShip : IShip
        {
            var node = ship
                .Node
                .SelectSingleNode("@thruster");
            if (node != null)
            {
                node.Value = macro;
            }
            return ship;
        }
    }
}