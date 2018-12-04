interface IInputHandler
{
    void OnMovePressed(Player player, Direction direction);
    void OnJumpPressed(Player player);
    void OnAttackPressed(Player player);

    void OnMoveReleased(Player player, Direction direction);
    void OnJumpReleased(Player player);
    void OnAttackReleased(Player player);

    void OnNothingPressed(Player player);
}