using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePlayer : IPlayer
{
    private float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        mouseY = Input.mousePosition.y;
        name = "MousePlayer";
    }

    // Update is called once per frame
    public  override void Update()
    {
        if (Input.mousePosition.y > mouseY)
            moveUp();
        else if (Input.mousePosition.y < mouseY)
            MoveDown();
        mouseY = Input.mousePosition.y;

    }
}
