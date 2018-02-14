using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MovingObject {

	public float speed = 5f;

	private Animator animator;

	protected override void Start () {
		animator = GetComponent<Animator> ();

		base.Start ();
	}

	void Update () {
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");

		// Debug.Log("PMove: " + x + " :: " + y);

		base.Move (x, y, speed);
	}
}