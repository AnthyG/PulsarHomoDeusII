using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    // public GameObject player;
    // public Player pScript;

    private int counter = 0;

    private CircleCollider2D circleCollider;
    private Animator animator;

    protected virtual void Start () {
        circleCollider = GetComponent<CircleCollider2D> ();
        animator = GetComponent<Animator> ();

        // pScript = player.GetComponent<Player> ();
    }

    protected virtual void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Player") {
            // Do Button-y Stuff
            Debug.Log ("Player pressed me! " + ++counter);

            // var lol = pScript.GetStoryQuestCounter();
            // Debug.Log (pScript + " :: " + lol);
            Player.StoryQuestCounter++;

            animator.SetTrigger ("pressed");
        }
    }
}