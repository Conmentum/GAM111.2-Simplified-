﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Used for UI
    public GameObject phase_Panel;
    public Text phase_Text;
    public GameObject action_Panel;
    public GameObject targetSelect_Panel;
    public GameObject status_Panel;
    //Used to find the current state of TurnStates
    public TurnStates curState;
    //Used in PhaseStateHandler
    public string hero;
    public GameObject activeHero;
    public GameObject targetGameObject;
    //public List<PhaseStateHandeler> actionList = new List<PhaseStateHandler>();
    public List<GameObject> herosIn_Battle = new List<GameObject>();
    public List<GameObject> enemiesIn_Battle = new List<GameObject>();
	//Used for target selection from UI
	public GameObject curTarget;

    // Use this for initialization
    void Start()
    {
		curTarget = null;	
		SetStartingUI ();
    }
    private void Update()
    {
        PhaseStateHandler();
		Debug.Log (curTarget);
    }
    // Update is called once per frame
    void PhaseStateHandler()
    {
        phase_Text.text = curState.ToString();
        Debug.Log(curState);
        if (curState == TurnStates.Standby)
        {
            action_Panel.SetActive(false);
            targetSelect_Panel.SetActive(false);
            phase_Panel.SetActive(true);
            //Start event here for all characters to start their ActionCooldowns
            BaseHero[] heros = GameObject.FindObjectsOfType<BaseHero>();
            foreach(BaseHero hero in heros)
            {
                hero.GetComponent<BaseHero>().startCoolDown();
            }
            
        }
        if (curState == TurnStates.SelectingTarget)
        {
            phase_Text.text = "Select A Target";
            targetSelect_Panel.SetActive(true);
        }
        if (curState == TurnStates.SelectingActions)
        {
            targetSelect_Panel.SetActive(false);
            action_Panel.SetActive(true);
        }
        if (curState == TurnStates.FIGHT)
        {
            action_Panel.SetActive(false);
            phase_Panel.SetActive(true);
        }
        if (curState == TurnStates.End)
        {

        }
    }
    public enum TurnStates
    {
        Start,
        Standby,
        SelectingTarget,
        SelectingActions,
        FIGHT,
		EnemyTurn,	
        End,
    }

    public void StartTransition()
    {
        if (curState == TurnStates.Start)
        {
            curState = TurnStates.Standby;
        }
    }

	public void SetStartingUI()
	{
		//Int UI
		phase_Text.text = curState.ToString();
		curState = TurnStates.Start;
		status_Panel.SetActive(true);
		phase_Panel.SetActive(true);
		action_Panel.SetActive(false);
		targetSelect_Panel.SetActive(false);
		//Look for Objects
		enemiesIn_Battle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
		herosIn_Battle.AddRange(GameObject.FindGameObjectsWithTag("Hero"));

		//Used For TargetPanel

	}
	public void SelectEnemyTarget(){
		curTarget = FindObjectOfType<BaseEnemy> ().gameObject;
        curState = TurnStates.SelectingActions;
	}

	public void SelectHero1(){
		curTarget = GameObject.FindGameObjectWithTag("Hero1");
        curState = TurnStates.SelectingActions;
    }

	public void SelectHero2(){
		curTarget = GameObject.FindGameObjectWithTag ("Hero2");
        curState = TurnStates.SelectingActions;
    }

	public void SelectHero3(){
        curTarget = GameObject.FindGameObjectWithTag ("Hero3");
        curState = TurnStates.SelectingActions;
    }
}
