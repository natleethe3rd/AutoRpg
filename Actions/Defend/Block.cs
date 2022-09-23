﻿using ConsoleApp1.Contexts;

namespace ConsoleApp1.Actions.Defend;

internal class Block : IAction
{
    public string Name => "Block";

    public string Description => "Prevents some damage";

    public ActionType Type => ActionType.Defend;

    public ActionContext Execute(IContext aContext, ITargetable aTarget)
    {
        int fAdjustedValue = aTarget.ApplyDefense(1);

        return new ActionContext(aContext, this, aTarget, fAdjustedValue);
    }

    public IEnumerable<ITargetable> ValidTargets(IContext aContext)
    {
        return new List<ITargetable> { aContext.Self };
    }
}
