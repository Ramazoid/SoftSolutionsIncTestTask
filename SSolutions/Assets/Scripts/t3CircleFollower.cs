using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class t3CircleFollower : MonoBehaviour
{
    private RectTransform rt;
    public Text info;
    private bool scale=false;
    private float scaleFactor=1;
    private float speed=0.1f;
    private bool drag;
    public Texture2D cursorDrag;

    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (drag)
            transform.position = Input.mousePosition;
        else
            transform.position = Vector3.Lerp(transform.position, Input.mousePosition, speed);

        if (scale)
        {
            scaleFactor += Input.mouseScrollDelta.y / 100;
            info.text = "RMB:Mode, MWheel:Scale:" + scaleFactor;
            transform.localScale = Vector3.one * scaleFactor;
        }
        else
        {
            speed += Input.mouseScrollDelta.y / 100;
            info.text = "RMB:Mode, MWheel:Speed:" + speed;
        }

        if (Input.GetMouseButtonDown(1))
            scale = !scale;

    }

    public void DragOn()
    {
        drag = true;
    }

    public void DragOff()
    {
        drag = false;
        Cursor.SetCursor (null,Vector2.zero,CursorMode.Auto);
    }

    public void CursorON()
    {
        Cursor.SetCursor (cursorDrag, Vector2.zero, CursorMode.Auto);
        print("ON");
    }
    public void CursorOff()
    {
        print("OFF");
        Cursor.SetCursor (null,Vector2.zero,CursorMode.Auto);
    }
    
}
