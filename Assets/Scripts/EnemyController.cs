using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("wall and floor")]
    //ground and wall checks
    private bool
        groundDetec,
        wallDetec;
    [SerializeField]
    private Transform
        groundCheck,
        wallCheck;

    [SerializeField]
    private LayerMask
        whatIsGround,
        whatIsWall;

    [SerializeField]
    private float
        groundCheckDistance,
        wallCheckDistance;


    //flipping enemy
    private int facingDirec = 1;

    //enemy get stuff
    private GameObject enemy;
    private Rigidbody enemyRB;

    //get other stuff
    private PlayerController pc;

    [Header("enemy characteristics")]
    [SerializeField]
    private float
        speedPatrol;
   

    private Vector2 movement;
    [SerializeField]
    private float HPmax;
    private float HPcurrent;
    //create state machine

    private enum State
    {
        patrol,
        chase, //maybe put some climbing in if they are chasing you
        attack,
        dead

    }    
    private State currentState;




    //start

    void Start()
    {
       
        //get components
        enemy = transform.Find("Enemy").gameObject;
        enemyRB = enemy.GetComponent<Rigidbody>();

        pc = GameObject.Find("Player").GetComponent<PlayerController>();



        HPcurrent = HPmax;

       

    }

    //update what state is active
    void Update()
    {
      
        transform.position += new Vector3(speedPatrol, 0, 0) * Time.deltaTime;

        switch (currentState)
        {
            case State.patrol:
                UpdatePatrolState();
                break;
            case State.chase:
                UpdateChaseState();
                break;
            case State.attack:
                UpdateAttackState();
                break;
            case State.dead:
                UpdateDeadState();
                break;
        }
        
    }

    //state switching
    private void SwitchState(State state)
    {
        //exit function
        switch (currentState)
        {
            case State.patrol:
                ExitPatrolState();
                break;
            case State.chase:
                ExitChaseState();
                break;
            case State.attack:
                ExitAttackState();
                break;
            case State.dead:
                ExitDeadState();
                break;
        }


        //enter function
        switch (state)
        {
            case State.patrol:
                EnterPatrolState();
                break;
            case State.chase:
                EnterChaseState();
                break;
            case State.attack:
                EnterAttackState();
                break;
            case State.dead:
                EnterDeadState();
                break;
        }
        currentState = state;
    }


    //non state functions ____________________________________________________________________________________________________________________________________________________________________________________________________
    private void Flip()
    {
        facingDirec *= -1;
        enemy.transform.Rotate(0f, 180f, 0f);
    }




    //gets called by SendMessage on the bullets, this is dmg it takes
    //private void DealDmg(float amount)
    //{
    //    HPcurrent -= amount;
    //    Debug.Log("enemy hp is" + HPcurrent);
    //    if (HPcurrent <=  0f)
    //    {
    //        HPcurrent = 0f;
    //    }
    //}


    //patrol ____________________________________________________________________________________________________________________________________________________________________________________________________

    private void EnterPatrolState()
    {

    }

    private void UpdatePatrolState()
    {
        //raycast to see if has to flip
        //find vector to calculate raycast
        groundDetec = Physics.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetec = Physics.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsWall);

        if (!groundDetec || wallDetec)
        {
            Debug.Log(groundDetec + "ground");
            Debug.Log(wallDetec + "wall");

            //flip 
            Flip();



        }
        
        else
        {
            //move
            transform.position = new Vector3(transform.position.x * speedPatrol, transform.position.y, transform.position.z);


        }
    }

    private void ExitPatrolState()
    {

    }



    //chase ____________________________________________________________________________________________________________________________________________________________________________________________________


    private void EnterChaseState()
    {

    }

    private void UpdateChaseState()
    {

    }

    private void ExitChaseState()
    {

    }
    //attack ____________________________________________________________________________________________________________________________________________________________________________________________________

    private void EnterAttackState()
    {

    }

    private void UpdateAttackState()
    {

    }

    private void ExitAttackState()
    {

    }




    //dead ____________________________________________________________________________________________________________________________________________________________________________________________________
    //here i rotate the thingy to get the boi done
    private void EnterDeadState()
    {
        float torque;
        torque = 1f;
        enemyRB.AddTorque(0, 0, torque);
    }

    private void UpdateDeadState()
    {
        
    }

    private void ExitDeadState()
    {

    }
 

}
