using UnityEngine;
using System.Collections;

public class Vacuum : MonoBehaviour
{
	private GameObject parent;
    public float X = 10;
    public float Y = 0;
    public float Z = 5;

    private int N = 101;
    private int max;
	private int k=0;

    // Use this for initialization
    void Start()
    {
        max = N;
		parent = new GameObject ("Vacuum");
    }

    // Update is called once per frame
    void Update()
    {
        float radius = Mathf.Sqrt((X * X) + (Z * Z)) / 2;

        float rot_int = (Mathf.PI) / (N - 1);
        float x_int = X / (N - 1);
        float z_int = Z / (N - 1);

		if (k < max) {
			float x = (k * x_int);
			float z = (k * z_int);
			float angle = (k * rot_int);
			float y = radius * Mathf.Sin (angle);

			GameObject cyl = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
			cyl.transform.SetParent(parent.transform);
			cyl.transform.position = new Vector3 (x, y, z);
			cyl.GetComponent<Renderer>().material.color = Color.black;
			float cyl_width = k / 0.25f;
                
			cyl.transform.localScale = new Vector3 (cyl_width, .1f, cyl_width);

			float xRot = k * rot_int;
			float yRot = k * rot_int;
			float zRot = k * rot_int * (90 / Mathf.PI) * 2;
			cyl.transform.Rotate (0, 0, -zRot);
		}
		k++;

		if (k == max+10) {
			Destroy (parent);
			Destroy (this);
		}
    }
}
