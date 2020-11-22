using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header ("movement")]
  
    public float moveSpeed;
    public float jumpForce;
    public float gravityForce;
    public float wallForce;

    [Header("dash")]
 
    public float dashSpeed;
    public float dashDur;
    public float dashFalloff;

    private bool isDashing = false;
    private float dashvalue = 0;
    private bool isDashFalloff = false;
    private Vector2 moveDirection;

    [Header("controller")]

    public CharacterController controller;
    public InputAction Leftstick;
    public InputAction buttonA;
    public InputAction buttonLT;
    public InputAction buttonRT;
    public InputAction Rightstick;

    [Header("gameobjects")]
    // get access to playeraimin
    public GameObject ShootConeObject;
    PlayerCone scriptPlayerAiming;
    // playershoot access
    public GameObject PlayerGunObject;
    PlayerShoot scriptPlayerShoot;


    //controller enabling and disabling


    private void OnEnable()
    {
        Leftstick.Enable();
        buttonA.Enable();
        buttonLT.Enable();
        buttonRT.Enable();
        Rightstick.Enable();

    }

    private void OnDisable()
    {
        Leftstick.Disable();
        buttonA.Disable();
        buttonLT.Disable();
        buttonRT.Disable();
        Rightstick.Disable();

    }

 //character controller

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //get player aiming and shooting
        scriptPlayerAiming = ShootConeObject.GetComponent<PlayerCone>();
        scriptPlayerShoot = PlayerGunObject.GetComponent<PlayerShoot>();
    }


    void Update()
    {
        // controller
        Vector2 inputVectorMove = Leftstick.ReadValue<Vector2>();       
        Vector2 inputVectorView = Rightstick.ReadValue<Vector2>();
        //Debug.Log(inputVectorView + "view");
        if (!isDashing && !isDashFalloff)
        {
            PlayerMovements();
        }
        //jump back here for the dash
        else if (isDashing)
        {
            controller.Move(inputVectorMove * Time.deltaTime * dashSpeed);
           // Debug.Log(dashvalue);
        }
      

        if (controller.isGrounded)
            dashvalue = 0;
           
        if (dashvalue < 3 && !controller.isGrounded && buttonLT.triggered)
        {
            StartCoroutine(Dash());
            StartCoroutine(DashFalloff());

            
        }
        else if (dashvalue >= 3)
        {
            isDashing = false;
        }

        //activate aim
        playerAimingJoystick();

        // shooting
        float rtPress = buttonRT.ReadValue<float>();
        if (rtPress == 1)
        {
            scriptPlayerShoot.Fire();



        }
    }

    //dash co-routine to give variable
    IEnumerator Dash()
    {

        float startTime = Time.time;

       
        while (Time.time < startTime + dashDur)
        {
            isDashing = true;
            yield return null;
        }
        dashvalue = dashvalue + 1f;
        isDashing = false;

        
        
    }
    IEnumerator DashFalloff ()
    {
        float startTime = Time.time;
        while (Time.time < startTime + dashFalloff)
        {
            isDashFalloff = true;
            yield return null;

        }
        isDashFalloff = false;

    }

    //all player movement, always the same indipendent from class and character for now
    void PlayerMovements()
    {
        //enabling joystick
        float aPress = buttonA.ReadValue<float>();
        Vector2 inputVector = Leftstick.ReadValue<Vector2>();

        //horizontal movement
        moveDirection.x = inputVector.x * moveSpeed;

        //jump
        if (controller.isGrounded && aPress==1)
        {
            moveDirection.y = jumpForce;
        }

        //gravity
        if (isDashing == false)
        {
        moveDirection.y = moveDirection.y + (Physics.gravity.y * Time.deltaTime * gravityForce);
        }

        //final movement
        controller.Move(moveDirection * Time.deltaTime);       
    }

    //wall scramble -> you have to spam jump to get up wall
    private void OnControllerColliderHit(ControllerColliderHit hit)

    {
        
       
        if (!controller.isGrounded && hit.normal.y < 0.1f && buttonA.triggered)
        {
            Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
            moveDirection.y = wallForce;
        }
    }
    //aim update code
    void playerAimingJoystick ()
    {
        Vector2 inputVector = Rightstick.ReadValue<Vector2>();
       // Debug.Log(inputVector + "view");
       /*
        scriptPlayerAiming.SetAimDirection(inputVector);
        /*scriptPlayerAiming.SetOrigin(transform.position);*/


    }



}
