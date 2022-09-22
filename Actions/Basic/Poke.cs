﻿using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Basic;

internal class Poke : IAction
{
    public string Name => "Poke";

    public string Description => "Poke the weakest enemy";

    public ActionType Type => ActionType.Basic;

    public ActionContext Execute(IContext aContext)
    {
        ICharacter fTarget = aContext.Enemies.Where(a => a.IsAlive).OrderByDescending(a => a.HealthPoints).Last();
        int fAdjusted = fTarget.ApplyDamage(1);

        return new ActionContext(aContext, this, fTarget, fAdjusted);
    }
}
