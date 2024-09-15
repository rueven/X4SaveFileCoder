namespace X4.SaveFile.Objects.Interfaces.SelectorVectors
{
    public interface IRace { }
    public interface IArgonRace : IRace { }
    public interface ITerranRace : IRace { }
    public interface IKhaakRace : IRace { }
    public interface IParanidRace : IRace { }
    public interface ISplitRace : IRace { }
    public interface ITeladiRace : IRace { }
    public interface IXenonRace : IRace { }


    public interface IEquipmentType { }
    public interface IShieldEquipmentType : IEquipmentType { }
    public interface IThrusterEquipmentType : IEquipmentType { }
    public interface IEngineEquipmentType : IEquipmentType { }
    public interface IWeaponEquipmentType : IEquipmentType { }
    public interface ITurretEquipmentType : IEquipmentType { }

    public interface ISize { }
    public interface IExtraLargeSize : ISize { }
    public interface ILargeSize : ISize { }
    public interface IMediumSize : ISize { }
    public interface ISmallSize : ISize { }

    public interface IEquipmentTrim { }
    public interface IAllRoundEquipmentTrim : IEquipmentTrim { }
    public interface ICombatEquipmentTrim : IEquipmentTrim { }
    public interface ITravelEquipmentTrim : IEquipmentTrim { }
}
