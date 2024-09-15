using X4.SaveFile.Objects.Implementations;
using X4.SaveFile.Objects.Interfaces.SelectorVectors;
using Argon = X4.SaveFile.Objects.Interfaces.SelectorVectors.IArgonRace;
using ExtraLarge = X4.SaveFile.Objects.Interfaces.SelectorVectors.IExtraLargeSize;
using Khaak = X4.SaveFile.Objects.Interfaces.SelectorVectors.IKhaakRace;
using Large = X4.SaveFile.Objects.Interfaces.SelectorVectors.ILargeSize;
using Medium = X4.SaveFile.Objects.Interfaces.SelectorVectors.IMediumSize;
using Paranid = X4.SaveFile.Objects.Interfaces.SelectorVectors.IParanidRace;
using Shield = X4.SaveFile.Objects.Interfaces.SelectorVectors.IShieldEquipmentType;
using Small = X4.SaveFile.Objects.Interfaces.SelectorVectors.ISmallSize;
using Split = X4.SaveFile.Objects.Interfaces.SelectorVectors.ISplitRace;
using Teladi = X4.SaveFile.Objects.Interfaces.SelectorVectors.ITeladiRace;
using Terran = X4.SaveFile.Objects.Interfaces.SelectorVectors.ITerranRace;
using Xenon = X4.SaveFile.Objects.Interfaces.SelectorVectors.IXenonRace;

namespace X4.SaveFile.Extensions
{
    public static class ShieldEquipmentTypeExtensions
    {
        #region Basic Navigators & Anchor Points

        public static Selector<Shield, ExtraLarge> ExtraLarge(this Selector<Shield> selector)
        {
            return new Selector<Shield, ExtraLarge>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Shield, Large> Large(this Selector<Shield> selector)
        {
            return new Selector<Shield, Large>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Shield, Medium> Medium(this Selector<Shield> selector)
        {
            return new Selector<Shield, Medium>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Shield, Small> Small(this Selector<Shield> selector)
        {
            return new Selector<Shield, Small>()
            {
                Ship = selector.Ship
            };
        }

        #endregion

        #region Argon

        public static RaceSelector<Shield, TSize, Argon> Argon<TSize>(this Selector<Shield, TSize> selector)
            where TSize : ISize
        {
            return new RaceSelector<Shield, TSize, Argon>()
            {
                Ship = selector.Ship
            };
        }

        public static string Mk1(this RaceSelector<Shield, ExtraLarge, Argon> selector) => "shield_arg_xl_standard_01_mk1";

        public static string Mk1(this RaceSelector<Shield, Large, Argon> selector) => "shield_arg_l_standard_01_mk1";
        public static string Mk2(this RaceSelector<Shield, Large, Argon> selector) => "shield_arg_l_standard_01_mk2";

        public static string Mk1(this RaceSelector<Shield, Medium, Argon> selector) => "shield_arg_m_standard_02_mk1";
        public static string Mk2(this RaceSelector<Shield, Medium, Argon> selector) => "shield_arg_m_standard_02_mk2";

        public static string Mk1(this RaceSelector<Shield, Small, Argon> selector) => "shield_arg_s_standard_01_mk1";
        public static string Mk2(this RaceSelector<Shield, Small, Argon> selector) => "shield_arg_s_standard_01_mk2";
        public static string Mk3(this RaceSelector<Shield, Small, Argon> selector) => "shield_arg_s_standard_01_mk3";

        #endregion

        #region Khaak

        public static RaceSelector<Shield, Small, Khaak> Khaak(this Selector<Shield, Small> selector)
        {
            return new RaceSelector<Shield, Small, Khaak>()
            {
                Ship = selector.Ship
            };
        }

        public static string Mk1(this RaceSelector<Shield, Small, Khaak> selector) => "shield_kha_s_standard_01_mk1";

        #endregion

        #region Paranid

        public static RaceSelector<Shield, TSize, Paranid> Paranid<TSize>(this Selector<Shield, TSize> selector)
            where TSize : ISize
        {
            return new RaceSelector<Shield, TSize, Paranid>()
            {
                Ship = selector.Ship
            };
        }

        public static string Mk1(this RaceSelector<Shield, ExtraLarge, Paranid> selector) => "shield_par_xl_standard_01_mk1";

        public static string Mk1(this RaceSelector<Shield, Large, Paranid> selector) => "shield_par_l_standard_01_mk1";
        public static string Mk2(this RaceSelector<Shield, Large, Paranid> selector) => "shield_par_l_standard_01_mk2";

        public static string Mk1(this RaceSelector<Shield, Medium, Paranid> selector) => "shield_par_m_standard_02_mk1";
        public static string Mk2(this RaceSelector<Shield, Medium, Paranid> selector) => "shield_par_m_standard_02_mk2";

        public static string Mk1(this RaceSelector<Shield, Small, Paranid> selector) => "shield_par_s_standard_01_mk1";
        public static string Mk2(this RaceSelector<Shield, Small, Paranid> selector) => "shield_par_s_standard_01_mk2";
        public static string Mk3(this RaceSelector<Shield, Small, Paranid> selector) => "shield_par_s_standard_01_mk3";

        #endregion

        #region Split

        public static RaceSelector<Shield, TSize, Split> Split<TSize>(this Selector<Shield, TSize> selector)
            where TSize : ISize
        {
            return new RaceSelector<Shield, TSize, Split>()
            {
                Ship = selector.Ship
            };
        }

        public static string Mk1(this RaceSelector<Shield, ExtraLarge, Split> selector) => "shield_spl_xl_standard_01_mk1";

        public static string Mk1(this RaceSelector<Shield, Large, Split> selector) => "shield_spl_l_standard_01_mk1";
        public static string Mk2(this RaceSelector<Shield, Large, Split> selector) => "shield_spl_l_standard_01_mk2";

        public static string Mk1(this RaceSelector<Shield, Medium, Split> selector) => "shield_spl_m_standard_02_mk1";
        public static string Mk2(this RaceSelector<Shield, Medium, Split> selector) => "shield_spl_m_standard_02_mk2";

        public static string Mk1(this RaceSelector<Shield, Small, Split> selector) => "shield_spl_s_standard_01_mk1";
        public static string Mk2(this RaceSelector<Shield, Small, Split> selector) => "shield_spl_s_standard_01_mk2";
        public static string Mk3(this RaceSelector<Shield, Small, Split> selector) => "shield_spl_s_standard_01_mk3";

        #endregion

        #region Teladi

        public static RaceSelector<Shield, TSize, Teladi> Teladi<TSize>(this Selector<Shield, TSize> selector)
            where TSize : ISize
        {
            return new RaceSelector<Shield, TSize, Teladi>()
            {
                Ship = selector.Ship
            };
        }

        public static string Mk1(this RaceSelector<Shield, ExtraLarge, Teladi> selector) => "shield_tel_xl_standard_01_mk1";

        public static string Mk1(this RaceSelector<Shield, Large, Teladi> selector) => "shield_tel_l_standard_01_mk1";
        public static string Mk2(this RaceSelector<Shield, Large, Teladi> selector) => "shield_tel_l_standard_01_mk2";

        public static string Mk1(this RaceSelector<Shield, Medium, Teladi> selector) => "shield_tel_m_standard_02_mk1";
        public static string Mk2(this RaceSelector<Shield, Medium, Teladi> selector) => "shield_tel_m_standard_02_mk2";

        public static string Mk1(this RaceSelector<Shield, Small, Teladi> selector) => "shield_tel_s_standard_01_mk1";
        public static string Mk2(this RaceSelector<Shield, Small, Teladi> selector) => "shield_tel_s_standard_01_mk2";
        public static string Mk3(this RaceSelector<Shield, Small, Teladi> selector) => "shield_tel_s_standard_01_mk3";

        #endregion

        #region Terran

        public static RaceSelector<Shield, TSize, Terran> Terran<TSize>(this Selector<Shield, TSize> selector)
            where TSize : ISize
        {
            return new RaceSelector<Shield, TSize, Terran>()
            {
                Ship = selector.Ship
            };
        }

        public static string Mk1(this RaceSelector<Shield, ExtraLarge, Terran> selector) => "shield_ter_xl_standard_01_mk1";

        public static string Mk1(this RaceSelector<Shield, Large, Terran> selector) => "shield_ter_l_standard_01_mk1";
        public static string Mk2(this RaceSelector<Shield, Large, Terran> selector) => "shield_ter_l_standard_01_mk2";

        public static string Mk1(this RaceSelector<Shield, Medium, Terran> selector) => "shield_ter_m_standard_02_mk1";
        public static string Mk2(this RaceSelector<Shield, Medium, Terran> selector) => "shield_ter_m_standard_02_mk2";
        public static string Mk3(this RaceSelector<Shield, Medium, Terran> selector) => "shield_ter_m_standard_01_mk3";

        public static string Mk1(this RaceSelector<Shield, Small, Terran> selector) => "shield_ter_s_standard_01_mk1";
        public static string Mk2(this RaceSelector<Shield, Small, Terran> selector) => "shield_ter_s_standard_01_mk2";
        public static string Mk3(this RaceSelector<Shield, Small, Terran> selector) => "shield_ter_s_standard_01_mk3";

        #endregion

        #region Xenon

        public static RaceSelector<Shield, TSize, Xenon> Xenon<TSize>(this Selector<Shield, TSize> selector)
            where TSize : ISize
        {
            return new RaceSelector<Shield, TSize, Xenon>()
            {
                Ship = selector.Ship
            };
        }

        public static string Mk1(this RaceSelector<Shield, ExtraLarge, Xenon> selector) => "shield_xen_xl_standard_01_mk1";

        public static string Mk1(this RaceSelector<Shield, Large, Xenon> selector) => "shield_xen_l_standard_01_mk1";
        public static string Mk2(this RaceSelector<Shield, Large, Xenon> selector) => "shield_xen_l_standard_01_mk2";

        public static string Mk1(this RaceSelector<Shield, Medium, Xenon> selector) => "shield_xen_m_standard_02_mk1";
        public static string Mk2(this RaceSelector<Shield, Medium, Xenon> selector) => "shield_xen_m_standard_02_mk2";
        
        public static string Mk1(this RaceSelector<Shield, Small, Xenon> selector) => "shield_xen_s_standard_01_mk1";
        public static string Mk2(this RaceSelector<Shield, Small, Xenon> selector) => "shield_xen_s_standard_01_mk2";

        #endregion
    }
}