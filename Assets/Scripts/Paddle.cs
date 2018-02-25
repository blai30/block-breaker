using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public float minX, maxX;
	public bool autoPlay = false;
	private Ball ball;

	    // Use this for initialization
    void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update() {
		if (!autoPlay) {
        	MoveWithMouse();
		} else {
			AutoPlay();
		}

		if (Input.GetKeyDown(KeyCode.A)) {
			if (autoPlay) {
				autoPlay = false;
			} else if (!autoPlay) {
				autoPlay = true;
			}
		}
	}

	void MoveWithMouse() {
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, this.transform.position.z);

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}

	void AutoPlay() {
		Vector3 ballPos = ball.transform.position;
        Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, this.transform.position.z);

        paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}

}
