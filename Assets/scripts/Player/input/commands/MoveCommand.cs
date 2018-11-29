
class MoveCommand : Command
{

    private MoveState moveState;

    public MoveCommand()
    {
        moveState = new MoveState();
    }

    public override void Execute(Player player)
    {        
        player.State.SetState(player, moveState);
    }
}

