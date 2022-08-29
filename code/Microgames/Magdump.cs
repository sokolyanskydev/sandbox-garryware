﻿using Sandbox;

namespace Garryware.Microgames;

/// <summary>
/// Players have to shoot all of their ammo before time runs out or they lose.
/// </summary>
public class Magdump : Microgame
{
    public Magdump()
    {
        Rules = MicrogameRules.LoseOnTimeout;
        ActionsUsedInGame = PlayerAction.PrimaryAttack;
        GameLength = 3.0f;
    }

    public override void Setup()
    {
        ShowInstructions("Get ready...");
    }

    public override void Start()
    {
        ShowInstructions("Empty your clip!");
        var weapons = GiveWeapon<Pistol>(To.Everyone);
        foreach (var weapon in weapons)
        {
            weapon.MagazineEmpty += OnMagazineEmpty;
        }
    }

    private void OnMagazineEmpty(AmmoWeapon weapon)
    {
        if (IsGameFinished())
            return;

        if (weapon.Owner is GarrywarePlayer player)
        {
            player.FlagAsRoundWinner();
            player.RemoveWeapons();
        }
    }

    public override void Finish()
    {
        RemoveAllWeapons();
    }

    public override void Cleanup()
    {
    }
}
