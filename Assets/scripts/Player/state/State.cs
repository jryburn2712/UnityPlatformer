public abstract class State : IState
{
    public virtual void OnStateEnter(Player player)
    {
        
    }

    public virtual void OnStateExit(Player player)
    {
        
    }

    public virtual void SetState(Player player, IState state)
    {
        player.State.OnStateExit(player);
        player.State = state;
        player.State.OnStateEnter(player);
    }

    public abstract void Tick(Player player);
    
}