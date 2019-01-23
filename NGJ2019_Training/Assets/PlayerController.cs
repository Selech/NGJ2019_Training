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
        
    }

	public void TetrominoCollided()
	{
		CurrentPiece = Spawner.SpawnNew(this);
	}
}
