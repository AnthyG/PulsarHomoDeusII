using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public GameObject player;
	public int distance = -10;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		if (player != null) {
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, distance);
		}
	}
}