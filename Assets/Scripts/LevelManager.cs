using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void Login() {
		Debug.Log ("Navigate to Login Scene");
		Application.LoadLevel ("Login Scene");
	}

	public void ShowFriends() {
		Debug.Log ("Navigate to Friends Scene");
		Application.LoadLevel ("Friends Scene");
	}

	public void ShowLeaderboard() {
		Debug.Log ("Navigate to Leaderboard Scene");
		Application.LoadLevel ("Leaderboard Scene");
	}

	public void LoadLevel(string name) {
		Debug.Log ("New Level load: " + name);
		Brick.breakableCount = 0;
		Application.LoadLevel (name);
	}

	public void QuitRequest() {
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestoyed() {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel();
		}
	}
}
