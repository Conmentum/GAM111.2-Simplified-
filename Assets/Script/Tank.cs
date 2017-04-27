using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : BaseHero {
    public Vector3 startPos;
    public bool action1;
    public bool action1_Used;
    public bool action2;
    public bool action2_Used;
    public bool activeObject;
    public float resetTimer;
    public float maxReset_Timer = 1f;

    public HeroStateMechine heroStatesMechine;
    public GameManager GM;

	// Use this for initialization
	void Start ()
    {
        resetTimer = maxReset_Timer;
        GM = FindObjectOfType<GameManager>();
        Max_actionCoolDown = 1f;
        ActionCooldown = Max_actionCoolDown;
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
        nameIn_UI.text = hero_Name;
        HPtext.text = "HP: " + curHealth.ToString() + " / " + health.ToString();
        APtext.text = "AP: " + curAction_Points.ToString() + " / " + action_Points.ToString();
        FindTarget();
        if (heroStatesMechine.curHeroState == HeroStateMechine.HeroStates.Waiting)
        {
            action1_Used = false;
            action2_Used = false;
            ActionCooldown = Max_actionCoolDown;

        }
        if (heroStatesMechine.curHeroState == HeroStateMechine.HeroStates.PerformAction)
        {
            Action();
            ActionCoolDown();
        }
        if (heroStatesMechine.curHeroState == HeroStateMechine.HeroStates.ActionComplete)
        {
            resetTimer = maxReset_Timer;
        }
    }

    public void Smash()
    {
        damage = 40f;
        action1 = true;
        action_Points -= 20;
        Action();
    }
    public void SmashAction()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.4f);
    }

    public void Taunt()
    {
        action2 = true;
        curAction_Points -= 30;
        Action();
    }
    public void TauntAction()
    {
        BaseHero[] heros = FindObjectsOfType<BaseHero>();
        foreach (BaseHero hero in heros)
        {
            if (hero != this)
            {
                target = this.gameObject;
            }
            else
            {
                return;
            }
        }
    }
    public void Action()
    {
        if (action1 == true)
        {
            action1_Used = true;
            heroStatesMechine.curHeroState = HeroStateMechine.HeroStates.PerformAction;
            SmashAction();
        }
        if (action2 == true)
        {
            heroStatesMechine.curHeroState = HeroStateMechine.HeroStates.PerformAction;
            Taunt();
        }
        else
        {
            return;
        }
    }
    public void ActionCoolDown()
    {
        ActionCooldown -= Time.deltaTime;
        if (ActionCooldown <= 0)
        {
            transform.position = startPos;
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {
                CompletedAction();
            }
        }
    }
    public void CompletedAction()
    {
        if (action1_Used == true)
        {
            if (target.GetComponent<EnemyStateMechine>() == null)
            {
                target.GetComponent<HeroStateMechine>().curHeroState = HeroStateMechine.HeroStates.TakeDamage;
            }
            target.GetComponent<EnemyStateMechine>().eTurnState = EnemyStateMechine.EnemyTurnState.TakingDamage;
            if (target.GetComponent<BaseEnemy>() == null)
            {
                target.GetComponent<BaseHero>().health -= damage;
            }
            target.GetComponent<BaseEnemy>().health -= damage;
        }
        action1 = false;
        action2 = false;
        heroStatesMechine.curHeroState = HeroStateMechine.HeroStates.ActionComplete;
        GM.curState = GameManager.TurnStates.Standby;
    }
    
}
