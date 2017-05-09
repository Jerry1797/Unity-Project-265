using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour 
{
	public float Speed = 2;
	public GameObject pause;

	[SerializeField]
	private Vector2 Movement;

	private Rigidbody2D RGB;

	private BoxCollider2D BC;

	private Animator anim;


	void Awake()
	{
		RGB = GetComponent<Rigidbody2D> ();
		BC = GetComponent<BoxCollider2D> ();
	}

	void Start()
	{
		RGB.gravityScale = 0;
		RGB.constraints = RigidbodyConstraints2D.FreezeRotation;
		Time.timeScale = 1;
		anim = gameObject.GetComponent<Animator> ();
	}

	void Update()
	{
		CheckInput ();
		if (Input.GetKeyDown (KeyCode.R))
		{
			SceneManager.LoadScene ("Game");
			Time.timeScale = 1;
		}
		if (Input.GetKeyDown (KeyCode.X))
		{
			pause.gameObject.SetActive (true);
			Time.timeScale = 0;
		}
		if (Input.GetKeyDown (KeyCode.Z))
		{
			SceneManager.LoadScene ("Main Menu");
		}
		anim.SetFloat ("Speed", Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")));

		if (Input.GetAxis ("Horizontal") < -0.1f) 
		{
			transform.localScale = new Vector3(-.05f,.05f,1f);
		}

		if (Input.GetAxis ("Horizontal") > 0.1f) 
		{
			transform.localScale = new Vector3(.05f,.05f,1f);
		}
	}

	void CheckInput()
	{
		var H = Input.GetAxisRaw ("Horizontal");
		var V = Input.GetAxisRaw ("Vertical");

		Movement = new Vector2 (H,V);

		CalculateMovement (Movement * Speed);

	}

	void CalculateMovement(Vector2 PlayerForce)
	{
		RGB.velocity = Vector2.zero;

		RGB.AddForce (PlayerForce,ForceMode2D.Impulse);
	}
}