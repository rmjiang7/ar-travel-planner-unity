using UnityEngine;
using System.Collections;

public class Vacuum : MonoBehaviour
{
    private GameObject cyl;
    public float X = 10;
    public float Y = 0;
    public float Z = 5;

    private int N = 101;
    private int max;

    // Use this for initialization
    void Start()
    {
        max = N;
    }

    // Update is called once per frame
    void Update()
    {
        float radius = Mathf.Sqrt((X * X) + (Z * Z)) / 2;

        float rot_int = (Mathf.PI) / (N - 1);
        float x_int = X / (N - 1);
        float z_int = Z / (N - 1);

        if (max != 0 && max <= N)
            max--;

        for (int k = N; k > max; k--)
        {
            float x = X - (k * x_int);
            float z = Z - (k * z_int);
            float angle = Mathf.PI - (k * rot_int);
            float y = radius * Mathf.Sin(angle);

            cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cyl.transform.position = new Vector3(x, y, z);
            float cyl_width = (float)(N - k) / 20;
                
            cyl.transform.localScale = new Vector3(cyl_width, .1f, cyl_width);

            float xRot = k * rot_int;
            float yRot = k * rot_int;
            float zRot = k * rot_int * (90 / Mathf.PI) * 2;
            cyl.transform.Rotate(0, 0, zRot);
        }
    }
}
