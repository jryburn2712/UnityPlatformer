

interface IInputHandler
{
    void OnMovePressed(Player player, Direction direction);
    void OnJumpPressed(Player player);

    void OnMoveReleased(Player player, Direction direction);
    void OnJumpReleased(Player player);

    void OnNothingPressed(Player player);
}

