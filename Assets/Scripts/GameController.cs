using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private GameObject[] Enemies;
	public int Score;
	void Start () {
		Enemies = GameObject.FindGameObjectsWithTag ("Character");
		Score = 0;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		int newScore = 0;
		foreach (GameObject enemy in Enemies) {
			if (enemy.GetComponent<CharacterController> ().State != States.Normal)
				newScore++;
		}

		Score = newScore;
		if (Score == Enemies.Length) {
			GameWin ();
		}
	}

	static public void GameWin()
	{
		Debug.Log ("Win");
	}
	static public void GameOver()
	{
		Debug.Log ("Game Over");
	}

}
