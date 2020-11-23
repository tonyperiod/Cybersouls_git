using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCone : MonoBehaviour
{


   
   
    public int rayCount = 30;    
    public float shotDistance = 5;
    private Vector3 origin = Vector3.zero;   
    private Mesh mesh;

    //connect to resource manager
    public GameObject RM;
    ResourceManager rmScript;
    private float cowardiceAngle;

    //connect to shoulder
    public GameObject playerControllerObject;
    PlayerController pcscript;
    private float aimAngleFloat;
  
    public void Start()
    {
        // creation of range mesh
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        rmScript = RM.GetComponent<ResourceManager>();
        pcscript= playerControllerObject.GetComponent<PlayerController>();

        
        
        

    }

    public void LateUpdate()
    {
        //get cowardice angle 
        cowardiceAngle = rmScript.cowardiceAngle;

        //get aimAngleFloat
        aimAngleFloat = pcscript.aimAngleFloat;              

        // define the angle
        float angleIncrease = cowardiceAngle / rayCount;
        float angle = aimAngleFloat;

        //nono touch, this is to make the field of view with modifiable angle
        Vector3[] vertices = new Vector3[rayCount +1 +1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];
              
        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
           
            vertex = origin + GetVectorFromAngle(angle) * shotDistance;
            //generate actual mesh
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
            
            
        }
            
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        



    }

   
    //convert angle into vector 3
    public static Vector3 GetVectorFromAngle (float anglecurrent)
    {
        float angleRad = anglecurrent * (Mathf.PI / 180);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        
    }


   
 
    /**
    // Parts that will be passed around in other scripts
    public void SetAimDirection(Vector2 aimAngleVector)
    {
        aimAngleFloat = GetAngleFromVectorFloat(aimAngleVector) + cowardiceAngle/2;
       // Debug.Log(aimAngleFloat + "aim angle");
    }
   **/
}