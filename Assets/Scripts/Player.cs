using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MovingObject {

	public float speed = 5f;

	public Text StoryText;
	private int counter = 0;

	private float _elapsedTime = 0;
	private int StoryCounter;
	private int StoryQuestCounter = 0;
	private int StoryQuestLength;
	private List<string> StoryQuestTexts;
	private List<int> StoryQuestCounters;

	private CircleCollider2D circleCollider;
	private Rigidbody2D rb2D;
	private Animator animator;

	protected override void Start () {
		circleCollider = base.GetComponent<CircleCollider2D> ();
		rb2D = base.GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		StoryQuestTexts = new List<string> ();
		StoryQuestCounters = new List<int> ();

		StoryQuestCounters.Add(1);
		StoryQuestTexts.Add("Welcome.");
		StoryQuestCounters.Add(1);
		StoryQuestTexts.Add("Welcome..");
		StoryQuestCounters.Add(1);
		StoryQuestTexts.Add("Welcome...");
		StoryQuestCounters.Add(1);
		StoryQuestTexts.Add ("WELCOME TO THE GGAIWF!");
		StoryQuestCounters.Add(3);
		StoryQuestTexts.Add ("Today you will activate the AI");
		StoryQuestCounters.Add(3);
		StoryQuestTexts.Add("To do that, you'll need to activate multiple consoles!");
		StoryQuestCounters.Add(4);
		StoryQuestTexts.Add("They are now marked with a nice pink border <3");
		StoryQuestCounters.Add(4);

		StoryQuestLength = StoryQuestTexts.Count;

		Debug.Log (StoryQuestTexts + " :: " + StoryQuestLength + " :: " + StoryQuestTexts[0]);

		base.Start ();
	}

	protected virtual void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Button") {
			// Do Button-y Stuff
			// Debug.Log ("Pressed a button!");
			// StoryText.text = "Boop! " + ++counter;
		}
	}

	// public List[] Getter() {
	// 	List[] stuff = new List[2] ();
	// 	stuff.Add(StoryQuestCounter);
	// 	stuff.Add(StoryQuestLength);
	// 	return stuff;
	// }

	public int GetStoryQuestCounter() {
		return StoryQuestCounter;
	}

	void FixedUpdate () {
		if (StoryQuestCounter < StoryQuestLength) {
			if (_elapsedTime >= 1) {
				_elapsedTime = 0;

				if (StoryCounter >= StoryQuestCounters[StoryQuestCounter]) {
					string StoryQuestText = StoryQuestTexts[StoryQuestCounter] as string;
					Debug.Log ("FixedUpdate: " + StoryCounter + " :: " + StoryQuestCounter + " :: " + StoryQuestText);

					if (StoryQuestText.Length > 0)
						StoryText.text = StoryQuestText;
					
					StoryQuestCounter++;
					StoryCounter = 0;
				} else {
					StoryCounter++;
				}
			} else {
				_elapsedTime += Time.deltaTime;
			}
		}
	}

	void Update () {
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");

		// Debug.Log("PMove: " + x + " :: " + y);

		base.Move (x, y, speed);

		transform.up = -rb2D.velocity.normalized;
	}
}