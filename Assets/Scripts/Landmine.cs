﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour
{
	public int damage;

	public float timer;
	float timerMax;

	public float explosionForce = 10f;
	public float explosionUpFactor = .5f;

	public UnityEngine.UI.Image timerImage;

	public GameObject Explosion;


	// Start is called before the first frame update
	void Start()
	{
		timerMax = timer;
	}

	// Update is called once per frame
	void Update()
	{
		if (timer != 0f)
		{
			timer -= Time.deltaTime;

			if (timer < 0f)
			{
				timer = 0f;
				Destroy(timerImage.canvas.gameObject);
				Debug.Log("Mine active");
			}
			timerImage.fillAmount = timer / timerMax;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Trigger(other);
	}

	private void OnTriggerStay(Collider other)
	{
		Trigger(other);
	}

	private void Trigger(Collider other)
	{
		if (timer == 0f)
		{
			if (other.gameObject.tag == "Player")
			{
				Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation);
				Destroy(gameObject);
				other.gameObject.GetComponent<Health>().DoDamage(damage);
				other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, 5f, explosionUpFactor);
				Debug.Log("Mine Triggered");
			}
		}
	}
}
