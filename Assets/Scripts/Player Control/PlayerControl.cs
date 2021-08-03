using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : BaseControl
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ControlPersonaje();   
    }

    protected override void ControlPersonaje()
    {
        float horizontal=Input.GetAxis("Horizontal");
        direction=new Vector2(horizontal,0);
        
        base.ControlPersonaje();
    }
}
