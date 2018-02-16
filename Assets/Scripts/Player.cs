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
	public static int StoryQuestCounter = 0;
	public static List<int> StoryQuestLengths;
	private List<string> StoryQuestTexts;
	private List<int> StoryQuestCounters;
	public static int StoryQuestLengthI = 0;

	private CircleCollider2D circleCollider;
	private Rigidbody2D rb2D;
	private Animator animator;

	protected override void Start () {
		circleCollider = base.GetComponent<CircleCollider2D> ();
		rb2D = base.GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		StoryQuestTexts = new List<string> ();
		StoryQuestCounters = new List<int> ();
		StoryQuestLengths = new List<int> ();

		StoryQuestCounters.Add (1);
		StoryQuestTexts.Add ("Welcome.");
		StoryQuestCounters.Add (1);
		StoryQuestTexts.Add ("Welcome..");
		StoryQuestCounters.Add (1);
		StoryQuestTexts.Add ("Welcome...");
		StoryQuestCounters.Add (1);
		StoryQuestTexts.Add ("WELCOME TO THE GGAIWF!");
		StoryQuestCounters.Add (3);
		StoryQuestTexts.Add ("Your job today is to activate the AI!");
		StoryQuestCounters.Add (3);
		StoryQuestTexts.Add ("To do that, you'll need to activate multiple data collectors first..");
		StoryQuestCounters.Add (4);
		StoryQuestTexts.Add ("..Data collectors enable the transmission of..");
		StoryQuestCounters.Add (3);
		StoryQuestTexts.Add("..data from satellites to the AI.");
		StoryQuestCounters.Add (3);
		StoryQuestTexts.Add ("I'll mark them with a nice pink border <3");
		StoryQuestCounters.Add (4);
		StoryQuestTexts.Add ("LOL, because I'm too incompetent to know ...");
		StoryQuestCounters.Add (4);
		StoryQuestTexts.Add ("... if you activated the only console in this game..");
		StoryQuestCounters.Add (4);
		StoryQuestTexts.Add (".. I'll just assume, you did that");
		StoryQuestCounters.Add (3);
		StoryQuestTexts.Add ("After all, this is just a demo of a demo");
		StoryQuestCounters.Add (3);
		StoryQuestTexts.Add ("And the AI was already (graphically) activated, sooo....");
		StoryQuestCounters.Add (3);
		StoryQuestTexts.Add ("[G]ood [G]rass!! ;)");
		StoryQuestCounters.Add (3);

		StoryQuestLengths.Add (StoryQuestTexts.Count);

		StoryQuestTexts.Add ("Nice, you activated the console!");
		StoryQuestCounters.Add (2);

		StoryQuestLengths.Add (1);

		Debug.Log (StoryQuestTexts + " :: " + StoryQuestLengths[0] + " :: " + StoryQuestTexts[0]);

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

	public int GetStoryQuestCounter () {
		return StoryQuestCounter;
	}

	void FixedUpdate () {
		Debug.Log ("test >> " + StoryQuestLengths[StoryQuestLengthI]);
		if (StoryQuestCounter < StoryQuestLengths[StoryQuestLengthI]) {
			if (_elapsedTime >= 1) {
				_elapsedTime = 0;

				if (StoryCounter >= StoryQuestCounters[StoryQuestCounter]) {
					Debug.Log ("FixedUpdate: " + StoryCounter + " :: " + StoryQuestCounter);

					StoryQuestCounter++;
					StoryCounter = 0;
				} else {
					StoryCounter++;
				}
			} else {
				_elapsedTime += Time.deltaTime;
			}
		}
		if (StoryQuestCounter == StoryQuestLengths[StoryQuestLengthI])
			StoryQuestLengthI++;
	}

	void Update () {
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");

		string StoryQuestText = "";
		if (StoryQuestTexts.Count > StoryQuestCounter)
			StoryQuestText = StoryQuestTexts[StoryQuestCounter] as string;

		if (StoryQuestText.Length > 0)
			StoryText.text = StoryQuestText;

		// Debug.Log("PMove: " + x + " :: " + y);

		base.Move (x, y, speed);

		transform.up = -rb2D.velocity.normalized;
	}
}