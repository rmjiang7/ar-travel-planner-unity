using UnityEngine;
using System.Collections;

public class SphereCollision : MonoBehaviour {

    public float time = 0;
    public float X = 5;
    public float Y = 0;
    public float Z = 0;

	// Use this for initialization
	void Start () {
        //transform.position = new Vector3(0, 0, 1);
        Z = transform.position.z;                
	}
	
	// Update is called once per frame
	void Update () {

        float t = updateTime();
        t = t % (X+1);
        float s = -(2/X) * ((t - X / 2) * (t - X / 2)) + (X / 2);

        transform.position = new Vector3(t, s, Z);

    }

    float trackTime()
    {
        return time;
    }

    float updateTime()
    {
        time += (float).1;
        return time;
    }

}
