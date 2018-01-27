using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    PlayerMovement playerMovement;
    Rigidbody2D rigidbody2D;
    public HitCircle hitCircle;
    public bool isFighting = false;
    public float speed = 1f;
    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        //是否在跑动
        float right = 0;
        float up = 0;
        if (Input.GetKey(KeyCode.A)) {
            right = -1;
        }else if (Input.GetKey(KeyCode.D)) {
            right = 1;
        }
        if (Input.GetKey(KeyCode.W)) {
            up = 1;
        }else if (Input.GetKey(KeyCode.S)) {
            up = -1;
        }
        playerMovement.SetRunnig(right != 0 || up != 0);
        rigidbody2D.velocity = new Vector2(right, up) * speed;

        //进行移动
        float facingRight = 0;
        float facingUp = 0;
        if (Input.GetKeyDown(KeyCode.A)) {
            facingRight = -1;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            facingRight = 1;
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            facingUp = 1;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            facingUp = -1;
        }
        if(facingRight != 0 || facingUp != 0) {
            playerMovement.SetFacing(facingRight, facingUp);
            Debug.Log(new Vector2(facingRight, facingUp));
        }

        //进行攻击
        isFighting = Input.GetKey(KeyCode.Space);
        hitCircle.gameObject.SetActive(isFighting);
    }
}
