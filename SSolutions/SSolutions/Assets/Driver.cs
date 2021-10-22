using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public IPlayer player;
    public string playerDriver;
    public float multiplyer=10;
    public RectTransform tr;
    private bool stop;

    public void Setup(IPlayer controller)
    {
        player = controller;
        player.moveUp = Moveup;
        player.MoveDown = MoveDown;
        tr = GetComponent<RectTransform>();
    }
    void Start()
    {
        //player = new KeyPlayer();

        multiplyer = 10;
    

    }

    private void Moveup()
    {
        Vector3 delta = Vector3.up* multiplyer;
        if (transform.localPosition.y+delta.y < 180)
        transform.position += delta;
        
    }
    private  void MoveDown()
    {
        Vector3 delta = Vector3.up * multiplyer;
        if (transform.localPosition.y-delta.y>-170)
        transform.position -= delta;
    }

    
    void Update()
    {
        if (player!=null)
            player.Update();
    }
}
