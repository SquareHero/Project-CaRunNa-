using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : Unit {
    //Player status setup
    public float speed= 5;
    public float jumpHeight =10;
    public float sprintSpeed =1;

    //Player input setup
    public XboxController player;
    public XboxButton sprintBt;
    public XboxButton jumpBt;
    public XboxButton switchItemBt;
    public XboxButton punchBt;
    public XboxButton climbBt;
    public XboxButton kickBt;
    public XboxButton useItemBt;
    public XboxButton switchTargetBt;

    //Private val.
    private float horizontalInput;
    private float verticalInput;
    //Cam seting
    private float camHorizontalInput;
    private float camVerticalInput;
    private Camera cam;

    //Start func. override
    protected override void Start()
    {
        base.Start();
        cam = GetComponentInChildren<Camera>();

    }

    private void Update()
    {
        //get input from box controller
        horizontalInput = XCI.GetAxis(XboxAxis.LeftStickX, player);
        verticalInput   = XCI.GetAxis(XboxAxis.LeftStickY, player);
        camHorizontalInput = XCI.GetAxis(XboxAxis.RightStickY, player);
        camVerticalInput = XCI.GetAxis(XboxAxis.RightStickX, player);
        
        //create Vector3 input collect the val.
        Vector3 input = new Vector3(horizontalInput,0, verticalInput) * speed * sprintSpeed;
       
        //ClampMagnitude make it to be same value in every direction
        input = Vector3.ClampMagnitude(input, speed * sprintSpeed);
        
        //Check input from controller and do something
        if (XCI.GetButtonDown(sprintBt, player))
        {
            //Q?
            sprintSpeed = 2;
           //TODO set every state doning faster
        }
        if (XCI.GetButtonUp(sprintBt, player))
        {
            sprintSpeed = 1;
            //TODO reset to normal state
        }
        if (XCI.GetButtonDown(jumpBt, player))
        {
            input.y = jumpHeight;
            //TODO set jumo animation
        }
        //if not jump Player Y velocity is what they was before
        else { input.y = rb.velocity.y; }

        //change Player velocity
        rb.velocity = transform.InverseTransformVector(input);
    }
}
