using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompPlayer : IPlayer
{
    private float mouseY;
    private Ball ball;
    private Driver player;

    public CompPlayer(Ball ball, Driver player)
    {
        this.ball = ball;
        this.player = player;
    }

    // Start is called before the first frame update
    void Start()
    {
        mouseY = Input.mousePosition.y;
        
    }

    // Update is called once per frame
    public  override void Update()
    {
        if (ball.transform.position.y> player.transform.position.y)
            moveUp();
        else if (ball.transform.position.y < player.transform.position.y)
            MoveDown();
        

    }
}
