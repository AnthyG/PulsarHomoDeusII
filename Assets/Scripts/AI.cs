using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

	private CircleCollider2D circleCollider;
	private Animator animator;

	void Start () {
		circleCollider = base.GetComponent<CircleCollider2D> ();
		animator = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		if (Player.StoryQuestCounter >= Player.StoryQuestLengths[0]) {
			int oldInt = animator.GetInteger ("state");
			animator.SetInteger ("state", oldInt + 1);
		}
	}

	void Update () {

	}
}