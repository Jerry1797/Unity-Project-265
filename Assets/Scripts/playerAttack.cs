using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour {

	private bool attacking = false;

	private float attackTimer = 0;
	private float attackCD = 0.3f;

	public GameObject attackTrigger;

	private Animator anim;

	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
		attackTrigger.gameObject.SetActive (false);
	}

	void Update()
	{
		if (Input.GetKeyDown ("space") && !attacking) 
		{
			attacking = true;
			attackTimer = attackCD;
			attackTrigger.gameObject.SetActive (true);

		}
		if (attacking) 
		{
			if (attackTimer > 0) 
			{
				attackTimer -= Time.deltaTime;
			} 
			else 
			{
				attacking = false;
				attackTrigger.gameObject.SetActive (false);
			}
		}
		anim.SetBool ("Attacking", attacking);
	}
}
