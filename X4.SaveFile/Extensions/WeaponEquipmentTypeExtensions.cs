using X4.SaveFile.Objects.Implementations;
using ExtraLarge = X4.SaveFile.Objects.Interfaces.SelectorVectors.IExtraLargeSize;
using Large = X4.SaveFile.Objects.Interfaces.SelectorVectors.ILargeSize;
using Medium = X4.SaveFile.Objects.Interfaces.SelectorVectors.IMediumSize;
using Small = X4.SaveFile.Objects.Interfaces.SelectorVectors.ISmallSize;
using Weapon = X4.SaveFile.Objects.Interfaces.SelectorVectors.IWeaponEquipmentType;


namespace X4.SaveFile.Extensions
{
    public static partial class WeaponEquipmentTypeExtensions
    {
        public static Selector<Weapon, ExtraLarge> ExtraLarge(this Selector<Weapon> selector)
        {
            return new Selector<Weapon, ExtraLarge>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Weapon, Large> Large(this Selector<Weapon> selector)
        {
            return new Selector<Weapon, Large>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Weapon, Medium> Medium(this Selector<Weapon> selector)
        {
            return new Selector<Weapon, Medium>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Weapon, Small> Small(this Selector<Weapon> selector)
        {
            return new Selector<Weapon, Small>()
            {
                Ship = selector.Ship
            };
        }
    }
}