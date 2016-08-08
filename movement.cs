using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

    float health;   
    float maxspeed;
    float rotspeed;
    public string team;
    string shipClass;
    public GameObject target;

	// Use this for initialization
	void Start () {
        health = 1000;
        maxspeed = 40;
        rotspeed = 160;
        team = "friend";
        shipClass = "frigate";
    }

    // Update is called once per frame
    void Update()
    {
        //everything a functional ship can do goes in here
        Vector3 pos = transform.position;                                                               // Grabs the ship position

        //ROTATE the ship
        Quaternion rot = transform.rotation;                                                            // Grabs the rotation quaternion
        float z = rot.eulerAngles.z;                                                                    // Gets the Euler angle
        z -= Input.GetAxis("Horizontal") * rotspeed * Time.deltaTime;                                   // Changes the z angle based on input
        rot = Quaternion.Euler(0, 0, z);                                                                // Recreates the quaternion
        transform.rotation = rot;                                                                       // Feeds the Quaternion into our position

        // MOVE the ship
        Vector3 velocity = new Vector3(Input.GetAxis("Vertical") * maxspeed * Time.deltaTime, 0, 0);    // Gets the velocity
        pos += rot * velocity;                                                                          // Changes position based on rotation and velcity
        transform.position = pos;                                                                       // Updates the object position to where it should be
    }
}
