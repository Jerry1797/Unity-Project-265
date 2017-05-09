using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour {

	public int health = 0;
	public GameObject enemy;
	private bool attacking = false;
	private Animator anim;
	public GameObject health2;
	public GameObject health3;
	public GameObject health4;
	public GameObject health5;

	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
	}

	void Update()
	{
		anim.SetBool ("attack", attacking);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		attacking = true;
		health += 1;
		if (health == 1) {
			health2.gameObject.SetActive (false);
		}

		if (health == 2) {
			health3.gameObject.SetActive (false);
		}

		if (health == 3) {
			health4.gameObject.SetActive (false);
		}
			
		if (health == 4) {
			enemy.gameObject.SetActive (false);
			health5.gameObject.SetActive (false);
		} else {
			attacking = false;
		}
	}
}
