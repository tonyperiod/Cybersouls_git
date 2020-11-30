using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
  //get components from other scripts
    public GameObject RM;
    ResourceManager rmScript;
    private float cowardiceAngle;
       
    public GameObject PC;
    PlayerCone pcScript;

    public GameObject PCT;
    PlayerController pctScript;
    private float aimAngleFloat;

    //shooty stuff
    // private float shootAngleFloat;

    //bullet get
    public GameObject bulletPrefab;
    public Transform shootstart;

    // bullet properties
    public float bulletSpeed = 30;
    public float bulletLife = 1;

    public float shootstepspeed = 1;

    void Start()
    {
        //get scripts
        rmScript = RM.GetComponent<ResourceManager>();
        pcScript = PC.GetComponent<PlayerCone>();
        pctScript = PCT.GetComponent<PlayerController>();
    }

    //lateupdate cause it's after the player update
    void LateUpdate()
    {

        // randomness
        cowardiceAngle = rmScript.cowardiceAngle;
        aimAngleFloat = pctScript.aimAngleFloat;
        //shootAngleFloat = aimAngleFloat;

    }

    //this gets called by player controller update
    public void Fire()
    {
        // prepping bullet
        GameObject bullet = Instantiate(bulletPrefab);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
            shootstart.parent.GetComponent<Collider>());
        
        bullet.transform.position = shootstart.position;
       

        //get rotations
        Vector3 rotation = bullet.transform.rotation.eulerAngles;
        rotation.x = 0f;
        rotation.y = 0f;
        rotation.z = 0f;
                       
     
        //randomness
        float randomShootAngle = Random.Range(-cowardiceAngle/2, +cowardiceAngle/2);        
        Vector3 randovec = new Vector3(0f, 0f, randomShootAngle+aimAngleFloat);
        print(randovec);
        print(aimAngleFloat + "aimangle");
        Quaternion randobullet = Quaternion.Euler(randovec);
          
       bullet.transform.rotation = Quaternion.RotateTowards(bullet.transform.rotation,randobullet, 360f);
                
        //actually shooting, have to base on aim direction
        

       bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.right*bulletSpeed, ForceMode.Impulse);
            
    

        //bullet die
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletLife));
      



    }

    // bullet destroy after time
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);

             
    }


    
}
