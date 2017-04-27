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
	public GameObject targetedChar;
    public string hero_Name;
    public float damage;
    public float health;
    public float curHealth;
	public int action_Points;
    public int curAction_Points;
    public float speed;
    public int armor;
    public int strength;
	public GameObject buttonIn_UI;
    public BaseHero friendly_Target;
    public BaseEnemy enemy_Target;
    public GameObject target;

    public float Max_actionCoolDown;
    public float ActionCooldown;

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
    public void FindTarget()
    {
        targetedChar = FindObjectOfType<GameManager>().curTarget;
        friendly_Target = targetedChar.GetComponent<BaseHero>();

        if (friendly_Target == null)
        {
            enemy_Target = targetedChar.GetComponent<BaseEnemy>();
        }

        if (friendly_Target != null)
        {
            target = friendly_Target.gameObject;
            enemy_Target = null;
        }
        else if (friendly_Target == null)
        {
            target = enemy_Target.gameObject;
        }
    }
}