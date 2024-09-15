using X4.SaveFile.Objects.Implementations;
using Medium = X4.SaveFile.Objects.Interfaces.SelectorVectors.IMediumSize;
using Small = X4.SaveFile.Objects.Interfaces.SelectorVectors.ISmallSize;
using Weapon = X4.SaveFile.Objects.Interfaces.SelectorVectors.IWeaponEquipmentType;

namespace X4.SaveFile.Extensions
{
    public static partial class WeaponEquipmentTypeExtensions
    {
        public static MakeTwoSelector Beam(this Selector<Weapon, Medium> selector)
            => new(selector.Ship, "weapon_gen_m_beam_01_mk1", "weapon_gen_m_beam_01_mk2");

        public static MakeTwoSelector Dumbfire(this Selector<Weapon, Medium> selector)
            => new(selector.Ship, "weapon_gen_m_dumbfire_01_mk1", "weapon_gen_m_dumbfire_01_mk2");

        public static MakeTwoSelector Gatling(this Selector<Weapon, Medium> selector)
            => new(selector.Ship, "weapon_gen_m_gatling_01_mk1", "weapon_gen_m_gatling_01_mk2");

        public static MakeTwoSelector Guided(this Selector<Weapon, Medium> selector)
            => new(selector.Ship, "weapon_gen_m_guided_01_mk1", "weapon_gen_m_guided_01_mk2");

        public static MakeTwoSelector Pulse(this Selector<Weapon, Medium> selector)
            => new(selector.Ship, "weapon_gen_m_laser_01_mk1", "weapon_gen_m_laser_01_mk2");

        public static MakeTwoSelector Mining(this Selector<Weapon, Medium> selector)
            => new(selector.Ship, "weapon_gen_m_mining_01_mk1", "weapon_gen_m_mining_01_mk2");

        public static MakeTwoSelector Plasma(this Selector<Weapon, Medium> selector)
            => new(selector.Ship, "weapon_gen_m_plasma_01_mk1", "weapon_gen_m_plasma_01_mk2");

        public static MakeTwoSelector Shotgun(this Selector<Weapon, Medium> selector)
            => new(selector.Ship, "weapon_gen_m_shotgun_01_mk1", "weapon_gen_m_shotgun_01_mk2");

        public static MakeTwoSelector Torpedo(this Selector<Weapon, Medium> selector)
            => new(selector.Ship, "weapon_gen_m_torpedo_01_mk1", "weapon_gen_m_torpedo_01_mk2");

        public static MakeTwoSelector Beam(this Selector<Weapon, Small> selector)
            => new(selector.Ship, "weapon_gen_s_beam_01_mk1", "weapon_gen_s_beam_01_mk2");

        public static MakeTwoSelector Burst(this Selector<Weapon, Small> selector)
            => new(selector.Ship, "weapon_gen_s_burst_01_mk1", "weapon_gen_s_burst_01_mk2");

        public static MakeTwoSelector Cannon(this Selector<Weapon, Small> selector)
            => new(selector.Ship, "weapon_gen_s_cannon_01_mk1", "weapon_gen_s_cannon_01_mk2");

        public static MakeTwoSelector Dumbfire(this Selector<Weapon, Small> selector)
            => new(selector.Ship, "weapon_gen_s_dumbfire_01_mk1", "weapon_gen_s_dumbfire_01_mk2");

        public static MakeTwoSelector Gatling(this Selector<Weapon, Small> selector)
            => new(selector.Ship, "weapon_gen_s_gatling_01_mk1", "weapon_gen_s_gatling_01_mk2");

        public static MakeTwoSelector Guided(this Selector<Weapon, Small> selector)
            => new(selector.Ship, "weapon_gen_s_guided_01_mk1", "weapon_gen_s_guided_01_mk2");

        public static MakeTwoSelector Pulse(this Selector<Weapon, Small> selector)
            => new(selector.Ship, "weapon_gen_s_laser_01_mk1", "weapon_gen_s_laser_01_mk2");

        public static MakeTwoSelector Mining(this Selector<Weapon, Small> selector)
            => new(selector.Ship, "weapon_gen_s_mining_01_mk1", "weapon_gen_s_mining_01_mk2");

        public static MakeTwoSelector Plasma(this Selector<Weapon, Small> selector)
            => new(selector.Ship, "weapon_gen_s_plasma_01_mk1", "weapon_gen_s_plasma_01_mk2");

        public static MakeTwoSelector Shotgun(this Selector<Weapon, Small> selector)
            => new(selector.Ship, "weapon_gen_s_shotgun_01_mk1", "weapon_gen_s_shotgun_01_mk2");

        public static MakeTwoSelector Torpedo(this Selector<Weapon, Small> selector)
            => new(selector.Ship, "weapon_gen_s_torpedo_01_mk1", "weapon_gen_s_torpedo_01_mk2");
    }
}