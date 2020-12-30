using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //flipping enemy
    private int facingDirec = 1; //this parameter is used for all enemy movement direction, so that state switching happens seamlessly
   

    //enemy get stuff
    public GameObject enemy;
    private Rigidbody enemyRB;

    //get other stuff
    private PlayerController pc;

    [Header("enemy characteristics")]
    [SerializeField]
    private float
        speedPatrol = 5,
        speedChase = 10;
    public float waitTime;
    private Vector2 movement;
    //hp stuff

    //[SerializeField]
    //private float HPmax;
    //private float HPcurrent;

    //chase stuff  
    private bool isThereWall = false;  //I NEED TO USE THESE
    private bool isThereGround = true;  //I NEED TO USE THESE

    private bool iAmCalm = true;

    //create state machine
    private enum State
    {
        patrol,
        chase, //maybe put some climbing in if they are chasing you
        attack,
        dead

    }    
    private State currentState;

    //detection
    [SerializeField]
    private float detecRange;

    [SerializeField]
   public  Transform player;

    private float currentTime = 0;


    //start

    void Start()
    {

        //get components


        enemyRB =enemy.GetComponent<Rigidbody>();
       

        pc = GameObject.Find("Player").GetComponent<PlayerController>();



        //HPcurrent = HPmax;


        currentState = State.patrol;
    }


    

 
    //update what state is active
    void Update() 
    {
        // player detection____________________________________________________________________________________________________________________________________________________________________________________________________
        //mix the raycast with a distance function, so that once enemy sees player in front, then will chase until player far enough
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        EnemyRays(detecRange);


        //player is in attack range, the enemy is attacking
        if (EnemyRays(detecRange))
        {
            iAmCalm = false;
            PlayerSeen();
         
        }

        //enemy is weary of player, but will not continue chasing much longer. no longer using the raycast to chase player. enemy only notices is run in front
        if (distToPlayer> detecRange && iAmCalm == false)

        {         
         PlayerEscape();         
        }

        //calm patrolling of enemy
        if (distToPlayer>detecRange && iAmCalm == true)
        {
            facingDirec *= -1; //enemy turns away from player so that doesn't seem like it's still chasing
            currentState = State.patrol;
        }


        //state machine update____________________________________________________________________________________________________________________________________________________________________________________________________
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




    //inter-script functions ____________________________________________________________________________________________________________________________________________________________________________________________________

    // patrol functions
    private void Flip()
    {
        facingDirec *= -1;

    }


    //chase funcions
    private void WallHit()    
    {       
        isThereWall = true;
    }
    private void WallOut()
    {       
        isThereWall = false;
    }


    private void GroundEnd()
    {
        // this is only for chase
        isThereGround = false;
    }
    private void GroundStart()
    {
        // this is only for chase
        isThereGround = true;
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

    //player detection ____________________________________________________________________________________________________________________________________________________________________________________________________
    //float distPlayer = Vector2.Distance(Transform.position, player.position);

    //extra functions ____________________________________________________________________________________________________________________________________________________________________________________________________

    bool EnemyRays(float distance)
    {
        bool val = false;
        float castDist = distance;        
        Vector3 EndPos = transform.position + new Vector3(1,1,1)* distance * facingDirec; // placed the 111 vector for simplicity, as you cannot add a vector and a float
        
        LayerMask mask = LayerMask.GetMask("damagable");



        if (Physics.Raycast(transform.position, new Vector3(1, 0, 0), distance, mask))
            val = true;
        else
            val = false;

        return val;
    }
    
    
    
    private void PlayerSeen()
    {
        Debug.Log("i see enemy");
        SwitchState(State.chase);

    }
    private void PlayerEscape()
    {
       
        Debug.Log("enemy gone");
        //This function allows me to have a certain modifiable amount of time where enemy chases even without eyesight
        if (Time.time > currentTime)
        {
            if (Time.time > waitTime + currentTime)
            {
                Debug.Log("calm is mine");
                SwitchState(State.patrol);
                currentTime = Time.time;
                iAmCalm = true;
                Debug.Log("i managed to calm down");
            }
        }
        else
        {
            Debug.Log("i chase escapee");
            currentState = State.chase;
           
        }
    }

    //patrol ____________________________________________________________________________________________________________________________________________________________________________________________________


    private void EnterPatrolState()
    {
        
    }

    private void UpdatePatrolState()
    {    
        Vector3 moving = new Vector3 (speedPatrol * facingDirec, 0f, 0f);
        enemyRB.MovePosition(transform.position+moving*Time.fixedDeltaTime); 

    }

    private void ExitPatrolState()
    {

    }



    //chase ____________________________________________________________________________________________________________________________________________________________________________________________________


    private void EnterChaseState()
    {
        //here i put functions I'll need in chase state
    
    }

    private void UpdateChaseState()
    {
        //find player relative position
        Vector3 playerEnemyVector = player.position - transform.position;
        //using relativec position between player and enemy, can get facing direction.
        if (playerEnemyVector.x > 0)
            facingDirec = 1;
        else
            facingDirec = -1;

        //move enemy

        Vector3 moving = new Vector3(speedChase * facingDirec, 0f, 0f);
        enemyRB.MovePosition(transform.position + moving * Time.fixedDeltaTime);


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
