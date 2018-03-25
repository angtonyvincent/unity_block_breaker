using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float minX, maxX;
	public float currentX = 8.0f;

	private Ball ball;
	
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
		
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			Move();			
			//MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}
	
	void Move() {
		float touchPosInBlocks = Input.GetTouch(0).position.x / Screen.width * 16;
		if (currentX > touchPosInBlocks) {
			currentX = Mathf.Clamp (currentX - 0.25f, minX, maxX);
		}
		else if (currentX < touchPosInBlocks) {
			currentX = Mathf.Clamp (currentX + 0.25f, minX, maxX);
		}
		Vector3 paddlePos = new Vector3 (currentX, this.transform.position.y, 0f);
		this.transform.position = paddlePos;
	}

	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}
}
