class IdleCommand : Command
{
    private IdleState idleState;

    public IdleCommand()
    {
        idleState = new IdleState();
    }

    public override void Execute(Player player)
    {    
        player.State.SetState(player, idleState);
    }
}