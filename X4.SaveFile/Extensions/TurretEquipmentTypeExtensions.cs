using X4.SaveFile.Objects.Implementations;
using X4.SaveFile.Objects.Interfaces.SelectorVectors;
using ExtraLarge = X4.SaveFile.Objects.Interfaces.SelectorVectors.IExtraLargeSize;
using Large = X4.SaveFile.Objects.Interfaces.SelectorVectors.ILargeSize;
using Medium = X4.SaveFile.Objects.Interfaces.SelectorVectors.IMediumSize;
using Small = X4.SaveFile.Objects.Interfaces.SelectorVectors.ISmallSize;
using Turret = X4.SaveFile.Objects.Interfaces.SelectorVectors.ITurretEquipmentType;
using Argon = X4.SaveFile.Objects.Interfaces.SelectorVectors.IArgonRace;
using Khaak = X4.SaveFile.Objects.Interfaces.SelectorVectors.IKhaakRace;
using Paranid = X4.SaveFile.Objects.Interfaces.SelectorVectors.IParanidRace;
using Split = X4.SaveFile.Objects.Interfaces.SelectorVectors.ISplitRace;
using Teladi = X4.SaveFile.Objects.Interfaces.SelectorVectors.ITeladiRace;
using Terran = X4.SaveFile.Objects.Interfaces.SelectorVectors.ITerranRace;
using Xenon = X4.SaveFile.Objects.Interfaces.SelectorVectors.IXenonRace;

namespace X4.SaveFile.Extensions
{
    public static class TurretEquipmentTypeExtensions
    {
        public static Selector<Turret, ExtraLarge> ExtraLarge(this Selector<Turret> selector)
        {
            return new Selector<Turret, ExtraLarge>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Turret, Large> Large(this Selector<Turret> selector)
        {
            return new Selector<Turret, Large>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Turret, Medium> Medium(this Selector<Turret> selector)
        {
            return new Selector<Turret, Medium>()
            {
                Ship = selector.Ship
            };
        }

        public static Selector<Turret, Small> Small(this Selector<Turret> selector)
        {
            return new Selector<Turret, Small>()
            {
                Ship = selector.Ship
            };
        }

        #region Argon

        public static RaceSelector<Turret, Large, Argon> Argon(this Selector<Turret, Large> selector)
            => new() { Ship = selector.Ship };

        public static RaceSelector<Turret, Medium, Argon> Argon(this Selector<Turret, Medium> selector)
            => new() { Ship = selector.Ship };

        //public static RaceSelector<Turret, Small, Argon> Argon(this Selector<Turret, Small> selector)
        //    => new() { Ship = selector.Ship };

        public static MakeOneSelector Beam(this RaceSelector<Turret, Large, Argon> selector)
            => new(selector.Ship, "turret_arg_l_beam_01_mk1");

        public static MakeOneSelector Dumbfire(this RaceSelector<Turret, Large, Argon> selector)
            => new(selector.Ship, "turret_arg_l_dumbfire_01_mk1");

        public static MakeOneSelector Guided(this RaceSelector<Turret, Large, Argon> selector)
            => new(selector.Ship, "turret_arg_l_guided_01_mk1");

        public static MakeOneSelector Pulse(this RaceSelector<Turret, Large, Argon> selector)
            => new(selector.Ship, "turret_arg_l_laser_01_mk1");

        public static MakeOneSelector Mining(this RaceSelector<Turret, Large, Argon> selector)
            => new(selector.Ship, "turret_arg_l_mining_01_mk1");

        public static MakeOneSelector Plasma(this RaceSelector<Turret, Large, Argon> selector)
            => new(selector.Ship, "turret_arg_l_plasma_01_mk1");

        public static MakeTwoSelector Beam(this RaceSelector<Turret, Medium, Argon> selector)
            => new(selector.Ship, "turret_arg_m_beam_01_mk1", "turret_arg_m_beam_02_mk1");

        public static MakeTwoSelector Dumbfire(this RaceSelector<Turret, Medium, Argon> selector)
            => new(selector.Ship, "turret_arg_m_dumbfire_01_mk1", "turret_arg_m_dumbfire_02_mk1");

        public static MakeTwoSelector Flak(this RaceSelector<Turret, Medium, Argon> selector)
            => new(selector.Ship, "turret_arg_m_flak_01_mk1", "turret_arg_m_flak_02_mk1");

        public static MakeTwoSelector Gatling(this RaceSelector<Turret, Medium, Argon> selector)
            => new(selector.Ship, "turret_arg_m_gatling_01_mk1", "turret_arg_m_gatling_02_mk1");

        public static MakeTwoSelector Guided(this RaceSelector<Turret, Medium, Argon> selector)
            => new(selector.Ship, "turret_arg_m_guided_01_mk1", "turret_arg_m_guided_02_mk1");

        public static MakeTwoSelector Pulse(this RaceSelector<Turret, Medium, Argon> selector)
            => new(selector.Ship, "turret_arg_m_laser_01_mk1", "turret_arg_m_laser_02_mk1");

        public static MakeTwoSelector Mining(this RaceSelector<Turret, Medium, Argon> selector)
            => new(selector.Ship, "turret_arg_m_mining_01_mk1", "turret_arg_m_mining_02_mk1");

        public static MakeTwoSelector Plasma(this RaceSelector<Turret, Medium, Argon> selector)
            => new(selector.Ship, "turret_arg_m_plasma_01_mk1", "turret_arg_m_plasma_02_mk1");

        public static MakeTwoSelector Shotgun(this RaceSelector<Turret, Medium, Argon> selector)
            => new(selector.Ship, "turret_arg_m_shotgun_01_mk1", "turret_arg_m_shotgun_02_mk1");

        //public static MakeTwoSelector Pulse(this RaceSelector<Turret, Small, Argon> selector)
        //    => new(selector.Ship, "turret_arg_m_shotgun_01_mk1", "turret_arg_m_shotgun_02_mk1");

        //public static MakeTwoSelector Gatling(this RaceSelector<Turret, Small, Argon> selector)
        //    => new(selector.Ship, "turret_arg_m_shotgun_01_mk1", "turret_arg_m_shotgun_02_mk1");

        //public static MakeTwoSelector Shotgun(this RaceSelector<Turret, Small, Argon> selector)
        //    => new(selector.Ship, "turret_arg_m_shotgun_01_mk1", "turret_arg_m_shotgun_02_mk1");

        #endregion

        #region Khaak

        public static RaceSelector<Turret, Medium, Khaak> Khaak(this Selector<Turret, Medium> selector)
            => new() { Ship = selector.Ship };

        public static MakeOneSelector Beam(this RaceSelector<Turret, Medium, Khaak> selector)
            => new(selector.Ship, "turret_kha_m_beam_01_mk1");

        #endregion

        #region Paranid

        public static RaceSelector<Turret, Large, Paranid> Paranid(this Selector<Turret, Large> selector)
            => new() { Ship = selector.Ship };

        public static RaceSelector<Turret, Medium, Paranid> Paranid(this Selector<Turret, Medium> selector)
            => new() { Ship = selector.Ship };

        public static MakeOneSelector Beam(this RaceSelector<Turret, Large, Paranid> selector)
            => new(selector.Ship, "turret_par_l_beam_01_mk1");

        public static MakeOneSelector Dumbfire(this RaceSelector<Turret, Large, Paranid> selector)
            => new(selector.Ship, "turret_par_l_dumbfire_01_mk1");

        public static MakeOneSelector Guided(this RaceSelector<Turret, Large, Paranid> selector)
            => new(selector.Ship, "turret_par_l_guided_01_mk1");

        public static MakeOneSelector Pulse(this RaceSelector<Turret, Large, Paranid> selector)
            => new(selector.Ship, "turret_par_l_laser_01_mk1");

        public static MakeOneSelector Mining(this RaceSelector<Turret, Large, Paranid> selector)
            => new(selector.Ship, "turret_par_l_mining_01_mk1");

        public static MakeOneSelector Plasma(this RaceSelector<Turret, Large, Paranid> selector)
            => new(selector.Ship, "turret_par_l_plasma_01_mk1");

        public static MakeTwoSelector Beam(this RaceSelector<Turret, Medium, Paranid> selector)
            => new(selector.Ship, "turret_par_m_beam_01_mk1", "turret_par_m_beam_02_mk1");

        public static MakeTwoSelector Dumbfire(this RaceSelector<Turret, Medium, Paranid> selector)
            => new(selector.Ship, "turret_par_m_dumbfire_01_mk1", "turret_par_m_dumbfire_02_mk1");

        public static MakeTwoSelector Gatling(this RaceSelector<Turret, Medium, Paranid> selector)
            => new(selector.Ship, "turret_par_m_gatling_01_mk1", "turret_par_m_gatling_02_mk1");

        public static MakeTwoSelector Guided(this RaceSelector<Turret, Medium, Paranid> selector)
            => new(selector.Ship, "turret_par_m_guided_01_mk1", "turret_par_m_guided_02_mk1");

        public static MakeTwoSelector Pulse(this RaceSelector<Turret, Medium, Paranid> selector)
            => new(selector.Ship, "turret_par_m_laser_01_mk1", "turret_par_m_laser_02_mk1");

        public static MakeTwoSelector Mining(this RaceSelector<Turret, Medium, Paranid> selector)
            => new(selector.Ship, "turret_par_m_mining_01_mk1", "turret_par_m_mining_02_mk1");

        public static MakeTwoSelector Plasma(this RaceSelector<Turret, Medium, Paranid> selector)
            => new(selector.Ship, "turret_par_m_plasma_01_mk1", "turret_par_m_plasma_02_mk1");

        public static MakeTwoSelector Shotgun(this RaceSelector<Turret, Medium, Paranid> selector)
            => new(selector.Ship, "turret_par_m_shotgun_01_mk1", "turret_par_m_shotgun_02_mk1");

        #endregion

        #region Split

        public static RaceSelector<Turret, Large, Split> Split(this Selector<Turret, Large> selector)
            => new() { Ship = selector.Ship };

        public static RaceSelector<Turret, Medium, Split> Split(this Selector<Turret, Medium> selector)
            => new() { Ship = selector.Ship };

        public static MakeOneSelector Beam(this RaceSelector<Turret, Large, Split> selector)
            => new(selector.Ship, "turret_spl_l_beam_01_mk1");

        public static MakeOneSelector Dumbfire(this RaceSelector<Turret, Large, Split> selector)
            => new(selector.Ship, "turret_spl_l_dumbfire_01_mk1");

        public static MakeOneSelector Guided(this RaceSelector<Turret, Large, Split> selector)
            => new(selector.Ship, "turret_spl_l_guided_01_mk1");

        public static MakeOneSelector Pulse(this RaceSelector<Turret, Large, Split> selector)
            => new(selector.Ship, "turret_spl_l_laser_01_mk1");

        public static MakeOneSelector Mining(this RaceSelector<Turret, Large, Split> selector)
            => new(selector.Ship, "turret_spl_l_mining_01_mk1");

        public static MakeOneSelector Plasma(this RaceSelector<Turret, Large, Split> selector)
            => new(selector.Ship, "turret_spl_l_plasma_01_mk1");

        public static MakeTwoSelector Beam(this RaceSelector<Turret, Medium, Split> selector)
            => new(selector.Ship, "turret_spl_m_beam_01_mk1", "turret_spl_m_beam_02_mk1");

        public static MakeTwoSelector Dumbfire(this RaceSelector<Turret, Medium, Split> selector)
            => new(selector.Ship, "turret_spl_m_dumbfire_01_mk1", "turret_spl_m_dumbfire_02_mk1");

        public static MakeTwoSelector Flak(this RaceSelector<Turret, Medium, Split> selector)
            => new(selector.Ship, "turret_spl_m_flak_01_mk1", "turret_spl_m_flak_02_mk1");

        public static MakeTwoSelector Gatling(this RaceSelector<Turret, Medium, Split> selector)
            => new(selector.Ship, "turret_spl_m_gatling_01_mk1", "turret_spl_m_gatling_02_mk1");

        public static MakeTwoSelector Guided(this RaceSelector<Turret, Medium, Split> selector)
            => new(selector.Ship, "turret_spl_m_guided_01_mk1", "turret_spl_m_guided_02_mk1");

        public static MakeTwoSelector Pulse(this RaceSelector<Turret, Medium, Split> selector)
            => new(selector.Ship, "turret_spl_m_laser_01_mk1", "turret_spl_m_laser_02_mk1");

        public static MakeTwoSelector Mining(this RaceSelector<Turret, Medium, Split> selector)
            => new(selector.Ship, "turret_spl_m_mining_01_mk1", "turret_spl_m_mining_02_mk1");

        public static MakeTwoSelector Plasma(this RaceSelector<Turret, Medium, Split> selector)
            => new(selector.Ship, "turret_spl_m_plasma_01_mk1", "turret_spl_m_plasma_02_mk1");

        public static MakeTwoSelector Shotgun(this RaceSelector<Turret, Medium, Split> selector)
            => new(selector.Ship, "turret_spl_m_shotgun_01_mk1", "turret_spl_m_shotgun_02_mk1");

        #endregion

        #region Teladi

        public static RaceSelector<Turret, Large, Teladi> Teladi(this Selector<Turret, Large> selector)
            => new() { Ship = selector.Ship };

        public static RaceSelector<Turret, Medium, Teladi> Teladi(this Selector<Turret, Medium> selector)
            => new() { Ship = selector.Ship };

        public static MakeOneSelector Beam(this RaceSelector<Turret, Large, Teladi> selector)
            => new(selector.Ship, "turret_tel_l_beam_01_mk1");

        public static MakeOneSelector Dumbfire(this RaceSelector<Turret, Large, Teladi> selector)
            => new(selector.Ship, "turret_tel_l_dumbfire_01_mk1");

        public static MakeOneSelector Guided(this RaceSelector<Turret, Large, Teladi> selector)
            => new(selector.Ship, "turret_tel_l_guided_01_mk1");

        public static MakeOneSelector Pulse(this RaceSelector<Turret, Large, Teladi> selector)
            => new(selector.Ship, "turret_tel_l_laser_01_mk1");

        public static MakeOneSelector Mining(this RaceSelector<Turret, Large, Teladi> selector)
            => new(selector.Ship, "turret_tel_l_mining_01_mk1");

        public static MakeOneSelector Plasma(this RaceSelector<Turret, Large, Teladi> selector)
            => new(selector.Ship, "turret_tel_l_plasma_01_mk1");

        public static MakeTwoSelector Beam(this RaceSelector<Turret, Medium, Teladi> selector)
            => new(selector.Ship, "turret_tel_m_beam_01_mk1", "turret_tel_m_beam_02_mk1");

        public static MakeTwoSelector Dumbfire(this RaceSelector<Turret, Medium, Teladi> selector)
            => new(selector.Ship, "turret_tel_m_dumbfire_01_mk1", "turret_tel_m_dumbfire_02_mk1");

        public static MakeTwoSelector Gatling(this RaceSelector<Turret, Medium, Teladi> selector)
            => new(selector.Ship, "turret_tel_m_gatling_01_mk1", "turret_tel_m_gatling_02_mk1");

        public static MakeTwoSelector Guided(this RaceSelector<Turret, Medium, Teladi> selector)
            => new(selector.Ship, "turret_tel_m_guided_01_mk1", "turret_tel_m_guided_02_mk1");

        public static MakeTwoSelector Pulse(this RaceSelector<Turret, Medium, Teladi> selector)
            => new(selector.Ship, "turret_tel_m_laser_01_mk1", "turret_tel_m_laser_02_mk1");

        public static MakeTwoSelector Mining(this RaceSelector<Turret, Medium, Teladi> selector)
            => new(selector.Ship, "turret_tel_m_mining_01_mk1", "turret_tel_m_mining_02_mk1");

        public static MakeTwoSelector Plasma(this RaceSelector<Turret, Medium, Teladi> selector)
            => new(selector.Ship, "turret_tel_m_plasma_01_mk1", "turret_tel_m_plasma_02_mk1");

        public static MakeTwoSelector Shotgun(this RaceSelector<Turret, Medium, Teladi> selector)
            => new(selector.Ship, "turret_tel_m_shotgun_01_mk1", "turret_tel_m_shotgun_02_mk1");

        #endregion

        #region Xenon

        public static RaceSelector<Turret, Large, Xenon> Xenon(this Selector<Turret, Large> selector)
            => new() { Ship = selector.Ship };

        public static RaceSelector<Turret, Medium, Xenon> Xenon(this Selector<Turret, Medium> selector)
            => new() { Ship = selector.Ship };

        public static MakeOneSelector Pulse(this RaceSelector<Turret, Large, Xenon> selector)
            => new(selector.Ship, "turret_xen_l_laser_01_mk1");

        public static MakeOneSelector Beam(this RaceSelector<Turret, Medium, Xenon> selector)
            => new(selector.Ship, "turret_xen_m_beam_02_mk1");

        public static MakeTwoSelector Pulse(this RaceSelector<Turret, Medium, Xenon> selector)
            => new(selector.Ship, "turret_xen_m_laser_01_mk1", "turret_xen_m_laser_02_mk1");

        #endregion
    }
}