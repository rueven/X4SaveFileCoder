namespace X4.SaveFile.Objects.Interfaces
{
    public interface ICharacter : ISeededXmlSaveFileElement, IMacroedXmlSaveFileElement { }

    public interface INamedCharacter : ICharacter, INamedXmlSaveFileElement { }

    public interface IPilot : INamedCharacter { }

    public interface IManager : INamedCharacter { }

    public interface IShipTrader : INamedCharacter { }

    public interface IInventoryTrader : INamedCharacter { }
}