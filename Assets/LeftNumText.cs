using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftNumText : MonoBehaviour {
    public GameController gc;
    public Text text;
    private void Start() {
        text = GetComponent<Text>();
        text.text = "剩余 <color=yellow>" + (gc.Enemies.Length - gc.Score).ToString() + "</color>人没有生气";
    }
}
