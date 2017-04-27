using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BaseHero : MonoBehaviour
{
    public Text nameIn_UI;
    public Text HPtext;
    public Text APtext;
	public Text nameInUI_asTarget;
    public string hero_Name;
    public float damage;
    public float health;
    public float curHealth;
    public float action_Points;
    public float curAction_Points;
    public float speed;
    public int armor;
    public int strength;
    //attack1
    //attack2

    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage()
    {
        health -= damage;
        if (health <= 0)
        {
            print(hero_Name + " was defeated");
            Destroy(gameObject);
        }
    }
    public void startCoolDown()
    {
        GetComponent<HeroStateMechine>().curHeroState = HeroStateMechine.HeroStates.Waiting;
        GetComponent<HeroStateMechine>().StartCooldown = true;
    }
}