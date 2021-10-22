using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPlayer : IPlayer
{
    new public string name = "KeyPlayer";

   

    // Update is called once per frame
   public override void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
            moveUp();
        else if (Input.GetKey(KeyCode.DownArrow))
            MoveDown();
    }
}
