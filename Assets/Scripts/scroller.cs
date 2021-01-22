using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroller : MonoBehaviour
{

    
    private float speed;
    private Vector2 end;
    private Vector2 start;

    private void Start()
    {
        speed = 5f;
        end = new Vector2(-22, -4.5f);
        start = new Vector2(22, -4.5f);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < end.x)
        {
            Vector2 pos = new Vector2(start.x, transform.position.y);
            transform.position = pos;
        }
    }
}