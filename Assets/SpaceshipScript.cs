using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour {
    [Range(-720f, 720f)]
    public float turnRate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, 5f * Time.deltaTime, 0f, Space.Self);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, turnRate * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -turnRate * Time.deltaTime);
        }
		
	}
}
