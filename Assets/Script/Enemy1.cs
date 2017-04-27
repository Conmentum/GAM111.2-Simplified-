using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : BaseEnemy {

	// Use this for initialization
	void Start () {
        health = strength * armor;
        startingPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<EnemyStateMechine>().eTurnState == EnemyStateMechine.EnemyTurnState.TakingDamage)
        {
            this.transform.position = startingPos;
            float calcTime = 1;
            calcTime -= Time.deltaTime;
            if (calcTime <= 1)
            {
                GetComponent<EnemyStateMechine>().eTurnState = EnemyStateMechine.EnemyTurnState.Waiting;
            }
        }
	}
}
