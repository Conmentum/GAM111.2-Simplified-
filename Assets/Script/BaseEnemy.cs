using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
	public float damage;
	public float curDamage;
	public float health;
	public float curHealth;
	public float speed;
	public string name;
	public Transform selectedTarget;

	public int armor;
	public int strength;
	public int actionPoints;
	public int curAction_points;


    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {

    }
}