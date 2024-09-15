using X4.SaveFile.Objects.Implementations;

namespace X4.SaveFile.Services.Interfaces
{
    public interface ISaveFileService
    {
        Task<XmlSaveFile> LoadFromGZipSlot(int slot);
        Task<XmlSaveFile> LoadFromSlot(int slot);
        Task Save(XmlSaveFile file);
    }
}