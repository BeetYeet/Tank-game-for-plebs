﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Health : MonoBehaviour
{
<<<<<<< HEAD
    public int objectHealth;
    public AudioClip hitSound1;
    public AudioClip hitSound2;

    public int speedUp;
    public int damageUp;
    public int healthUp;

    public int pickUpNumber;
    public GameObject floatingTextPrefab;

    //Refrencing the scripts
    public MovementTest move;
    public PlayerShooting hurt;


    private void Start()
    {
        //SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
        move = GameObject.FindObjectOfType<MovementTest>();
        hurt = GameObject.FindObjectOfType<PlayerShooting>();
    }

    void Update()
    {
        if (objectHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
        }
    }

    public void DoDamage(int damage)
    {
        objectHealth -= damage;
        SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Pickup")
        {
            pickUpNumber = Random.Range(0, 3);
        }

        if (floatingTextPrefab)
        {
            ShowUpgrade();
        }

        if (pickUpNumber == 0)
        {
            Speed();
        }
        else if (pickUpNumber == 1)
        {
            Damage();
        }
        else if (pickUpNumber == 2)
        {
            HealthUp();
        }
    }

    void ShowUpgrade()
    {
        var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
        if (pickUpNumber == 0)
        {
            go.GetComponent<TextMesh>().text = "Speed Up";

        }
        else if (pickUpNumber == 1)
        {
            go.GetComponent<TextMesh>().text = "Damage Up";

        }
        else if (pickUpNumber == 2)
        {
            go.GetComponent<TextMesh>().text = "Health Up";

        }
    }
    void Speed() //Increases Speed
    {
        move.moveSpeed += speedUp;
        Debug.Log("SpeedUp active");
    }

    void Damage() //Increases Damage
    {
        hurt.bulletDamage += damageUp;
        Debug.Log("DamageUp active");
    }

    void HealthUp() //Increases health
    {
        objectHealth += healthUp;
        Debug.Log("HealthUp active");
    }

}
=======
	public int health;
	public int maxHealth;

	public AudioClip hitSound1;
	public AudioClip hitSound2;
    public HealthBar hpBar;
	private void Start()
	{
		health = maxHealth;
		//SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
	}

	void Update()
	{
		if (health <= 0)
		{
			Destroy(gameObject);
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
            DoDamage(1);
		}
	}

	public void DoDamage(int damage)
	{
		health -= damage;
		SoundManager.instance.RandomizeSfx(hitSound1, hitSound2);
        hpBar.StartAnimation();
	}
}
>>>>>>> 7d2c418f4439c9a09743a627502c073997231911
