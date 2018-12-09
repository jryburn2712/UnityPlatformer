
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class MenuButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Text btnText;
    private Color lightBlue;
    private Color originalColor;


    protected virtual void Start()
    {
        lightBlue = new Color32(173, 216, 230, 255);    
        btnText = GetComponentInChildren<Text>();
        originalColor = btnText.color;        
    }

    protected virtual void Update()
    {

    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        btnText.color = lightBlue;
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        btnText.color = originalColor;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
