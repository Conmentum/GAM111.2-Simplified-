using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMechine : MonoBehaviour {

    private GameManager gameManager;
    public BaseEnemy enemy;
    public float actionCooldown;

    public enum EnemyTurnState
    {
        Waiting,
        SelectingAction,
        TakingDamage,
        dead

    }
	public EnemyTurnState eTurnState;

	// Use this for initialization
	void Start () {
        actionCooldown = 15f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TimeTillAction()
    {

        actionCooldown -= Time.deltaTime;
    }
}
