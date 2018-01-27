using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Facing {
    down,
    left,
    up,
    right,
}

public class AngryablePerson : MonoBehaviour {
    public bool isAngry = false;
    public Facing facing = Facing.down;
}
