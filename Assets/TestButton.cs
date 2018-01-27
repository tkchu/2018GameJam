using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour {
    public AngryablePerson person;
    int fac = 0;
    public void SetFacing() {
        if(fac==0)
            person.SetFacing(Facing.down);

        if (fac == 1)
            person.SetFacing(Facing.up);

        if (fac == 2)
            person.SetFacing(Facing.left);

        if (fac == 3)
            person.SetFacing(Facing.right);
        fac += 1;
        if(fac >= 4) {
            fac = 0;
        }
    }
}
