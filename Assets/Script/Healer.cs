using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : BaseHero
{
    public Vector3 startPos;
    public bool action1;
    public bool action1_Used;
    public bool action2;
    public bool action2_Used;
    public bool activeObject;
    public HeroStateMechine heroStatesMechine;
    public GameManager GM;

    // Use this for initialization
    void Start()
    {
        startPos = this.transform.position;
        health = strength * armor;
        curHealth = health;
        action_Points = 100;
        curAction_Points = action_Points;
    }

    // Update is called once per frame
    void Update()
    {
        heroStatesMechine = GetComponent<HeroStateMechine>();
        if (heroStatesMechine.curHeroState == HeroStateMechine.HeroStates.SelectTarget)
        {
            activeObject = true;
        }
        Debug.Log(heroStatesMechine.curHeroState);
        nameIn_UI.text = hero_Name;
        HPtext.text = "HP: " + curHealth.ToString() + " / " + health.ToString();
        APtext.text = "AP: " + curAction_Points.ToString() + " / " + action_Points.ToString();
        FindTarget();
        if (heroStatesMechine.curHeroState == HeroStateMechine.HeroStates.PerformAction)
        {
            Action();
            ActionCoolDown();
        }
    }
    public void Action()
    {
        if (action1 == true)
        {
            heroStatesMechine.curHeroState = HeroStateMechine.HeroStates.PerformAction;
        }
        if (action2 == true)
        {
            heroStatesMechine.curHeroState = HeroStateMechine.HeroStates.PerformAction;
        }
        else
        {
            return;
        }
    }

    public void ActionCoolDown()
    {
        if (Max_actionCoolDown <= 0)
        {
            Max_actionCoolDown = 1f;
            ActionCooldown = Max_actionCoolDown;
            ActionCooldown -= Time.deltaTime;
            if (ActionCooldown <= 0)
            {
                CompletedAction();
                FindObjectOfType<GameManager>().curState = GameManager.TurnStates.Standby;
            }
        }
    }
    public void CompletedAction()
    {
        transform.position = startPos;
        action1 = false;
        action2 = false;
    }
}
