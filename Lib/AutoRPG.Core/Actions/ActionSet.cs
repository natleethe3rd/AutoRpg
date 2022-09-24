﻿namespace AutoRPG.Core.Actions;

public class ActionSet
{
    private readonly IAction mrBasic;
    private readonly IAction mrSupport;
    private readonly IAction mrDefend;
    private readonly IAction mrAttack;

    internal ActionSet(IAction aBasic, IAction aSupport, IAction aDefend, IAction aAttack)
    {
        mrBasic = VerifyActionType(aBasic, ActionType.Basic);
        mrSupport = VerifyActionType(aSupport, ActionType.Support);
        mrDefend = VerifyActionType(aDefend, ActionType.Defend);
        mrAttack = VerifyActionType(aAttack, ActionType.Attack);
    }

    private IAction VerifyActionType(IAction aActionToCheck, ActionType aTypeItShouldBe)
    {
        if (aActionToCheck.Type != aTypeItShouldBe)
        {
            throw new ArgumentException($"Action {aActionToCheck} was supposed to be {aTypeItShouldBe} - instead it was {aActionToCheck.Type}");
        }
        return aActionToCheck;
    }

    public IAction Basic => mrBasic;

    public IAction Support => mrSupport;

    public IAction Defend => mrDefend;

    public IAction Attack => mrAttack;

    public string Summary => "\n> " + string.Join("\n> ", Basic.Name, Support.Name, Defend.Name, Attack.Name);
}
