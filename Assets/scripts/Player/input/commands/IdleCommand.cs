
class IdleCommand : Command
{
    private IdleState idleState;
    public override void Execute(Player player)
    {
        //Initialize idleState if it's not already initialized.
        if (idleState == null)
        {
            idleState = new IdleState();
        }
        player.State.SetState(player, idleState);
    }
}

