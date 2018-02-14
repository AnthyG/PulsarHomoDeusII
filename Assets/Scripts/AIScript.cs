using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIScript : MovingObject {

	public NeuralNet nn;

	public List<double> outputArr;
	public List<double> trainArr;
	public List<double> testArr;

	public float speed = 5f;

	private int xDir = 0;
	private int yDir = 0;

	private Animator animator;

	protected override void Start () {
		animator = GetComponent<Animator> ();

		// sig, inputs, outputs, hidden, neurons/hidden
		nn = new NeuralNet (false, 4, 4, 2, 8);
		Debug.Log ("NN >> " + nn);

		Debug.Log ("NN >> Weights " + nn.GetNumberofWeights ());

		// List<double> gweights = nn.GetWeights ();
		// Debug.Log ("NN >> gweights: " + gweights);

		// for (int i = 0; i < gweights.Count; i++) {
		// 	Debug.Log ("NN >> gweights >> " + i + " >> " + gweights[i]);
		// }

		base.Start ();

		// testArr = new List<double> ();
		// Debug.Log(testArr);
		// testArr.Add(3);
		// Debug.Log(testArr[0]);
	}

	void Update () {
		trainArr.Clear ();
		trainArr.Add (0.0);
		trainArr.Add (0.1);
		trainArr.Add (0.2);
		trainArr.Add (0.3);

		// Debug.Log ("NN >> trainArr: " + trainArr);

		// for (int i = 0; i < trainArr.Count; i++) {
		// Debug.Log ("NN >> trainArr >> " + i + " >> " + trainArr[i]);
		// }

		outputArr = nn.cycle (trainArr);
		// Debug.Log ("NN >> outputArr: " + outputArr);

		// for (int i = 0; i < outputArr.Count; i++) {
		// Debug.Log ("NN >> outputArr >> " + i + " >> " + outputArr[i]);
		// }

		float x = 0f;
		float y = 0f;

		if (outputArr[0] == 1) { // 0 w
			yDir = -1;
			y = -1f;
		}
		if (outputArr[1] == 1) { // 1 a
			xDir = -1;
			x = -1f;
		}
		if (outputArr[2] == 1) { // 2 s
			yDir = 1;
			y = 1f;
		}
		if (outputArr[3] == 1) { // 3 d
			xDir = 1;
			x = 1f;
		}

		// Debug.Log ("xDir: " + xDir + " :: " + "yDir: " + yDir);

		base.Move (x, y, speed);
	}
}