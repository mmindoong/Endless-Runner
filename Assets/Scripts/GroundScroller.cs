using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public SpriteRenderer[] tiles;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i<tiles.Length;i++)
        {
            tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime *speed);
        }
        
    }
}
