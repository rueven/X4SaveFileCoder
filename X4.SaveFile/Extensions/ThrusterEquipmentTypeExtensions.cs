using X4.SaveFile.Objects.Implementations;
using X4.SaveFile.Objects.Interfaces.SelectorVectors;
using AllRound = X4.SaveFile.Objects.Interfaces.SelectorVectors.IAllRoundEquipmentTrim;
using Combat = X4.SaveFile.Objects.Interfaces.SelectorVectors.ICombatEquipmentTrim;
using ExtraLarge = X4.SaveFile.Objects.Interfaces.SelectorVectors.IExtraLargeSize;
using Large = X4.SaveFile.Objects.Interfaces.SelectorVectors.ILargeSize;
using Medium = X4.SaveFile.Objects.Interfaces.SelectorVectors.IMediumSize;
using Small = X4.SaveFile.Objects.Interfaces.SelectorVectors.ISmallSize;
using Thruster = X4.SaveFile.Objects.Interfaces.SelectorVectors.IThrusterEquipmentType;

namespace X4.SaveFile.Extensions
{
    public static class ThrusterEquipmentTypeExtensions
    {
        public static Selector<Thruster, ExtraLarge> ExtraLarge(this Selector<Thruster> selector)
        {
            return new Selector<Thruster, ExtraLarge>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Thruster, Large> Large(this Selector<Thruster> selector)
        {
            return new Selector<Thruster, Large>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Thruster, Medium> Medium(this Selector<Thruster> selector)
        {
            return new Selector<Thruster, Medium>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Thruster, Small> Small(this Selector<Thruster> selector)
        {
            return new Selector<Thruster, Small>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Thruster, TSize, AllRound> AllRound<TSize>(this Selector<Thruster, TSize> selector)
            where TSize: ISize
        {
            return new Selector<Thruster, TSize, AllRound>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Thruster, Medium, Combat> Combat(this Selector<Thruster, Medium> selector)
        {
            return new Selector<Thruster, Medium, Combat>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Thruster, Small, Combat> Combat(this Selector<Thruster, Small> selector)
        {
            return new Selector<Thruster, Small, Combat>()
            {
                Ship = selector.Ship
            };
        }

        public static string Mk1(this Selector<Thruster, ExtraLarge, AllRound> selector) => "thruster_gen_xl_allround_01_mk1";
        public static string Mk2(this Selector<Thruster, ExtraLarge, AllRound> selector) => "thruster_gen_xl_allround_01_mk2";
        public static string Mk3(this Selector<Thruster, ExtraLarge, AllRound> selector) => "thruster_gen_xl_allround_01_mk3";

        public static string Mk1(this Selector<Thruster, Large, AllRound> selector) => "thruster_gen_l_allround_01_mk1";
        public static string Mk2(this Selector<Thruster, Large, AllRound> selector) => "thruster_gen_l_allround_01_mk2";
        public static string Mk3(this Selector<Thruster, Large, AllRound> selector) => "thruster_gen_l_allround_01_mk3";

        public static string Mk1(this Selector<Thruster, Medium, AllRound> selector) => "thruster_gen_m_allround_01_mk1";
        public static string Mk2(this Selector<Thruster, Medium, AllRound> selector) => "thruster_gen_m_allround_01_mk2";
        public static string Mk3(this Selector<Thruster, Medium, AllRound> selector) => "thruster_gen_m_allround_01_mk3";

        public static string Mk1(this Selector<Thruster, Medium, Combat> selector) => "thruster_gen_m_combat_01_mk1";
        public static string Mk2(this Selector<Thruster, Medium, Combat> selector) => "thruster_gen_m_combat_01_mk2";
        public static string Mk3(this Selector<Thruster, Medium, Combat> selector) => "thruster_gen_m_combat_01_mk3";

        public static string Mk1(this Selector<Thruster, Small, AllRound> selector) => "thruster_gen_s_allround_01_mk1";
        public static string Mk2(this Selector<Thruster, Small, AllRound> selector) => "thruster_gen_s_allround_01_mk2";
        public static string Mk3(this Selector<Thruster, Small, AllRound> selector) => "thruster_gen_s_allround_01_mk3";

        public static string Mk1(this Selector<Thruster, Small, Combat> selector) => "thruster_gen_s_combat_01_mk1";
        public static string Mk2(this Selector<Thruster, Small, Combat> selector) => "thruster_gen_s_combat_01_mk2";
        public static string Mk3(this Selector<Thruster, Small, Combat> selector) => "thruster_gen_s_combat_01_mk3";
    }
}