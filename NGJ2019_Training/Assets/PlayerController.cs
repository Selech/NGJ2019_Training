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

	private SpawnerScript Spawner;

	private int i;

	private int movePieceInterval = 10;

	void Awake()
	{
		Spawner = GetComponentInChildren<SpawnerScript>();
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

		if (Input.GetKey(Left))
		{
			if (i > movePieceInterval) {
				CurrentPiece.transform.position += (Vector3.left / 2);
				i = 0;
			}
		}

		if (Input.GetKey(Right))
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

		if (Input.GetKeyDown(LeftDash))
		{
			CurrentPiece.transform.position += (Vector3.left);
		}

		if (Input.GetKeyDown(RightDash))
		{
			CurrentPiece.transform.position += (Vector3.right);
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
