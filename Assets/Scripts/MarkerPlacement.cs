using UnityEngine;
using System.Collections;

public class MarkerPlacement : MonoBehaviour
{
    private float radius_max = 400.0f;
    private float radius = 0;
    private float rad_incr;
    private float angle_tot = 3 * Mathf.PI;
    private float angle = 0;
    private float angle_incr;
    private float height = 600.0f;
    private float height_incr;
    private int num_iter = 50;

    public float X = 0;
    public float Z = 0;
	
	public Mesh selectedMesh;
	public Material selectedMeshMaterial;

    // Use this for initialization
    void Start()
    {
        rad_incr = radius_max / (num_iter / 2);
        angle_incr = angle_tot / num_iter;
        height_incr = height / num_iter;
		ChangeMeshRenderer ();
    }

    // Update is called once per frame
    void Update()
    {
        if (height >= 0)
            updateParams();

        float x = radius * Mathf.Cos(angle) + X;
        float y = height;
        float z = radius * Mathf.Sin(angle) + Z;
        transform.position = new Vector3(x, y, z);
    }

    void updateParams()
    {
        if (angle < angle_tot / 2)
            radius += rad_incr;
        else
            radius -= rad_incr;
        angle += angle_incr;
        height -= height_incr;
    }

	void ChangeMeshRenderer() {
		GetComponent<MeshFilter> ().mesh = selectedMesh;
		GetComponent<MeshRenderer> ().materials = new Material[]{selectedMeshMaterial};
	}

}
