using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameControllerCommunicator
{
	public GameObject CurrentPiece;

	public KeyCode Rotate;
	public KeyCode Left;
	public KeyCode Right;
	public KeyCode Down;
	public KeyCode LeftDash;
	public KeyCode RightDash;
	public KeyCode Defense;
	public KeyCode Offense;

	private SpawnerScript Spawner;

	private int i;

	private int movePieceInterval = 10;

	private float LeftBorder;
	private float RightBorder;

	private bool HasPower;

	void Awake()
	{
		Spawner = GetComponentInChildren<SpawnerScript>();
		LeftBorder = this.transform.position.x - this.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
		RightBorder = this.transform.position.x + this.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
	}

	public override void OnGameStart()
	{
		CurrentPiece = Spawner.SpawnNew(this);
	}

	// Update is called once per frame
	void Update()
    {
		i++;
		if (CurrentPiece == null)
		{
			return;
		}

		CurrentPiece.transform.position += (Vector3.down * Time.deltaTime) * 4;

		if (Input.GetKeyDown(Rotate))
		{
			CurrentPiece.transform.Rotate(Vector3.back, 90);
		}

		if (Input.GetKey(Left) && CurrentPiece.transform.position.x > LeftBorder)
		{
			if (i > movePieceInterval) {
				CurrentPiece.transform.position += (Vector3.left / 2);
				i = 0;
			}
		}

		if (Input.GetKey(Right) && CurrentPiece.transform.position.x < RightBorder)
		{
			if (i > movePieceInterval) {
				CurrentPiece.transform.position += (Vector3.right / 2);
				i = 0;
			}
		}

		if (Input.GetKey(Down))
		{
			CurrentPiece.transform.position += Vector3.down/5;
		}

		if (Input.GetKeyDown(LeftDash) && CurrentPiece.transform.position.x > LeftBorder)
		{
			CurrentPiece.transform.position += (Vector3.left);
		}

		if (Input.GetKeyDown(RightDash) && CurrentPiece.transform.position.x < RightBorder)
		{
			CurrentPiece.transform.position += (Vector3.right);
		}

		if (Input.GetKeyDown(Offense) && HasPower)
		{
			// Use Offense power
		}

		if (Input.GetKeyDown(Defense) && HasPower)
		{
			// Use Defense power
		}
	}

	public void TetrominoCollided()
	{
		CurrentPiece.transform.GetComponent<Rigidbody2D>().gravityScale = 1f;
		CurrentPiece = Spawner.SpawnNew(this);
	}

	public void TetrominoLost()
	{
		// TODO
	}
}
