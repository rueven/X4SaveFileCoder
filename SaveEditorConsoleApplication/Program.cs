using X4.SaveFile.Extensions;
using X4.SaveFile.Services.Implementations;
using X4.SaveFile.Services.Interfaces;

var i = 1;
ISaveFileService service = new SaveFileService();
var file = await service.LoadFromGZipSlot(1);

var faction = file
    .Factions()
    .First(x => x.IsFaction(X4.SaveFile.Constants.Faction.Player));

var ships = file
    .Ships()
    .Where(x => x.IsOwnedBy(X4.SaveFile.Constants.Faction.Scaleplate))
    .ToList();

var ship = file
    .FindShipByCode("DSA-999")!
    .AsExtraLargeShip()
    .Code("ASD-100")
    .Thrusters(x => x.AllRound().Mk3())
    .Shields(x => x.Argon().Mk1())
    .Engines(x => x.AllRound().Argon().Mk1())
    .Weapons(x => x.Small().Argon().Ion().Mk2())
    .WeaponSlot(1, x => x.Small().Argon().Ion().Mk2())
    .ModifyWeapons()
    .ModifyTurrets()
    .ModifyTurretGroups()
    .ModifyChassisWithStreamlinedHull()
    .ModifyEnginesSpeed()
    .ModifyShields()
    .Pilot(pilot =>
    {

    });