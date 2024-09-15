using System.IO.Compression;
using System.Xml;
using X4.SaveFile.Objects.Implementations;
using X4.SaveFile.Services.Interfaces;

namespace X4.SaveFile.Services.Implementations
{
    public class SaveFileService : ISaveFileService
    {
        public Task<XmlSaveFile> LoadFromGZipSlot(int slot)
        {
            var filePath = $@"c:\users\{Environment.UserName}\documents\egosoft\x4\44625032\save\save_{slot.ToString("D3")}.xml.gz";
            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var zipper = new GZipStream(stream, CompressionMode.Decompress);
            using var memoryStream = new MemoryStream();
            zipper.CopyTo(memoryStream);
            memoryStream.Position = 0;
            var document = new XmlDocument();
            document.Load(memoryStream);
            return Task.FromResult(new XmlSaveFile(true, filePath, document));
        }

        public Task<XmlSaveFile> LoadFromSlot(int slot)
        {
            var filePath = $@"c:\users\{Environment.UserName}\documents\egosoft\x4\44625032\save\save_{slot.ToString("D3")}.xml";
            var document = new XmlDocument();
            document.Load(filePath);
            return Task.FromResult(new XmlSaveFile(false, filePath, document));
        }

        public Task Save(XmlSaveFile file)
        {
            ArgumentNullException.ThrowIfNull(file, nameof(file));
            if (file.IsCompressed)
            {
                File.Delete(file.Filepath);
                using var stream = new FileStream(file.Filepath, FileMode.CreateNew);
                using var zipper = new GZipStream(stream, CompressionLevel.Optimal);
                file.Document
                    .Save(zipper);
            }
            else
            {
                file.Document
                    .Save(file.Filepath);
            }
            return Task.CompletedTask;
        }
    }
}