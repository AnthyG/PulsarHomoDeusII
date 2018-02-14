using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour {

	public LayerMask blockingLayer;

	private CircleCollider2D circleCollider;
	private Rigidbody2D rb2D;

	protected virtual void Start () {
		circleCollider = GetComponent<CircleCollider2D> ();
		rb2D = GetComponent<Rigidbody2D> ();
	}

	protected virtual void Move (float x, float y, float speed) {
		rb2D.velocity = new Vector2 (x * speed, y * speed);
	}
}