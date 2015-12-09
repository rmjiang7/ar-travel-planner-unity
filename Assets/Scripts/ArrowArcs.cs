using UnityEngine;
using System.Collections;

public class ArrowArcs : MonoBehaviour
{
    private GameObject arcs;

    private GameObject cyl;
    public float X = 10;
    public float Z = 5;
    public float X_start = 0;
    public float Z_start = 0;
    public bool solidLine = true;

    private int N = 101;
    private int max = 0;

    private int k = 0;

    // Use this for initialization
    void Start()
    {
        arcs = new GameObject();
        max = N;
    }

    // Update is called once per frame
    void Update()
    {
        float radius = Mathf.Sqrt(Mathf.Pow(X - X_start, 2) + Mathf.Pow(Z - Z_start, 2)) / 2;

        float rot_int = (Mathf.PI) / (N - 1);
        float x_int = (X - X_start) / (N - 1);
        float z_int = (Z - Z_start) / (N - 1);

        if (k < max)
        {
            cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cyl.transform.parent = arcs.transform;

            float angle = Mathf.PI - (k * rot_int);
            float x = X_start + k * x_int;
            float z = Z_start + k * z_int;
            float y = radius * Mathf.Sin(angle);
            cyl.transform.position = new Vector3(x, y, z);

            if (k < N - 5)
            {
                if (solidLine == true)
                    cyl.transform.localScale = new Vector3(10f, 5f, 10f);
                else
                    cyl.transform.localScale = new Vector3(10f, .1f, 10f);
            }
            else  //make last five iters into the arrowhead
            {
                float cyl_width = (float)(N - k) / 10 * 100;
                if (solidLine == true)
                    cyl.transform.localScale = new Vector3(cyl_width, 5f, cyl_width);
                else
                    cyl.transform.localScale = new Vector3(cyl_width, .1f, cyl_width);
            }

            float xRot = k * rot_int;
            float yRot = k * rot_int;
            float zRot = k * rot_int * (90 / Mathf.PI) * 2;
            cyl.transform.Rotate(0, 0, -zRot);

            k++;
        }

    }

    public void destroyArc()
    {
        Destroy(arcs);
    }
}
