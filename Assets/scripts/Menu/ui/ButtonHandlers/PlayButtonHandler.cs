using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    private Text btnText;
    private Color originalColor, lightBlue;
    private CanvasGroup canvas;
    private AudioSource audioSource;
    

    // Use this for initialization
    void Start()
    {
        canvas = GameObject.FindWithTag("UICanvas").GetComponent<CanvasGroup>();
        audioSource = Camera.main.GetComponent<AudioSource>();
        btnText = GetComponentInChildren <Text>();
        originalColor = btnText.color;
        lightBlue = new Color32(173, 216, 230, 255);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        btnText.color = lightBlue;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        btnText.color = originalColor;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
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
