using X4.SaveFile.Constants;
using X4.SaveFile.Objects.Interfaces;

namespace X4.SaveFile.Extensions
{
    public static class FactionExtensions
    {
        public static bool IsFaction(this IFaction faction, Faction id) => string
            .Equals(faction.Id, Enum.GetName(id)!.ToLower(), StringComparison.OrdinalIgnoreCase);

        public static IFaction AddLicense(this IFaction faction, License license, params IFaction[] otherFaction)
        {
            var factions = otherFaction
                .Aggregate(string.Empty, (x, y) => $"{x} {y}");
            faction
                .Node
                .OwnerDocument!
                .ResolveOrCreate($"licenses/license[@type='{license.GetDescription()}']/@factions")
                .Value = factions;
            return faction;
        }

        public static IFaction SetRelation(this IFaction faction, IFaction otherFaction, double value)
        {
            faction
                .Node
                .OwnerDocument!
                .SelectSingleNode("relations")!
                .ResolveOrCreate(faction.Node.OwnerDocument!, $"relation[@faction='{otherFaction}']/@relation")
                .Value = value.ToString();
            return faction;
        }
    }
}