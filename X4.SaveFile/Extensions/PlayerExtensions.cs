using System.Xml;
using X4.SaveFile.Objects.Interfaces;

namespace X4.SaveFile.Extensions
{
    public static class PlayerExtensions
    {
        public static IPlayer AddBluePrint(this IPlayer player, string bluePrint)
        {
            var playerBluePrints = player
                .Node
                .SelectSingleNode("blueprints")!;
            var node = playerBluePrints
                .ResolveOrCreate(player.Node.OwnerDocument!, $"blueprint[@ware='{bluePrint}']");
            return player;
        }

        public static IPlayer RemoveBluePrint(this IPlayer player, string bluePrint)
        {
            var node = player
                .Node
                .SelectSingleNode($"blueprints/blueprint[@ware='{bluePrint}']");
            if (node != null)
            {
                node.ParentNode!
                    .RemoveChild(node);
            }
            return player;
        }

        public static IPlayer AddInventory(this IPlayer player, string name, int amount)
        {
            var playerInventory = player
                .Node
                .SelectSingleNode("inventory")!;
            var node = playerInventory
                .ResolveOrCreate(player.Node.OwnerDocument!, $"ware[@ware='{name}']")
                .ResolveOrCreate(player.Node.OwnerDocument!, "@amount").Value = amount.ToString();
            return player;
        }

        public static IPlayer RemoveInventory(this IPlayer player, string name, int amount)
        {
            var playerInventory = player
                .Node
                .SelectSingleNode("inventory")!;
            var node = playerInventory
                .SelectSingleNode($"ware[@ware='{name}']");
            if (node == null)
            {
                return player;
            }
            var amountNode = node
                .SelectSingleNode("@amount");
            if (amountNode == null || string.IsNullOrWhiteSpace(amountNode.Value) || amountNode.Value == "0")
            {
                node.ParentNode!
                    .RemoveChild(node);
                return player;
            }
            if (int.TryParse(amountNode.Value, out var currentAmount))
            {
                currentAmount = currentAmount - amount;
                if (currentAmount < 1)
                {
                    node.ParentNode!
                        .RemoveChild(node);
                    return player;
                }
                amountNode.Value = currentAmount.ToString();
                return player;
            }
            node.ParentNode!
                .RemoveChild(node);
            return player;
        }

        public static IPlayer MarkEnclopediaAsRead(this IPlayer player)
        {
            var nodes = player
                .Node
                .SelectNodes("known//entry/@read")!;
            foreach (XmlNode node in nodes)
            {
                node.Value = "1";
            }
            return player;
        }
    }
}