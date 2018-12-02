using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenBackground : MonoBehaviour {

    SpriteRenderer backgroundSpriteRenderer;

    void Awake()
    {
        //backgroundSpriteRenderer = GetComponent<SpriteRenderer>();
        //float cameraHeight = Camera.main.orthographicSize * 2;
        //Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        //Vector2 spriteSize = backgroundSpriteRenderer.sprite.bounds.size;

        //Vector2 scale = transform.localScale;
        //if (cameraSize.x >= cameraSize.y)
        //{
        //    scale *= cameraSize.x / cameraSize.y;
        //} else
        //{
        //    scale *= cameraSize.y / spriteSize.y;
        //}

        //transform.position = Vector2.zero;
        //transform.localScale = scale;

        backgroundSpriteRenderer = GetComponent<SpriteRenderer>();
        if (backgroundSpriteRenderer == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        float width = backgroundSpriteRenderer.sprite.bounds.size.x;
        float height = backgroundSpriteRenderer.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}