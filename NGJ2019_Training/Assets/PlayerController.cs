using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameControllerCommunicator
{
	public GameObject CurrentPiece;

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

		if (Input.GetKeyDown("up"))
		{
			CurrentPiece.transform.Rotate(Vector3.back, 90);
		}

		if (Input.GetKey("left"))
		{
			if (i > movePieceInterval) {
				CurrentPiece.transform.position += (Vector3.left / 2);
				i = 0;
			}
		}

		if (Input.GetKey("right"))
		{
			if (i > movePieceInterval) {
				CurrentPiece.transform.position += (Vector3.right / 2);
				i = 0;
			}
		}

		if (Input.GetKey("down"))
		{
			CurrentPiece.transform.position += Vector3.down/5;
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
