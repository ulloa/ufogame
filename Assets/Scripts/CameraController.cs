using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position; // transform.position will reference whatever object this is attached to
        // in this case it will use the maincamera transform position
        // player must be selected in unity script for the maincamera (drag and drop)
	}
	
	// Guarantees that all other updates have run before this happens
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
