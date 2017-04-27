using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStateMechine : MonoBehaviour {

    //for the action bar.
    public float curAction_CD;
    public float sAction_CD;
    public float maxAction_CD;
    public Image actionBar;
    public bool StartCooldown;
    public bool activeObject;
    public HeroStateMechine[] Cooldowns;

    public enum HeroStates
    {
        Waiting,
        SelectTarget,
        SelectAction,
        PerformAction,
        ActionComplete,
        TakeDamage,
        Dead
    }
    public HeroStates curHeroState;

    public void Start()
    {
        sAction_CD = curAction_CD;
        maxAction_CD = GetComponent<BaseHero>().speed;
        curHeroState = HeroStates.Waiting;
        StartCooldown = false;
    }

    // Use this for initialization
    public void Update () {
        if (curAction_CD >= maxAction_CD)
        {
            activeObject = false;
        }
        Debug.Log(curHeroState);
        switch (curHeroState)
        {
            case (HeroStates.Waiting):
                ActionBar();
                activeObject = false;
                break;
            case (HeroStates.SelectAction):
                break;
            case (HeroStates.PerformAction):
                FindObjectOfType<GameManager>().curState = GameManager.TurnStates.FIGHT;
                break;
            case (HeroStates.ActionComplete):
                ReturnToWaiting();
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
            curAction_CD = curAction_CD + Time.deltaTime * 3;
            float calculateCooldown = curAction_CD / maxAction_CD;
            actionBar.transform.localScale = new Vector3(Mathf.Clamp(calculateCooldown, 0, 1), actionBar.transform.localScale.y, actionBar.transform.localScale.z);
            if (curAction_CD >= maxAction_CD)
            {
                CoolDownCompleted();
                curHeroState = HeroStates.SelectTarget;
            }
        }
    }
    public void CoolDownCompleted()
    {
        
        curAction_CD = sAction_CD;
        activeObject = true;
        curHeroState = HeroStates.SelectAction;
        Cooldowns = GameObject.FindObjectsOfType<HeroStateMechine>();
        foreach (HeroStateMechine coolDown in Cooldowns)
        {
            coolDown.StartCooldown = false;
        }
        GameObject.FindObjectOfType<GameManager>().curState = GameManager.TurnStates.SelectingTarget;
    }

    public void ReturnToWaiting()
    {
        float calcTime = 1f;
        calcTime -= Time.deltaTime;
        if (calcTime <= 0f)
        {
            foreach (HeroStateMechine cooldownRe in Cooldowns)
            {
                cooldownRe.StartCooldown = true;
            }
            curHeroState = HeroStates.Waiting;
        }

    }
}
