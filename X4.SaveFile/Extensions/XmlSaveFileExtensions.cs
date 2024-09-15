using System.Xml;
using X4.SaveFile.Objects.Implementations;
using X4.SaveFile.Objects.Interfaces;

namespace X4.SaveFile.Extensions
{
    public static class XmlSaveFileExtensions
    {
        public static XmlSaveFile Player(this XmlSaveFile file, Action<IPlayer> method)
        {
            var node = file
                .Document
                .SelectSingleNode("//component[@class='player']");
            if (node != null)
            {
                method?.Invoke(new XmlSaveFileElement()
                {
                    Node = node
                });
            }
            return file;
        }

        public static IFaction? FindFaction(this XmlSaveFile file, string name)
        {
            var node = file
                .Document
                .SelectSingleNode($"savegame/universe/factions/faction[@id='{name}']");
            if (node == null)
            {
                return null;
            }
            return new XmlSaveFileElement()
            {
                Node = node
            };
        }

        public static IReadOnlyList<IFaction> Factions(this XmlSaveFile file)
        {
            var nodes = file
                .Document
                .SelectNodes($"savegame/universe/factions/faction");
            if (nodes == null || nodes.Count == 0)
            {
                return [];
            }
            var output = new List<IFaction>();
            foreach (XmlNode node in nodes)
            {
                output.Add(new XmlSaveFileElement()
                {
                    Node = node
                });
            }
            return output;
        }

        public static IStation? FindStationByCode(this XmlSaveFile file, Code code)
        {
            var node = file
                .Document
                .SelectSingleNode($"//component[@class='station'][@code='{code}']");
            if (node == null)
            {
                return null;
            }
            return new XmlSaveFileElement()
            {
                Node = node
            };
        }

        public static IReadOnlyList<IStation> Stations(this XmlSaveFile file)
        {
            var nodes = file
                .Document
                .SelectNodes("//component[@class='station']");
            if (nodes == null || nodes.Count == 0)
            {
                return [];
            }
            var output = new List<IStation>();
            foreach (XmlNode node in nodes)
            {
                output.Add(new XmlSaveFileElement()
                {
                    Node = node
                });
            }
            return output;
        }

        public static IAnonymousShip? FindShipByCode(this XmlSaveFile file, Code code)
        {
            var node = file
                .Document
                .SelectSingleNode($"//component[@class='ship_s' or @class='ship_m' or @class='ship_l' or @class='ship_xl'][@code='{code}']");
            if (node == null)
            {
                return null;
            }
            return new XmlSaveFileElement()
            {
                Node = node
            };
        }

        public static IReadOnlyList<IAnonymousShip> Ships(this XmlSaveFile saveFile)
        {
            var nodes = saveFile
                .Document
                .SelectNodes("//component[@class='ship_s' or @class='ship_m' or @class='ship_l' or @class='ship_xl']");
            if (nodes == null || nodes.Count == 0)
            {
                return [];
            }
            var output = new List<IAnonymousShip>();
            foreach (XmlNode node in nodes)
            {
                output.Add(new XmlSaveFileElement()
                {
                    Node = node
                });
            }
            return output;
        }
    }
}