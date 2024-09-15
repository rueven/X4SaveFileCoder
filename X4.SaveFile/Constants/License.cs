using System.ComponentModel;

namespace X4.SaveFile.Constants
{
    public enum License
    {
        [Description("capitalequipment")]
        CapitalEquipment,
        [Description("capitalship")]
        CapitalShip,
        [Description("militaryequipment")]
        MilitaryEquipment,
        [Description("militaryship")]
        MilitaryShip,
        [Description("police")]
        Police,
        [Description("station_illegal")]
        StationIllegal,
        [Description("generaluseequipment")]
        GeneralUseEquipment,
        [Description("generaluseship")]
        GeneralUseShip
    }
}