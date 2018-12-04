class AttackCommand : Command
{
    public AttackState attackState;

    public AttackCommand()
    {
        attackState = new AttackState();
    }

    public override void Execute(Player player)
    {
        player.State.SetState(player, attackState);
    }
}