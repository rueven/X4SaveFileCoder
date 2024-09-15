using System.Xml;
using X4.SaveFile.Objects.Implementations;
using X4.SaveFile.Objects.Interfaces;
using X4.SaveFile.Objects.Interfaces.SelectorVectors;

namespace X4.SaveFile.Extensions
{
    public static partial class ShipExtensions
    {
        private static TShip ForEachWeapon<TShip>(this TShip ship, Action<XmlNode> method)
            where TShip : IShip
        {
            var nodes = ship
                .Node
                .SelectNodes("connections/connection[starts-with(@connection, 'con_') and contains(@connection, 'weapon')]/component[@class='weapon']/..");
            if (nodes != null && nodes.Count == 0)
            {
                foreach (XmlNode node in nodes)
                {
                    method?.Invoke(node);
                }
            }
            return ship;
        }

        private static TShip UseWeaponSlot<TShip>(this TShip ship, int slot, Action<XmlNode> method)
            where TShip : IShip
        {
            var node = ship
                .Node
                .SelectFirstSingleNonNullNode
                (
                    $"connections/connection[@connection='con_primaryweapon_{slot.ToString("D2")}']",
                    $"connections/connection[@connection='con_primaryweapon_{slot.ToString("D3")}']",
                    $"connections/connection[@connection='con_primaryweapon_{slot.ToString("D4")}']",
                    $"connections/connection[@connection='con_secondaryweapon_{slot.ToString("D2")}']",
                    $"connections/connection[@connection='con_secondaryweapon_{slot.ToString("D3")}']",
                    $"connections/connection[@connection='con_secondaryweapon_{slot.ToString("D4")}']",
                    $"connections/connection[@connection='con_weapon_{slot.ToString("D2")}']",
                    $"connections/connection[@connection='con_weapon_{slot.ToString("D3")}']",
                    $"connections/connection[@connection='con_weapon_{slot.ToString("D4")}']"
                );
            if (node != null)
            {
                method(node);
            }
            return ship;
        }

        public static TShip WeaponSlot<TShip>(this TShip ship, int slot, Func<Selector<IWeaponEquipmentType>, string> selector)
            where TShip : IShip
        {
            var start = new Selector<IWeaponEquipmentType>()
            {
                Ship = ship
            };
            var type = selector(start);
            return ship
                .WeaponSlot(slot, type + "_macro");
        }
        
        public static TShip WeaponSlot<TShip>(this TShip ship, int slot, string macro)
            where TShip : IShip
        {
            return ship
                .UseWeaponSlot(slot, node =>
                {
                    var component = node
                        .SelectSingleNode("component");
                    if (component != null)
                    {
                        component.ResolveOrCreate(ship.Node.OwnerDocument!, "@macro").Value = macro;
                        component.ResolveOrCreate(ship.Node.OwnerDocument!, "@class").Value = "weapon";
                    }
                });
        }

        public static TShip Weapons<TShip>(this TShip ship, Func<Selector<IWeaponEquipmentType>, string> selector)
            where TShip : IShip
        {
            var start = new Selector<IWeaponEquipmentType>()
            {
                Ship = ship
            };
            var type = selector(start);
            return ship
                .Weapons(type + "_macro");
        }

        public static TShip WeaponReplacements<TShip>(this TShip ship, Func<Selector<IWeaponEquipmentType>, string> findSelector, Func<Selector<IWeaponEquipmentType>, string> replaceSelector)
            where TShip : IShip
        {
            var start = new Selector<IWeaponEquipmentType>()
            {
                Ship = ship
            };
            var findType = findSelector(start);
            var replaceType = replaceSelector(start);
            return ship
                .WeaponReplacements(findType + "_macro", replaceType + "_macro");
        }

        public static TShip Weapons<TShip>(this TShip ship, string macro)
            where TShip : IShip
        {
            return ship
                .ForEachWeapon(node =>
                {
                    var component = node
                        .SelectSingleNode("component");
                    if (component != null)
                    {
                        component.ResolveOrCreate(ship.Node.OwnerDocument!, "@macro").Value = macro;
                    }
                });
        }

        public static TShip WeaponReplacements<TShip>(this TShip ship, string findMacro, string replaceMacro)
            where TShip : IShip
        {
            return ship
                .ForEachWeapon(node =>
                {
                    var component = node
                        .SelectSingleNode("component");
                    if (component != null)
                    {
                        var macroNode = component
                            .SelectSingleNode("@macro")!;
                        if (macroNode.Value == findMacro)
                        {
                            macroNode.Value = replaceMacro;
                        }
                    }
                });
        }

        public static TShip ModifyWeaponSlot<TShip>(this TShip ship, int slot, double damage = 1.75D, double reload = 1.5D, double speed = 2D, double rotationSpeed = 1.5D)
            where TShip : IShip
        {
            return ship
                .UseWeaponSlot(slot, node =>
                {
                    var weapon = node
                        .ResolveOrCreate(ship.Node.OwnerDocument!, "component/modification");
                    weapon.ResolveOrCreate(ship.Node.OwnerDocument!, "@ware").Value = "mod_weapon_speed_01_mk3";
                    weapon.ResolveOrCreate(ship.Node.OwnerDocument!, "@damage").Value = damage.ToString();
                    weapon.ResolveOrCreate(ship.Node.OwnerDocument!, "@reload").Value = reload.ToString();
                    weapon.ResolveOrCreate(ship.Node.OwnerDocument!, "@speed").Value = speed.ToString();
                    weapon.ResolveOrCreate(ship.Node.OwnerDocument!, "@rotationspeed").Value = rotationSpeed.ToString();     
                });
        }

        public static TShip ModifyWeapons<TShip>(this TShip ship, double damage = 1.75D, double reload = 1.5D, double speed = 2D, double rotationSpeed = 1.5D)
            where TShip : IShip
        {
            return ship
                .ForEachWeapon(node =>
                {
                    var weapon = node
                        .ResolveOrCreate(ship.Node.OwnerDocument!, "component/modification");
                    weapon.ResolveOrCreate(ship.Node.OwnerDocument!, "@ware").Value = "mod_weapon_speed_01_mk3";
                    weapon.ResolveOrCreate(ship.Node.OwnerDocument!, "@damage").Value = damage.ToString();
                    weapon.ResolveOrCreate(ship.Node.OwnerDocument!, "@reload").Value = reload.ToString();
                    weapon.ResolveOrCreate(ship.Node.OwnerDocument!, "@speed").Value = speed.ToString();
                    weapon.ResolveOrCreate(ship.Node.OwnerDocument!, "@rotationspeed").Value = rotationSpeed.ToString();
                });
        }

        public static TShip ModifyMatchedWeapons<TShip>(this TShip ship, Func<Selector<IWeaponEquipmentType>, string> selector, double damage = 1.75D, double reload = 1.5D, double speed = 2D, double rotationSpeed = 1.5D)
            where TShip : IShip
        {
            var start = new Selector<IWeaponEquipmentType>()
            {
                Ship = ship
            };
            var type = selector(start) + "_macro";
            return ship
                .ForEachWeapon(node =>
                {
                    var component = node
                        .SelectSingleNode("component");
                    if (component != null)
                    {
                        var macroNode = component
                            .SelectSingleNode("@macro")!;
                        if (macroNode.Value == type)
                        {
                            var modification = node.ResolveOrCreate(ship.Node.OwnerDocument!, "modification");
                            modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@ware").Value = "mod_weapon_speed_01_mk3";
                            modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@damage").Value = damage.ToString();
                            modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@reload").Value = reload.ToString();
                            modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@speed").Value = speed.ToString();
                            modification.ResolveOrCreate(ship.Node.OwnerDocument!, "@rotationspeed").Value = rotationSpeed.ToString();
                        }
                    }
                });
        }
    }
}