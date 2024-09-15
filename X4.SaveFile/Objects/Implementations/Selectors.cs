using X4.SaveFile.Objects.Interfaces;
using X4.SaveFile.Objects.Interfaces.SelectorVectors;

namespace X4.SaveFile.Objects.Implementations
{
    public class Selector<TEquipmentType>
        where TEquipmentType : IEquipmentType
    {
        public required IShip Ship { get; init; }
    }

    public class Selector<TEquipmentType, TSize>
        where TEquipmentType : IEquipmentType
        where TSize : ISize
    {
        public required IShip Ship { get; init; }
    }

    public class Selector<TEquipmentType, TSize, TEquipmentTrim>
        where TEquipmentType : IEquipmentType
        where TSize : ISize
        where TEquipmentTrim : IEquipmentTrim
    {
        public required IShip Ship { get; init; }
    }

    public class Selector<TEquipmentType, TSize, TEquipmentTrim, TRace>
        where TEquipmentType : IEquipmentType
        where TSize : ISize
        where TEquipmentTrim : IEquipmentTrim
        where TRace : IRace
    {
        public required IShip Ship { get; init; }
    }

    public class RaceSelector<TEquipmentType, TSize, TRace>
        where TEquipmentType : IEquipmentType
        where TSize : ISize
        where TRace : IRace
    {
        public required IShip Ship { get; init; }
    }

    public class MakeOneSelector
    {
        public MakeOneSelector(IShip ship, string mk1Value)
        {
            this.Ship = ship;
            this.Mk1Value = mk1Value;
        }
        public IShip Ship { get; }
        private string Mk1Value { get; }
        public string Mk1() => this.Mk1Value;
    }

    public class MakeTwoSelector : MakeOneSelector
    {
        public MakeTwoSelector(IShip ship, string mk1Value, string mk2Value)
            : base(ship, mk1Value)
        {
            this.Mk2Value = mk2Value;
        }
        private string Mk2Value { get; }
        public string Mk2() => this.Mk2Value;
    }
}