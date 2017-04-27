using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMechine : MonoBehaviour {

    private GameManager gameManager;
    public BaseEnemy enemy;

    public enum EnemyTurnState
    {
        Processing,
        AddToList,
        Waiting,
        SelectingAction

    }
	public EnemyTurnState eTurnState;

	// Use this for initialization
	void Start () {
		eTurnState = EnemyTurnState.Processing;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
