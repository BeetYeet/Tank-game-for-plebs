﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	public float speedUp;
	public int damageUp;
	public int healthUp;
	[Range(0f, 1f)] //take x less part damage
	public float armorUp;
	int armorLevel = 0;

	public MoveScript move;
	public PlayerShooting hurt;
	public Health health;

	public GameObject floatingTextPrefab;
	void Start()
	{

	}


	public enum Upgrade
	{
		Speed,
		Damage,
		Health,
		Armor,
		None
	}

	private void OnTriggerEnter(Collider collider)
	{
		Upgrade pickup = Upgrade.None;
		if (collider.gameObject.tag == "Pickup")
		{
			pickup = (Upgrade)Random.Range(0, 4);

			if (floatingTextPrefab)
			{
				ShowUpgrade(pickup);
			}

			Destroy(collider.transform.root.gameObject);
		}

	}


	void ShowUpgrade(Upgrade pickup)
	{
		string text = "";
		if (pickup == Upgrade.Speed)
		{
			text = ((speedUp) / move.gasForce).ToString("P") + " Max Speed";
			Speed();
		}
		else if (pickup == Upgrade.Damage)
		{
			text = "+" + (damageUp / hurt.bulletStats.damage).ToString("P") + " Damage";
			Damage();
		}
		else if (pickup == Upgrade.Health)
		{
			text = "+" + healthUp + " Health";
			HealthUp();
		}
		else if (pickup == Upgrade.Armor)
		{
			text = armorUp.ToString("P") + " less damage";
			ArmorUp();
		}
		GameObject go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
		go.GetComponent<FloatingText>().text = text;

	}
	void Speed() //Increases Speed
	{
		move.gasForce += speedUp;
		Debug.Log("SpeedUp active");
	}

	void Damage() //Increases Damage
	{
		hurt.bulletStats.damage += damageUp;
		Debug.Log("DamageUp active");
	}

	void HealthUp() //Increases health
	{
		health.health += Mathf.RoundToInt(healthUp * Mathf.Pow(1 / armorUp, armorLevel));
		Debug.Log("HealthUp active");
	}

	void ArmorUp()
	{
		float val = 1 / armorUp;
		health.health = Mathf.RoundToInt(health.health * val);
		health.maxHealth = Mathf.RoundToInt(health.maxHealth * val);
		armorLevel++;
		Debug.Log("ArmorUp active");
	}

	// Update is called once per frame
	void Update()
	{

	}
}
