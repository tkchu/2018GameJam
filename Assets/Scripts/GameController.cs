using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject[] Enemies;
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

    public GameObject overResult;
    public void ShowOverResult() {
        FindObjectOfType<PlayerControl>().enabled = false;
        overResult.SetActive(true);
    }

    public GameObject winResult;
    public void ShowWinResult() {
        FindObjectOfType<PlayerControl>().enabled = false;
        winResult.SetActive(true);
    }
    static public void GameWin()
	{
        FindObjectOfType<GameController>().ShowWinResult();
    }
    static public void GameOver()
	{
        FindObjectOfType<GameController>().ShowOverResult();
	}

}
