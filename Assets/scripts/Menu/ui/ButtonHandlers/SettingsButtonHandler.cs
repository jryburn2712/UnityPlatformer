using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    private Text btnText;
    private Color originalColor, lightBlue;

    // Use this for initialization
    void Start()
    {
        btnText = GetComponentInChildren<Text>();
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

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    
	
	// Update is called once per frame
	void Update () {
		
	}
}
