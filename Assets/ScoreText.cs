using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    public GameController gc;
    Text text;

    private void Start() {
        text = GetComponent<Text>();
    }

    public void Update() {
        text.text = "剩余：" + (gc.Enemies.Length - gc.Score).ToString() ;
    }
}
