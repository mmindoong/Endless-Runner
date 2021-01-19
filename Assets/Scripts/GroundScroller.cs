using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public Sprite Land;
    public Sprite Background;
    public float scrollSpeed;
    private SpriteRenderer Scroller;
    private Vector2 scrollOffset = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        Scroller = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameOver)
        {
            scrollOffset = Scroller.material.mainTextureOffset;
            scrollOffset.x += (scrollSpeed * Time.deltaTime);
            Scroller.material.mainTextureOffset = scrollOffset;
        }

        switch (GameManager.instance.stage)
        {
            case 2:
                Scroller.sprite = Background;
                Scroller.transform.localScale = new Vector3(4.15f, 3.112499f, 1.0f);
                break;
            case 3:
                Scroller.sprite = Land;
                Scroller.transform.localScale = new Vector3(15.67497f, 12.37498f, 1.0f);
                break;
        }
    }
}