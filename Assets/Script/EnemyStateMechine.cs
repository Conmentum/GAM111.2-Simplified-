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
        Waiting2,
        SelectingAction

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
