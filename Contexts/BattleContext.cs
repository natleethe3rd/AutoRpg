﻿using ConsoleApp1.Actions;

namespace ConsoleApp1.Contexts;

internal class BattleContext : IContext
{
    private static readonly List<ICharacter> msrInitiativeOrder = new();

    internal BattleContext(ICharacter aSelf, Party aAllies, Party aEnemies)
    {
        Self = aSelf;
        Allies = aAllies;
        Enemies = aEnemies;
    }

    public static void SetUpForBattle(Party aPartyA, Party aPartyB)
    {
        msrInitiativeOrder.Clear();
        foreach (ICharacter aCharacter in aPartyA)
        {
            aCharacter.Context = new BattleContext(aCharacter, aPartyA, aPartyB);
        }

        foreach (ICharacter aCharacter in aPartyB)
        {
            aCharacter.Context = new BattleContext(aCharacter, aPartyB, aPartyA);
        }

        for (int i = 0; i < 4; i++)
        {
            msrInitiativeOrder.Add(aPartyA.ElementAt(i));
            msrInitiativeOrder.Add(aPartyB.ElementAt(i));
        }
    }

    public static void NextRound(Action<ActionContext> func)
    {
        foreach (ICharacter character in msrInitiativeOrder)
        {
            character.ResetForRound();
        }

        foreach (ICharacter fActiveCharacter in msrInitiativeOrder)
        {
            if (!fActiveCharacter.Context.Enemies.StillKickin) break;
            if (!fActiveCharacter.IsAlive) continue;

            ActionContext fResult = fActiveCharacter.DoAnyAction();

            func(fResult);
        }
    }

    public ICharacter Self { get; set; }

    public Party Allies { get; set; }

    public Party Enemies { get; set; }
}
