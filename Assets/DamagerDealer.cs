using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerDealer : BaseHero {

	// Use this for initialization
	void Start () {
		nameInUI_asTarget.text = hero_Name;
        health = strength * armor;
        curHealth = health;
        action_Points = 100;
        curAction_Points = action_Points;
    }
	
	// Update is called once per frame
	void Update () {
        nameIn_UI.text = hero_Name;
        HPtext.text = "HP: " + curHealth.ToString() + " / " + health.ToString();
        APtext.text = "AP: " + curAction_Points.ToString() + " / " + action_Points.ToString();

    }

	public void DmgDealer_Action1(){
	
	}

	public void DmgDealer_Action2(){
	
	}
}
