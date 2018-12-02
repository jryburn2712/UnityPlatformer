class JumpCommand : Command
{
	private JumpState jumpState;

    public JumpCommand()
    {
        jumpState = new JumpState();
    }

    public override void Execute(Player player)
    {        
        player.State.SetState(player, jumpState);
    }
}