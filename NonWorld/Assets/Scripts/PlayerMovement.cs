using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour,IMove
{
	[SerializeField] float moveSpeed,currentMoveSpeed;
	
	Rigidbody2D playerRb2d;
	public Camera cam;
	[SerializeField]public GameObject weapon;

	Vector2 movement;
	Vector2  mousePos;
	PlayerStats playerStats;
	[SerializeField]bool canMove = true, isRunning;
	

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public bool CanMove { get => canMove; set => canMove = value; }
    public bool IsRunning { get => isRunning;}

	private void Awake() {
	}

    private void Start() {
		playerRb2d = GetComponent<Rigidbody2D>();
		playerStats = GetComponent<PlayerStats>();
		Cursor.visible = false;
		currentMoveSpeed = moveSpeed;
		

	}

	void Update()
	{
		// Input
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		/*animator.SetFloat("Horizontal",movement.x);
		animator.SetFloat("Vertical",movement.y);
		animator.SetFloat("Speed",movement.sqrMagnitude);*/

		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetKey(KeyCode.LeftShift) && playerStats.CurrentStamina > 0)
		{
			GetComponent<PlayerStats>().CurrentStamina -= 1 * Time.deltaTime;
			UIManager.Instance.UpdateStaminaBar(GetComponent<PlayerStats>().CurrentStamina,GetComponent<PlayerStats>().Stamina);
			currentMoveSpeed = moveSpeed + 2f;
			GetComponent<AudioSource>().pitch = 1.5f;
		}
		else {
			GetComponent<PlayerStats>().CurrentStamina += 1 * Time.deltaTime;
			UIManager.Instance.UpdateStaminaBar(GetComponent<PlayerStats>().CurrentStamina,GetComponent<PlayerStats>().Stamina);
			currentMoveSpeed = moveSpeed;
			GetComponent<AudioSource>().pitch = 1f;
		}
		if (isRunning && weapon.GetComponent<Shooting>().canFire)
		{
			weapon.SetActive(false);
		}
		if (!isRunning)
		{
			weapon.SetActive(true);
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			GetComponent<AudioSource>().Play();
		}
	}


	void FixedUpdate()
	{
		Move(movement);

		Vector2 lookDir = mousePos - playerRb2d.position;
		float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
		playerRb2d.rotation = angle;
		
	}

    public void Move(Vector2 inputVector)
    {
		if (canMove)
		{
			playerRb2d.MovePosition(playerRb2d.position + inputVector.normalized * currentMoveSpeed * Time.fixedDeltaTime);
		}
		if (inputVector.x > 0 || inputVector.y > 0 || inputVector.x < 0 || inputVector.y < 0)
		{
			isRunning = true;
			GetComponent<Animator>().SetBool("Run",isRunning);
			GetComponent<AudioSource>().enabled = true;
		}
		else
		{
			isRunning = false;
			GetComponent<Animator>().SetBool("Run",isRunning);
			GetComponent<AudioSource>().enabled = false;
		}
        // Movement
		//rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);	
		// playerRb2d.velocity = inputVector.normalized * moveSpeed;
    }
    public void Move(Vector3 inputVector)
    {
        throw new System.NotImplementedException();
    }

}
