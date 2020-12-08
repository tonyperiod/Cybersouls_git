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
        speedPatrol,
        maxHP;

    private Vector2 movement;

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

    private void Start()
    {
        //get components
        enemy = transform.Find("Enemy").gameObject;
        enemyRB = enemy.GetComponent<Rigidbody>();

        pc = GameObject.Find("Player").GetComponent<PlayerController>();



        HPcurrent = HPmax;



    }

    //update what state is active
    private void Update()
    {
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


    //used funcions ____________________________________________________________________________________________________________________________________________________________________________________________________
    private void Flip()
    {
        facingDirec *= -1;
        enemy.transform.Rotate(0f, 180f,0f);
    }

    private void Damage()
    {

    }

    //gets called by SendMessage on the bullets, this is dmg it takes
    private void DealDmg(float amount)
    {
        HPcurrent -= amount;
        Debug.Log("enemy hp is" + HPcurrent);
        if (HPcurrent <=  0f)
        {
            HPcurrent = 0f;
        }
    }


    //patrol ____________________________________________________________________________________________________________________________________________________________________________________________________

    private void EnterPatrolState()
    {

    }

    private void UpdatePatrolState()
    {
        groundDetec = Physics.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetec = Physics.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsWall);

        if (!groundDetec || wallDetec)
        {
            //flip 
            Flip();



        }

        else
        {
            movement.Set(speedPatrol * facingDirec, enemyRB.velocity.y );
            enemyRB.velocity = movement;
            //move
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

    private void EnterDeadState()
    {

    }

    private void UpdateDeadState()
    {

    }

    private void ExitDeadState()
    {

    }
 

}
