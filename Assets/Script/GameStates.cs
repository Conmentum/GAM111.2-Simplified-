using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour {
    //maybe not needed
    public enum TurnStates
    {
        Start,
        Standby,
        SelectingTarget,
        SelectingActions,
        Battle,
        SurplusActions,
        End,
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
