using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    Camera cam;
    public AudioClip bounce;
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;

    // Use this for initialization
    void Start() {
        this.cam = Camera.main;
        paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
        print(paddleToBallVector.y);
	}
	
	// Update is called once per frame
	void Update() {
		if (!hasStarted) {
            // Lock the ball relative to the paddle.
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for a mouse press to launch.
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("Mouse clicked, launch ball");
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 10f);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision) {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted) {
            AudioSource.PlayClipAtPoint(bounce, this.cam.transform.position);
            this.GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }

}
