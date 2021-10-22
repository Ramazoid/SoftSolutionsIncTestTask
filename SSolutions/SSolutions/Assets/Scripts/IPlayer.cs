using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPlayer
{
    public Action moveUp;
    public Action MoveDown;
    public string name;
   
    public virtual void Init() { 
    }

     public virtual void Update()
        {
    
        }
}