using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : BaseHero {
    

	// Use this for initialization
	void Start () {
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
}
