using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float UpCorrection;
    public float speed = 1;
    internal Action<int> Scoring;
    public RectTransform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right*speed+Vector3.up*UpCorrection;
        if (transform.position.x > Screen.width)
            Scoring(2);
        else if (transform.position.x < 0)
            Scoring(1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision)");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       

        if (collision.gameObject.tag == "Player")
        {
            float delta = +collision.gameObject.transform.position.y - transform.position.y;
            UpCorrection -= delta / 10;
            speed = -speed;
        }
        else if (collision.gameObject.tag == "Wall")
            UpCorrection = -UpCorrection;
    }
}
