using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public Vector3 startingPos;
	public float damage;
	public float curDamage;
	public float health;
	public float curHealth;
	public Transform selectedTarget;

	public int armor;
	public int strength;
	public int actionPoints;
	public int curAction_points;

}