public interface IState
{
    void OnStateEnter(Player player);
    void OnStateExit(Player player);
    void SetState(Player player, IState state);
    void Tick(Player player);
}