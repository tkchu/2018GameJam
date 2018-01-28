using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIcon : MonoBehaviour {
    public Sprite[] sprites;
    SpriteRenderer render;

    private void Start() {
        render = GetComponent<SpriteRenderer>();
        StartCoroutine(ShowIcon());
    }
    IEnumerator ShowIcon() {
        int i = 0;
        while (true) {
            if (i >= sprites.Length) {
                i = 0;
            }
            render.sprite = sprites[i];
            i++;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
