
class MoveCommand : Command
{

    private MoveState moveState;
    public override void Execute(Player player)
    {
        //Initialize moveState if it's not already initialized.
        if (moveState == null)
        {
            moveState = new MoveState();
        }
        player.State.SetState(player, moveState);
    }
}

