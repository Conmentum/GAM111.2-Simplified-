using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStateMechine : MonoBehaviour {

    //for the action bar.
    public float curAction_CD;
    public float maxAction_CD;
    public Image actionBar;
    public bool StartCooldown;

    public enum HeroStates
    {
        Waiting,
        SelectAction,
        PerformAction,
        TakeDamage,
        Dead
    }
    public HeroStates curHeroState;

    public void Start()
    {
        maxAction_CD = GetComponent<BaseHero>().speed;
        curHeroState = HeroStates.Waiting;
        StartCooldown = false;
    }

    // Use this for initialization
    public void Update () {
        Debug.Log(curHeroState);
        switch (curHeroState)
        {
            case (HeroStates.Waiting):
                ActionBar();
                break;
            case (HeroStates.SelectAction):
                //stop other cooldowns
                break;
            case (HeroStates.PerformAction):
                Time.timeScale = 1;
                break;
            case (HeroStates.TakeDamage):
                break;
            case (HeroStates.Dead):
                break;
        }
	}

    public void ActionBar()
    {
        if (StartCooldown == true)
        {
            Debug.Log("Well it got here");
            curAction_CD = curAction_CD + Time.deltaTime * 3;
            float calculateCooldown = curAction_CD / maxAction_CD;
            actionBar.transform.localScale = new Vector3(Mathf.Clamp(calculateCooldown, 0, 1), actionBar.transform.localScale.y, actionBar.transform.localScale.z);
            if (curAction_CD >= maxAction_CD)
            {
                Debug.Log("And this worked");
                CoolDownCompleted();
            }
        }
    }
    public void CoolDownCompleted()
    {
        StartCooldown = false;
        HeroStateMechine[] Cooldowns = GameObject.FindObjectsOfType<HeroStateMechine>();
        foreach(HeroStateMechine coolDown in Cooldowns)
        {
            coolDown.StartCooldown = false;
        }
        curHeroState = HeroStates.SelectAction;
        GameObject.FindObjectOfType<GameManager>().curState = GameManager.TurnStates.SelectingTarget;
    }
}
