using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // resource manager get
    public GameObject RM;
    ResourceManager rmScript;
    private float cowardiceAngle;

    // playercone get
    public GameObject PC;
    PlayerCone pcScript;

    private float aimAngleFloat;

    //shooty stuff
    private float shootAngleFloat;

    //bullet get
    public GameObject bulletPrefab;
    public Transform shootstart;

    // bullet properties
    public float bulletSpeed = 30;
    public float bulletLife = 1;



    void Start()
    {
        //get scripts
        rmScript = RM.GetComponent<ResourceManager>();
        pcScript = PC.GetComponent<PlayerCone>();
    }

    //lateupdate cause it's after the player update
    void LateUpdate()
    {

        // randomness
        cowardiceAngle = rmScript.cowardiceAngle;
        aimAngleFloat = pcScript.aimAngleFloat;
        shootAngleFloat = aimAngleFloat;
        shootAngleFloat += Random.Range(-cowardiceAngle, 0);
        
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
        //more randomness
        Quaternion randobullet = Random.rotation;
        randobullet.x = 0f;
        randobullet.y = 0f;
        bullet.transform.rotation = Quaternion.RotateTowards(bullet.transform.rotation,randobullet,shootAngleFloat);
        
        //actually shooting
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.up*bulletSpeed, ForceMode.Impulse);
        Debug.Log(bullet.transform.up);


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
