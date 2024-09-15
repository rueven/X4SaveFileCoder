using System.Xml;
using X4.SaveFile.Objects.Interfaces;

namespace X4.SaveFile.Extensions
{
    public static partial class ShipExtensions
    {
        private static TShip ForEachTurret<TShip>(this TShip ship, Action<XmlNode> method)
            where TShip : IShip
        {
            var nodes = ship
                .Node
                .SelectNodes("connections/connection[starts-with(@connection, 'con_') and contains(@connection, 'turret')]/component[@class='turret']/..");
            if (nodes != null && nodes.Count == 0)
            {
                foreach (XmlNode node in nodes)
                {
                    method?.Invoke(node);
                }
            }
            return ship;
        }

        public static TShip ModifyTurrets<TShip>(this TShip ship, double speed = 1.15D, double damage = 1.3D, double rotationSpeed = 1.3D, double reload = 1.1D)
            where TShip : IShip
        {
            return ship
                .ForEachTurret(node =>
                {
                    var modification = node
                        .ResolveOrCreate(ship.Node.OwnerDocument!, "component/modification");
                    modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@ware").Value = "mod_weapon_speed_01_mk3";
                    modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@damage").Value = damage.ToString();
                    modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@speed").Value = speed.ToString();
                    modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@reload").Value = reload.ToString();
                    modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@rotationspeed").Value = rotationSpeed.ToString();
                    //modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@lifetime").Value = lifetime.ToString();
                });
        }

        public static TShip RemoveTurretModifications<TShip>(this TShip ship)
            where TShip : IShip
        {
            return ship
                .ForEachTurret(node =>
                {
                    var component = node
                        .SelectSingleNode("component")!;
                    var modification = component
                        .SelectSingleNode("modification");
                    if (modification != null)
                    {
                        component
                            .RemoveChild(modification);
                    }
                });
        }

        public static TShip ModifyTurretGroups<TShip>(this TShip ship, double capacity = 1.3D, double rechargeDelay = .7D, double rechargeRate = 1.7D, double speed = 1.15D, double damage = 1.3D, double rotationSpeed = 1.3D, double reload = 1.1D)
            where TShip : IShip
        {
            var nodes = ship
                .Node
                .SelectNodes("shields/group");
            if (nodes != null && nodes.Count > 0)
            {
                foreach (XmlNode node in nodes)
                {
                    var modifications = node
                        .SelectNodes("modification")!;
                    foreach (XmlNode childNode in modifications)
                    {
                        node.RemoveChild(childNode);
                    }
                    var modification = node
                        .ResolveOrCreate(ship.Node.OwnerDocument!, "modification");
                    modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@ware").Value = "mod_shield_capacity_02_mk3";
                    modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@capacity").Value = capacity.ToString();
                    modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@rechargedelay").Value = rechargeDelay.ToString();
                    modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@rechargerate").Value = rechargeRate.ToString();
                    var weapon = modification
                        .ResolveOrCreate(ship.Node.OwnerDocument!, "weapon");
                    weapon.ResolveOrCreate(ship.Node.OwnerDocument!, "@ware").Value = "mod_weapon_speed_01_mk3";
                    weapon.ResolveOrCreate(ship.Node.OwnerDocument!, "@damage").Value = damage.ToString();
                    weapon.ResolveOrCreate(ship.Node.OwnerDocument!, "@speed").Value = speed.ToString();
                    weapon.ResolveOrCreate(ship.Node.OwnerDocument!, "@reload").Value = reload.ToString();
                    weapon.ResolveOrCreate(ship.Node.OwnerDocument!, "@rotationspeed").Value = rotationSpeed.ToString();
                }
            }
            return ship;
        }
    }
}