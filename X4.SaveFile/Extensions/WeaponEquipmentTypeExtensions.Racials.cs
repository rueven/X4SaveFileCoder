using X4.SaveFile.Objects.Implementations;
using X4.SaveFile.Objects.Interfaces.SelectorVectors;
using Argon = X4.SaveFile.Objects.Interfaces.SelectorVectors.IArgonRace;
using Khaak = X4.SaveFile.Objects.Interfaces.SelectorVectors.IKhaakRace;
using Large = X4.SaveFile.Objects.Interfaces.SelectorVectors.ILargeSize;
using Medium = X4.SaveFile.Objects.Interfaces.SelectorVectors.IMediumSize;
using Paranid = X4.SaveFile.Objects.Interfaces.SelectorVectors.IParanidRace;
using Small = X4.SaveFile.Objects.Interfaces.SelectorVectors.ISmallSize;
using Split = X4.SaveFile.Objects.Interfaces.SelectorVectors.ISplitRace;
using Teladi = X4.SaveFile.Objects.Interfaces.SelectorVectors.ITeladiRace;
using Terran = X4.SaveFile.Objects.Interfaces.SelectorVectors.ITerranRace;
using Weapon = X4.SaveFile.Objects.Interfaces.SelectorVectors.IWeaponEquipmentType;
using Xenon = X4.SaveFile.Objects.Interfaces.SelectorVectors.IXenonRace;

namespace X4.SaveFile.Extensions
{
    public static partial class WeaponEquipmentTypeExtensions
    {
        #region Argon

        public static RaceSelector<Weapon, TSize, Argon> Argon<TSize>(this Selector<Weapon, TSize> selector)
            where TSize : ISize => new() { Ship = selector.Ship };

        public static MakeOneSelector Destroyer(this RaceSelector<Weapon, Large, Argon> selector)
            => new(selector.Ship, "weapon_arg_l_destroyer_01_mk1");

        public static MakeTwoSelector Ion(this RaceSelector<Weapon, Medium, Argon> selector)
            => new(selector.Ship, "weapon_arg_m_ion_01_mk1", "weapon_arg_m_ion_01_mk2");

        public static MakeTwoSelector Ion(this RaceSelector<Weapon, Small, Argon> selector)
            => new(selector.Ship, "weapon_arg_s_ion_01_mk1", "weapon_arg_s_ion_01_mk2");

        #endregion

        #region Khaak

        public static RaceSelector<Weapon, Medium, Khaak> Khaak(this Selector<Weapon, Medium> selector)
        {
            return new RaceSelector<Weapon, Medium, Khaak>()
            {
                Ship = selector.Ship
            };
        }

        public static RaceSelector<Weapon, Small, Khaak> Khaak(this Selector<Weapon, Small> selector)
        {
            return new RaceSelector<Weapon, Small, Khaak>()
            {
                Ship = selector.Ship
            };
        }

        public static MakeOneSelector Laser(this RaceSelector<Weapon, Medium, Khaak> selector)
            => new(selector.Ship, "weapon_kha_m_laser_01_mk1");

        public static MakeOneSelector Laser(this RaceSelector<Weapon, Small, Khaak> selector)
            => new(selector.Ship, "weapon_kha_s_laser_01_mk1");

        #endregion

        #region Paranid

        public static RaceSelector<Weapon, TSize, Paranid> Paranid<TSize>(this Selector<Weapon, TSize> selector)
            where TSize : ISize => new() { Ship = selector.Ship };

        public static MakeOneSelector Destroyer(this RaceSelector<Weapon, Large, Paranid> selector)
            => new(selector.Ship, "weapon_par_l_destroyer_01_mk1");

        public static MakeTwoSelector Railgun(this RaceSelector<Weapon, Medium, Paranid> selector)
            => new(selector.Ship, "weapon_par_m_railgun_01_mk1", "weapon_par_m_railgun_01_mk2");

        public static MakeTwoSelector Railgun(this RaceSelector<Weapon, Small, Paranid> selector)
            => new(selector.Ship, "weapon_par_s_railgun_01_mk1", "weapon_par_s_railgun_01_mk2");

        #endregion

        #region Split

        public static RaceSelector<Weapon, TSize, Split> Split<TSize>(this Selector<Weapon, TSize> selector)
            where TSize : ISize => new() { Ship = selector.Ship };

        public static MakeOneSelector Destroyer(this RaceSelector<Weapon, Large, Split> selector)
            => new(selector.Ship, "weapon_spl_l_destroyer_01_mk1");

        public static MakeTwoSelector Nuetron(this RaceSelector<Weapon, Medium, Split> selector)
            => new(selector.Ship, "weapon_spl_m_gatling_01_mk1", "weapon_spl_m_gatling_01_mk2");

        public static MakeTwoSelector Boson(this RaceSelector<Weapon, Medium, Split> selector)
            => new(selector.Ship, "weapon_spl_m_railgun_01_mk1", "weapon_spl_m_railgun_01_mk2");

        public static MakeTwoSelector Tau(this RaceSelector<Weapon, Medium, Split> selector)
            => new(selector.Ship, "weapon_spl_m_shotgun_01_mk1", "weapon_spl_m_shotgun_01_mk2");

        public static MakeTwoSelector Thermal(this RaceSelector<Weapon, Medium, Split> selector)
            => new(selector.Ship, "weapon_spl_m_sticky_01_mk1", "weapon_spl_m_sticky_01_mk2");

        public static MakeTwoSelector Nuetron(this RaceSelector<Weapon, Small, Split> selector)
            => new(selector.Ship, "weapon_spl_s_gatling_01_mk1", "weapon_spl_s_gatling_01_mk2");

        public static MakeTwoSelector Boson(this RaceSelector<Weapon, Small, Split> selector)
            => new(selector.Ship, "weapon_spl_s_railgun_01_mk1", "weapon_spl_s_railgun_01_mk2");

        public static MakeTwoSelector Tau(this RaceSelector<Weapon, Small, Split> selector)
            => new(selector.Ship, "weapon_spl_s_shotgun_01_mk1", "weapon_spl_s_shotgun_01_mk2");

        public static MakeTwoSelector Thermal(this RaceSelector<Weapon, Small, Split> selector)
            => new(selector.Ship, "weapon_spl_s_sticky_01_mk1", "weapon_spl_s_sticky_01_mk2");

        #endregion

        #region Teladi

        public static RaceSelector<Weapon, TSize, Teladi> Teladi<TSize>(this Selector<Weapon, TSize> selector)
            where TSize : ISize => new() { Ship = selector.Ship };

        public static MakeOneSelector Destroyer(this RaceSelector<Weapon, Large, Teladi> selector)
            => new(selector.Ship, "weapon_tel_l_destroyer_01_mk1");

        public static MakeTwoSelector Muon(this RaceSelector<Weapon, Medium, Teladi> selector)
            => new(selector.Ship, "weapon_tel_m_charge_01_mk1", "weapon_tel_m_charge_01_mk2");

        public static MakeTwoSelector Muon(this RaceSelector<Weapon, Small, Teladi> selector)
            => new(selector.Ship, "weapon_tel_s_charge_01_mk1", "weapon_tel_s_charge_01_mk2");

        #endregion

        #region Terran

        public static RaceSelector<Weapon, TSize, Terran> Terran<TSize>(this Selector<Weapon, TSize> selector)
            where TSize : ISize => new() { Ship = selector.Ship };

        public static MakeOneSelector Destroyer(this RaceSelector<Weapon, Large, Terran> selector)
            => new(selector.Ship, "weapon_tel_l_destroyer_01_mk1");

        public static MakeTwoSelector Pulse(this RaceSelector<Weapon, Small, Terran> selector)
            => new(selector.Ship, "weapon_ter_s_laser_01_mk1", "weapon_ter_s_laser_01_mk2");

        public static MakeTwoSelector Gatling(this RaceSelector<Weapon, Small, Terran> selector)
            => new(selector.Ship, "weapon_ter_s_gatling_01_mk1", "weapon_ter_s_gatling_01_mk2");

        #endregion

        #region Xenon

        public static RaceSelector<Weapon, Medium, Xenon> Xenon(this Selector<Weapon, Medium> selector) => new() { Ship = selector.Ship };

        public static RaceSelector<Weapon, Small, Xenon> Xenon(this Selector<Weapon, Small> selector) => new() { Ship = selector.Ship };

        public static MakeOneSelector Pulse(this RaceSelector<Weapon, Medium, Xenon> selector)
            => new(selector.Ship, "weapon_xen_m_laser_01_mk1");

        public static MakeOneSelector Mining(this RaceSelector<Weapon, Medium, Xenon> selector)
            => new(selector.Ship, "weapon_xen_m_mining_01_mk1");

        public static MakeOneSelector Pulse(this RaceSelector<Weapon, Small, Xenon> selector)
            => new(selector.Ship, "weapon_xen_s_laser_01_mk1");

        #endregion
    }
}