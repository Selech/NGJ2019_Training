using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameControllerCommunicator
{
	public GameObject CurrentPiece;

	private SpawnerScript Spawner;

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
		if (Input.GetKeyDown("up"))
		{
			CurrentPiece.transform.Rotate(Vector3.back, 90);
		}

		if (Input.GetKeyDown("left"))
		{
			CurrentPiece.transform.position += (Vector3.left / 2);
		}

		if (Input.GetKeyDown("right"))
		{
			CurrentPiece.transform.position += (Vector3.right / 2);
		}

		if (Input.GetKeyDown("down"))
		{
			CurrentPiece.transform.position += (Vector3.down);
		}
	}

	public void TetrominoCollided()
	{
		CurrentPiece = Spawner.SpawnNew(this);
	}

	public void TetrominoLost()
	{
		// TODO
	}
}
