using UnityEngine;
using System.Collections;

public class ArrowArcs : MonoBehaviour {
    private GameObject cyl;
    public float X = 10;
    public float Y = 0;
    public float Z = 5;

	// Use this for initialization
	void Start () {
        int N = 101;
        float radius = Mathf.Sqrt((X * X) + (Z * Z)) / 2;
        //Debug.Log("radius=" + radius + " ");
        float rot_int = (Mathf.PI) / (N - 1);
        float x_int = X / (N - 1);// (Mathf.Max(X, Z) / 2) / (N - 1);
        //Debug.Log("xints " + x_int);
        float z_int = Y / (N - 1);
        //Debug.Log("zints=" + z_int + " ");

        for (int k = 0; k< N; k++)
        {
            cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
          
            float angle = Mathf.PI - (k * rot_int);
            //Debug.Log("angle: " + angle + " ");
            //float x = radius * Mathf.Cos(angle) + (X/2);
            float x = k * x_int;
            float z = k * z_int;
            float y = radius * Mathf.Sin(angle);
            //float z = Z;

            //Debug.Log("(x,y)=(" + x + "," + y + ")");
            cyl.transform.position = new Vector3(x,y,z);
            cyl.transform.localScale = new Vector3(.3f, .1f, .3f);

            float xRot = k * rot_int;
            float yRot = k * rot_int;
            float zRot = k * rot_int;
            cyl.transform.Rotate(0, 0, -zRot);

            //delay(1);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator delay(int sec) {
        Debug.Log("was here!!");
        yield return new WaitForSeconds(sec);        
    }
}
