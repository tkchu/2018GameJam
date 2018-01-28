using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballController : CharacterController {

	public GameObject Point;

	public override void Hit (Vector3 otherVec)
	{
		if (State == States.Normal && Wudi < 0.1f) {
            StartCoroutine(IE_Fighting(otherVec));
		}

	}

    IEnumerator IE_Fighting(Vector3 otherVec) {
        GameObject NewTarget = Instantiate(Point);
        Vector3 direction = otherVec - transform.position;
        NewTarget.transform.position = transform.position + direction.normalized * 20f;
        Move.SetTarget(NewTarget);

        AngryPerson.TriggerHit();
        yield return new WaitForSeconds(2f);
        State = States.Fight;
        AngryPerson.TriggerAngry();
        AngryPerson.TriggerFight();
        hitCircle.gameObject.SetActive(true);
    }
}
