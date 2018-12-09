using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayButtonHandler : MenuButtonHandler {

    private CanvasGroup canvas;
    private AudioSource audioSource;
    

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        canvas = GameObject.FindWithTag("UICanvas").GetComponent<CanvasGroup>();
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        //Lock canvas once game is started to avoid multiple presses.
        canvas.interactable = false;
        StartCoroutine(fade());
    }

    private IEnumerator fade()
    {
        while (canvas.alpha > 0)
        {
            canvas.alpha -= Time.deltaTime / 2;
            audioSource.volume -= Time.deltaTime / 2;
            yield return null;
        }
        //Game is ready to start at this point. Set gameState to playing.
        GameManager.Instance.GameState.SetGameState(GameManager.Instance.gameStates[GameStateType.PLAYGAME]);
        yield return null;
    }
}
