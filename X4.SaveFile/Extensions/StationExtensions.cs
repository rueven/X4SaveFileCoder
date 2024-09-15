using System.Xml;
using X4.SaveFile.Objects.Implementations;
using X4.SaveFile.Objects.Interfaces;

namespace X4.SaveFile.Extensions
{
    public static class StationExtensions
    {
        public static IStation Manager(this IStation station, Action<IManager> method)
            => station.NamedCharacter("manager", x => method?.Invoke((IManager)x));

        public static IStation ShipTrader(this IStation station, Action<IShipTrader> method)
            => station.NamedCharacter("shiptrader", x => method?.Invoke((IShipTrader)x));

        public static IStation InventoryTraders(this IStation station, Action<IInventoryTrader> method)
            => station.NamedCharacter("trader", x => method?.Invoke((IInventoryTrader)x));

        private static IStation NamedCharacter(this IStation station, string post, Action<INamedCharacter> method)
        {
            var pointer = station
                .Node
                .SelectSingleNode(@$"control/post[@id='{post}']/@component");
            if (pointer != null)
            {
                var node = station
                    .Node
                    .SelectSingleNode($"//component[@class='npc'][@id='{pointer.Value}']");
                if (node != null)
                {
                    var namedCharacter = new XmlSaveFileElement()
                    {
                        Node = node
                    };
                    method?.Invoke(namedCharacter);
                }
            }
            return station;
        }

        public static IReadOnlyList<string> GetListOfStationModules(this IStation station)
        {
            var nodes = station
                .Node
                .SelectNodes($@"connections/connection[@connection=""modules""]/component/@macro");
            var output = new List<string>();
            if (nodes != null && nodes.Count > 0)
            {
                foreach (XmlNode node in nodes)
                {
                    output.Add(node.Value!);
                }
            }
            return output;
        }

        public static IStation RemoveAllCurrentBuildRequirements(this IStation station)
        {
            var nodes = station
                .Node
                .SelectNodes("//component[@class='buildprocessor']/resources/ware/@amount");
            foreach (XmlNode node in nodes)
            {
                node.Value = "0";
            }
            return station;
        }
    }
}