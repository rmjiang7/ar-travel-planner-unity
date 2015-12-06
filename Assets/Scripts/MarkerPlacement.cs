using UnityEngine;
using System.Collections;

public class MarkerPlacement : MonoBehaviour {
    private float radius_max = 5;
    private float radius = 0;
    private float rad_incr;
    private float angle = 0;
    private float angle_incr;
    private float height = 4;
    private float height_incr;
    private int num_iter = 50;

    public float X = 0;
    public float Z = 0;

    private GameObject sphere;

    // Use this for initialization
    void Start () {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        rad_incr = radius_max / (num_iter / 2);
        angle_incr = (2*Mathf.PI) / (num_iter/2);
        height_incr = height / num_iter;
        
    }
	
	// Update is called once per frame
	void Update () {
        if(height >= 0)
            updateParams();

        float x = radius*Mathf.Cos(angle) + X;
        float y = height;
        float z = radius * Mathf.Sin(angle) + Z;
        //transform.position = new Vector3(x, y, z);
        sphere.transform.position = new Vector3(x, y, z);
	}

    void updateParams() {
        if (angle < Mathf.PI * 2)
            radius += rad_incr;
        else
            radius -= rad_incr;
        angle += angle_incr;
        height -= height_incr;
    }
}
