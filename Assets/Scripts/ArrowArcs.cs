using UnityEngine;
using System.Collections;

public class ArrowArcs : MonoBehaviour
{
    private GameObject cyl;
    public float X = 10;
    public float Y = 0;
    public float Z = 5;

    private int N = 101;

    private int k = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float radius = Mathf.Sqrt((X * X) + (Z * Z)) / 2;

        float rot_int = (Mathf.PI) / (N - 1);
        float x_int = X / (N - 1);
        float z_int = Z / (N - 1);

        if (k < N)
        {
            cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

            float angle = Mathf.PI - (k * rot_int);
            float x = k * x_int;
            float z = k * z_int;
            float y = radius * Mathf.Sin(angle);
            cyl.transform.position = new Vector3(x, y, z);

            if (k < N - 5)
            {
                cyl.transform.localScale = new Vector3(.2f, .1f, .2f);
            }
            else  //make last five iters into the arrowhead
            {
                float cyl_width = (float)(N - k) / 10;
                cyl.transform.localScale = new Vector3(cyl_width, .1f, cyl_width);
            }

            float xRot = k * rot_int;
            float yRot = k * rot_int;
            float zRot = k * rot_int * (90 / Mathf.PI) * 2;
            cyl.transform.Rotate(0, 0, -zRot);

            k++;
        }
    }
}
