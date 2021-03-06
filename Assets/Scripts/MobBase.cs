﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{
    public float mobSpeed = 0;
    public Vector2 startPosition;

    private void OnEnable()
    {
        transform.position = startPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * mobSpeed);

        if(transform.position.x < -6)
        {
            gameObject.SetActive(false);
        }
    }
}
