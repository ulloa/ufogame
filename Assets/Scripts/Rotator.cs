using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime); // As far as I can tell, rotations should be done always on Z axis because you can't rotate a 2d game through x or y. It iwll just scale down and up

	}
}
