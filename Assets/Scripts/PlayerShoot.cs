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
    public float bulletLife = 3;



    void Start()
    {
        //get scripts
        rmScript = RM.GetComponent<ResourceManager>();
        pcScript = PC.GetComponent<PlayerCone>();
    }

    //lateupdate cause it's after the player update
    void LateUpdate()
    {
        // get shoot angle
        cowardiceAngle = rmScript.cowardiceAngle;
        aimAngleFloat = pcScript.aimAngleFloat;
        shootAngleFloat = aimAngleFloat;
        shootAngleFloat += Random.Range(-cowardiceAngle, 0);
    }

    //this gets called by player controller update
    public void Fire()
    {
      

        GameObject bullet = Instantiate(bulletPrefab);
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
            shootstart.parent.GetComponent<Collider>());

        bullet.transform.position = shootstart.position;
        //rotated correctly
        Vector3 rotation = bullet.transform.rotation.eulerAngles;
        bullet.transform.rotation = Quaternion.Euler(transform.eulerAngles.x,rotation.x,rotation.z);

        bullet.GetComponent<Rigidbody>().AddForce(shootstart.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet, bulletLife));
      



    }

    // bullet destroy after time
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);

             
    }


    
}
