
using UnityEngine.EventSystems;

public class ResumeButtonHandler : MenuButtonHandler
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        GameManager.Instance.GameState.SetGameState(GameManager.Instance.gameStates[GameStateType.PLAYGAME]);
    }
}

