using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MoveController {

	public GameObject PosA, PosB;



	void Update()
	{
		base.SetTarget (PosA);
	}
}
