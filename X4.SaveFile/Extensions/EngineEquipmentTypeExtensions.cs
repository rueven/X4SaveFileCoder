using X4.SaveFile.Objects.Implementations;
using X4.SaveFile.Objects.Interfaces.SelectorVectors;
using AllRound = X4.SaveFile.Objects.Interfaces.SelectorVectors.IAllRoundEquipmentTrim;
using Argon = X4.SaveFile.Objects.Interfaces.SelectorVectors.IArgonRace;
using Combat = X4.SaveFile.Objects.Interfaces.SelectorVectors.ICombatEquipmentTrim;
using Engine = X4.SaveFile.Objects.Interfaces.SelectorVectors.IEngineEquipmentType;
using ExtraLarge = X4.SaveFile.Objects.Interfaces.SelectorVectors.IExtraLargeSize;
using Khaak = X4.SaveFile.Objects.Interfaces.SelectorVectors.IKhaakRace;
using Large = X4.SaveFile.Objects.Interfaces.SelectorVectors.ILargeSize;
using Medium = X4.SaveFile.Objects.Interfaces.SelectorVectors.IMediumSize;
using Paranid = X4.SaveFile.Objects.Interfaces.SelectorVectors.IParanidRace;
using Small = X4.SaveFile.Objects.Interfaces.SelectorVectors.ISmallSize;
using Split = X4.SaveFile.Objects.Interfaces.SelectorVectors.ISplitRace;
using Teladi = X4.SaveFile.Objects.Interfaces.SelectorVectors.ITeladiRace;
using Terran = X4.SaveFile.Objects.Interfaces.SelectorVectors.ITerranRace;
using Travel = X4.SaveFile.Objects.Interfaces.SelectorVectors.ITravelEquipmentTrim;

namespace X4.SaveFile.Extensions
{
    public static class EngineEquipmentTypeExtensions
    {
        #region Basic Navigators & Anchor Points

        public static Selector<Engine, ExtraLarge> ExtraLarge(this Selector<Engine> selector)
        {
            return new Selector<Engine, ExtraLarge>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Engine, Large> Large(this Selector<Engine> selector)
        {
            return new Selector<Engine, Large>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Engine, Medium> Medium(this Selector<Engine> selector)
        {
            return new Selector<Engine, Medium>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Engine, Small> Small(this Selector<Engine> selector)
        {
            return new Selector<Engine, Small>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Engine, TSize, AllRound> AllRound<TSize>(this Selector<Engine, TSize> selector)
            where TSize : ISize
        {
            return new Selector<Engine, TSize, AllRound>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Engine, TSize, Combat> Combat<TSize>(this Selector<Engine, TSize> selector)
            where TSize : ISize
        {
            return new Selector<Engine, TSize, Combat>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Engine, TSize, Travel> Travel<TSize>(this Selector<Engine, TSize> selector)
            where TSize : ISize
        {
            return new Selector<Engine, TSize, Travel>()
            {
                Ship = selector.Ship
            };
        }


        #endregion

        #region Argon

        public static Selector<Engine, TSize, TEquipmentTrim, Argon> Argon<TSize, TEquipmentTrim>(this Selector<Engine, TSize, TEquipmentTrim> selector)
            where TSize : ISize
            where TEquipmentTrim: IEquipmentTrim
        {
            return new Selector<Engine, TSize, TEquipmentTrim, Argon>()
            {
                Ship = selector.Ship
            };
        }

        public static string Mk1(this Selector<Engine, ExtraLarge, AllRound, Argon> selector) => "engine_arg_xl_allround_01_mk1";
        public static string Mk1(this Selector<Engine, ExtraLarge, Travel, Argon> selector) => "engine_arg_xl_travel_01_mk1";

        public static string Mk1(this Selector<Engine, Large, AllRound, Argon> selector) => "engine_arg_l_allround_01_mk1";
        public static string Mk1(this Selector<Engine, Large, Travel, Argon> selector) => "engine_arg_l_travel_01_mk1";

        public static string Mk1(this Selector<Engine, Medium, AllRound, Argon> selector) => "engine_arg_m_allround_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, AllRound, Argon> selector) => "engine_arg_m_allround_01_mk2";
        public static string Mk3(this Selector<Engine, Medium, AllRound, Argon> selector) => "engine_arg_m_allround_01_mk3";
        public static string Mk1(this Selector<Engine, Medium, Combat, Argon> selector) => "engine_arg_m_combat_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, Combat, Argon> selector) => "engine_arg_m_combat_01_mk2";
        public static string Mk3(this Selector<Engine, Medium, Combat, Argon> selector) => "engine_arg_m_combat_01_mk3";
        public static string Mk1(this Selector<Engine, Medium, Travel, Argon> selector) => "engine_arg_m_travel_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, Travel, Argon> selector) => "engine_arg_m_travel_01_mk2";
        public static string Mk3(this Selector<Engine, Medium, Travel, Argon> selector) => "engine_arg_m_travel_01_mk3";

        public static string Mk1(this Selector<Engine, Small, AllRound, Argon> selector) => "engine_arg_s_allround_01_mk1";
        public static string Mk2(this Selector<Engine, Small, AllRound, Argon> selector) => "engine_arg_s_allround_01_mk2";
        public static string Mk3(this Selector<Engine, Small, AllRound, Argon> selector) => "engine_arg_s_allround_01_mk3";
        public static string Mk1(this Selector<Engine, Small, Combat, Argon> selector) => "engine_arg_s_combat_01_mk1";
        public static string Mk2(this Selector<Engine, Small, Combat, Argon> selector) => "engine_arg_s_combat_01_mk2";
        public static string Mk3(this Selector<Engine, Small, Combat, Argon> selector) => "engine_arg_s_combat_01_mk3";
        public static string Mk1(this Selector<Engine, Small, Travel, Argon> selector) => "engine_arg_s_travel_01_mk1";
        public static string Mk2(this Selector<Engine, Small, Travel, Argon> selector) => "engine_arg_s_travel_01_mk2";
        public static string Mk3(this Selector<Engine, Small, Travel, Argon> selector) => "engine_arg_s_travel_01_mk3";

        #endregion

        #region Khaak

        public static Selector<Engine, Medium, TEquipmentTrim, Khaak> Khaak<TEquipmentTrim>(this Selector<Engine, Medium, TEquipmentTrim> selector)
            where TEquipmentTrim : IEquipmentTrim
        {
            return new Selector<Engine, Medium, TEquipmentTrim, Khaak>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Engine, Small, TEquipmentTrim, Khaak> Khaak<TEquipmentTrim>(this Selector<Engine, Small, TEquipmentTrim> selector)
            where TEquipmentTrim : IEquipmentTrim
        {
            return new Selector<Engine, Small, TEquipmentTrim, Khaak>()
            {
                Ship = selector.Ship
            };
        }

        public static string Mk1(this Selector<Engine, Medium, Combat, Khaak> selector) => "engine_kha_m_combat_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, Combat, Khaak> selector) => "engine_kha_m_combat_02_mk1";

        public static string Mk1(this Selector<Engine, Small, Combat, Khaak> selector) => "engine_kha_s_combat_01_mk1";

        #endregion

        #region Paranid

        public static Selector<Engine, TSize, TEquipmentTrim, Paranid> Paranid<TSize, TEquipmentTrim>(this Selector<Engine, TSize, TEquipmentTrim> selector)
            where TSize : ISize
            where TEquipmentTrim : IEquipmentTrim
        {
            return new Selector<Engine, TSize, TEquipmentTrim, Paranid>()
            {
                Ship = selector.Ship
            };
        }

        public static string Mk1(this Selector<Engine, ExtraLarge, AllRound, Paranid> selector) => "engine_par_xl_allround_01_mk1";
        public static string Mk1(this Selector<Engine, ExtraLarge, Travel, Paranid> selector) => "engine_par_xl_travel_01_mk1";

        public static string Mk1(this Selector<Engine, Large, AllRound, Paranid> selector) => "engine_par_l_allround_01_mk1";
        public static string Mk1(this Selector<Engine, Large, Travel, Paranid> selector) => "engine_par_l_travel_01_mk1";

        public static string Mk1(this Selector<Engine, Medium, AllRound, Paranid> selector) => "engine_par_m_allround_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, AllRound, Paranid> selector) => "engine_par_m_allround_01_mk2";
        public static string Mk3(this Selector<Engine, Medium, AllRound, Paranid> selector) => "engine_par_m_allround_01_mk3";
        public static string Mk1(this Selector<Engine, Medium, Combat, Paranid> selector) => "engine_par_m_combat_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, Combat, Paranid> selector) => "engine_par_m_combat_01_mk2";
        public static string Mk3(this Selector<Engine, Medium, Combat, Paranid> selector) => "engine_par_m_combat_01_mk3";
        public static string Mk1(this Selector<Engine, Medium, Travel, Paranid> selector) => "engine_par_m_travel_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, Travel, Paranid> selector) => "engine_par_m_travel_01_mk2";
        public static string Mk3(this Selector<Engine, Medium, Travel, Paranid> selector) => "engine_par_m_travel_01_mk3";

        public static string Mk1(this Selector<Engine, Small, AllRound, Paranid> selector) => "engine_par_s_allround_01_mk1";
        public static string Mk2(this Selector<Engine, Small, AllRound, Paranid> selector) => "engine_par_s_allround_01_mk2";
        public static string Mk3(this Selector<Engine, Small, AllRound, Paranid> selector) => "engine_par_s_allround_01_mk3";
        public static string Mk1(this Selector<Engine, Small, Combat, Paranid> selector) => "engine_par_s_combat_01_mk1";
        public static string Mk2(this Selector<Engine, Small, Combat, Paranid> selector) => "engine_par_s_combat_01_mk2";
        public static string Mk3(this Selector<Engine, Small, Combat, Paranid> selector) => "engine_par_s_combat_01_mk3";
        public static string Mk1(this Selector<Engine, Small, Travel, Paranid> selector) => "engine_par_s_travel_01_mk1";
        public static string Mk2(this Selector<Engine, Small, Travel, Paranid> selector) => "engine_par_s_travel_01_mk2";
        public static string Mk3(this Selector<Engine, Small, Travel, Paranid> selector) => "engine_par_s_travel_01_mk3";

        #endregion

        #region Split

        public static Selector<Engine, TSize, TEquipmentTrim, Split> Split<TSize, TEquipmentTrim>(this Selector<Engine, TSize, TEquipmentTrim> selector)
            where TSize : ISize
            where TEquipmentTrim : IEquipmentTrim
        {
            return new Selector<Engine, TSize, TEquipmentTrim, Split>()
            {
                Ship = selector.Ship
            };
        }

        public static string Mk1(this Selector<Engine, ExtraLarge, AllRound, Split> selector) => "engine_spl_xl_allround_01_mk1";
        public static string Mk1(this Selector<Engine, ExtraLarge, Travel, Split> selector) => "engine_spl_xl_travel_01_mk1";

        public static string Mk1(this Selector<Engine, Large, AllRound, Split> selector) => "engine_spl_l_allround_01_mk1";
        public static string Mk1(this Selector<Engine, Large, Travel, Split> selector) => "engine_spl_l_travel_01_mk1";

        public static string Mk1(this Selector<Engine, Medium, AllRound, Split> selector) => "engine_spl_m_allround_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, AllRound, Split> selector) => "engine_spl_m_allround_01_mk2";
        public static string Mk3(this Selector<Engine, Medium, AllRound, Split> selector) => "engine_spl_m_allround_01_mk3";
        public static string Mk1(this Selector<Engine, Medium, Combat, Split> selector) => "engine_spl_m_combat_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, Combat, Split> selector) => "engine_spl_m_combat_01_mk2";
        public static string Mk3(this Selector<Engine, Medium, Combat, Split> selector) => "engine_spl_m_combat_01_mk3";
        public static string Mk4(this Selector<Engine, Medium, Combat, Split> selector) => "engine_spl_m_combat_01_mk4";
        public static string Mk1(this Selector<Engine, Medium, Travel, Split> selector) => "engine_spl_m_travel_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, Travel, Split> selector) => "engine_spl_m_travel_01_mk2";
        public static string Mk3(this Selector<Engine, Medium, Travel, Split> selector) => "engine_spl_m_travel_01_mk3";

        public static string Mk1(this Selector<Engine, Small, AllRound, Split> selector) => "engine_spl_s_allround_01_mk1";
        public static string Mk2(this Selector<Engine, Small, AllRound, Split> selector) => "engine_spl_s_allround_01_mk2";
        public static string Mk3(this Selector<Engine, Small, AllRound, Split> selector) => "engine_spl_s_allround_01_mk3";
        public static string Mk1(this Selector<Engine, Small, Combat, Split> selector) => "engine_spl_s_combat_01_mk1";
        public static string Mk2(this Selector<Engine, Small, Combat, Split> selector) => "engine_spl_s_combat_01_mk2";
        public static string Mk3(this Selector<Engine, Small, Combat, Split> selector) => "engine_spl_s_combat_01_mk3";
        public static string Mk4(this Selector<Engine, Small, Combat, Split> selector) => "engine_spl_s_combat_01_mk4";
        public static string Mk1(this Selector<Engine, Small, Travel, Split> selector) => "engine_spl_s_travel_01_mk1";
        public static string Mk2(this Selector<Engine, Small, Travel, Split> selector) => "engine_spl_s_travel_01_mk2";
        public static string Mk3(this Selector<Engine, Small, Travel, Split> selector) => "engine_spl_s_travel_01_mk3";

        #endregion

        #region Teladi

        public static Selector<Engine, TSize, TEquipmentTrim, Teladi> Teladi<TSize, TEquipmentTrim>(this Selector<Engine, TSize, TEquipmentTrim> selector)
            where TSize : ISize
            where TEquipmentTrim : IEquipmentTrim
        {
            return new Selector<Engine, TSize, TEquipmentTrim, Teladi>()
            {
                Ship = selector.Ship
            };
        }

        public static string Mk1(this Selector<Engine, ExtraLarge, AllRound, Teladi> selector) => "engine_tel_xl_allround_01_mk1";
        public static string Mk1(this Selector<Engine, ExtraLarge, Travel, Teladi> selector) => "engine_tel_xl_travel_01_mk1";

        public static string Mk1(this Selector<Engine, Large, AllRound, Teladi> selector) => "engine_tel_l_allround_01_mk1";
        public static string Mk1(this Selector<Engine, Large, Travel, Teladi> selector) => "engine_tel_l_travel_01_mk1";

        public static string Mk1(this Selector<Engine, Medium, AllRound, Teladi> selector) => "engine_tel_m_allround_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, AllRound, Teladi> selector) => "engine_tel_m_allround_01_mk2";
        public static string Mk3(this Selector<Engine, Medium, AllRound, Teladi> selector) => "engine_tel_m_allround_01_mk3";
        public static string Mk1(this Selector<Engine, Medium, Combat, Teladi> selector) => "engine_tel_m_combat_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, Combat, Teladi> selector) => "engine_tel_m_combat_01_mk2";
        public static string Mk3(this Selector<Engine, Medium, Combat, Teladi> selector) => "engine_tel_m_combat_01_mk3";
        public static string Mk1(this Selector<Engine, Medium, Travel, Teladi> selector) => "engine_tel_m_travel_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, Travel, Teladi> selector) => "engine_tel_m_travel_01_mk2";
        public static string Mk3(this Selector<Engine, Medium, Travel, Teladi> selector) => "engine_tel_m_travel_01_mk3";

        public static string Mk1(this Selector<Engine, Small, AllRound, Teladi> selector) => "engine_tel_s_allround_01_mk1";
        public static string Mk2(this Selector<Engine, Small, AllRound, Teladi> selector) => "engine_tel_s_allround_01_mk2";
        public static string Mk3(this Selector<Engine, Small, AllRound, Teladi> selector) => "engine_tel_s_allround_01_mk3";
        public static string Mk1(this Selector<Engine, Small, Combat, Teladi> selector) => "engine_tel_s_combat_01_mk1";
        public static string Mk2(this Selector<Engine, Small, Combat, Teladi> selector) => "engine_tel_s_combat_01_mk2";
        public static string Mk3(this Selector<Engine, Small, Combat, Teladi> selector) => "engine_tel_s_combat_01_mk3";
        public static string Mk1(this Selector<Engine, Small, Travel, Teladi> selector) => "engine_tel_s_travel_01_mk1";
        public static string Mk2(this Selector<Engine, Small, Travel, Teladi> selector) => "engine_tel_s_travel_01_mk2";
        public static string Mk3(this Selector<Engine, Small, Travel, Teladi> selector) => "engine_tel_s_travel_01_mk3";

        #endregion

        #region Terran

        public static Selector<Engine, TSize, TEquipmentTrim, Terran> Terran<TSize, TEquipmentTrim>(this Selector<Engine, TSize, TEquipmentTrim> selector)
            where TSize : ISize
            where TEquipmentTrim : IEquipmentTrim
        {
            return new Selector<Engine, TSize, TEquipmentTrim, Terran>()
            {
                Ship = selector.Ship
            };
        }

        public static string Mk1(this Selector<Engine, ExtraLarge, AllRound, Terran> selector) => "engine_ter_xl_allround_01_mk1";
        public static string Mk1(this Selector<Engine, ExtraLarge, Travel, Terran> selector) => "engine_ter_xl_travel_01_mk1";

        public static string Mk1(this Selector<Engine, Large, AllRound, Terran> selector) => "engine_ter_l_allround_01_mk1";
        public static string Mk1(this Selector<Engine, Large, Travel, Terran> selector) => "engine_ter_l_travel_01_mk1";

        public static string Mk1(this Selector<Engine, Medium, AllRound, Terran> selector) => "engine_ter_m_allround_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, AllRound, Terran> selector) => "engine_ter_m_allround_01_mk2";
        public static string Mk3(this Selector<Engine, Medium, AllRound, Terran> selector) => "engine_ter_m_allround_01_mk3";
        public static string Mk1(this Selector<Engine, Medium, Combat, Terran> selector) => "engine_ter_m_combat_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, Combat, Terran> selector) => "engine_ter_m_combat_01_mk2";
        public static string Mk3(this Selector<Engine, Medium, Combat, Terran> selector) => "engine_ter_m_combat_01_mk3";
        public static string Mk1(this Selector<Engine, Medium, Travel, Terran> selector) => "engine_ter_m_travel_01_mk1";
        public static string Mk2(this Selector<Engine, Medium, Travel, Terran> selector) => "engine_ter_m_travel_01_mk2";
        public static string Mk3(this Selector<Engine, Medium, Travel, Terran> selector) => "engine_ter_m_travel_01_mk3";

        public static string Mk1(this Selector<Engine, Small, AllRound, Terran> selector) => "engine_ter_s_allround_01_mk1";
        public static string Mk2(this Selector<Engine, Small, AllRound, Terran> selector) => "engine_ter_s_allround_01_mk2";
        public static string Mk3(this Selector<Engine, Small, AllRound, Terran> selector) => "engine_ter_s_allround_01_mk3";
        public static string Mk1(this Selector<Engine, Small, Combat, Terran> selector) => "engine_ter_s_combat_01_mk1";
        public static string Mk2(this Selector<Engine, Small, Combat, Terran> selector) => "engine_ter_s_combat_01_mk2";
        public static string Mk3(this Selector<Engine, Small, Combat, Terran> selector) => "engine_ter_s_combat_01_mk3";
        public static string Mk1(this Selector<Engine, Small, Travel, Terran> selector) => "engine_ter_s_travel_01_mk1";
        public static string Mk2(this Selector<Engine, Small, Travel, Terran> selector) => "engine_ter_s_travel_01_mk2";
        public static string Mk3(this Selector<Engine, Small, Travel, Terran> selector) => "engine_ter_s_travel_01_mk3";

        #endregion
    }
}