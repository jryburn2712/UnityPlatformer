public abstract class State : IState, IInputHandler
{
    public virtual void OnJumpPressed(Player player)
    {
        
    }

    public virtual void OnMovePressed(Player player, Direction direction)
    {

    }

    public virtual void OnAttackPressed(Player player)
    {
        
    }

    public virtual void OnAttackReleased(Player player)
    {

    }
    

    public virtual void OnMoveReleased(Player player, Direction direction)
    {

    }

    public virtual void OnJumpReleased(Player player)
    {

    }

    public virtual void OnNothingPressed(Player player)
    {

    }

    public virtual void OnStateEnter(Player player)
    {
        
    }

    public virtual void OnStateExit(Player player)
    {
        
    }

    public virtual void SetState(Player player, State state)
    {
        player.State.OnStateExit(player);
        player.State = state;
        player.State.OnStateEnter(player);
    }

    public abstract void Tick(Player player);
}