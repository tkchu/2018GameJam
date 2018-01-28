using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	// Use this for initialization
	public void Start () {
        StartCoroutine(Next());
	}
	
	public IEnumerator Next() {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("level");
    }
}
