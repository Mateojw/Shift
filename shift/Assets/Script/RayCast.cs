using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {
	public GameObject projectile;
	public float range;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray landingRay = new Ray (transform.position, Camera.main.transform.forward);
		if (Physics.Raycast (landingRay, out hit, range)) {
			if (hit.transform.tag == "enemy") {
        Debug.Log ("hit");
        Destroy (hit.transform.gameObject);
			}

			Debug.DrawLine (transform.position, hit.point);
		}
	}
}
