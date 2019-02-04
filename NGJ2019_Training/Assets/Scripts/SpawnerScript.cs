using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : GameControllerCommunicator
{
	public List<GameObject> PiecePrefabs;
	public GameObject NextPiece;
	public GameObject StartPiece;
	private Vector2 CurrentPosition;
	public HighlightScript HighlightScript;
	public GameController Controller;

	void Awake()
	{
		Controller = GameObject.FindObjectOfType<GameController>();
		var index = Random.Range(0, PiecePrefabs.Count - 1);
		NextPiece = PiecePrefabs[index];
	}

	public override void OnGameStart()
	{
		
	}

	public GameObject SpawnNew(PlayerController player)
	{
		this.transform.position = new Vector3(this.transform.position.x, Controller.CurrentHighPoint + 20, this.transform.position.z);
		if (NextPiece == null)
			NextPiece = StartPiece;

		var go = Instantiate(NextPiece, this.transform.position, Quaternion.identity);
		go.GetComponent<TetrominoScript>().PlayerController = player;
		var index = Random.Range(0, PiecePrefabs.Count - 1);
		NextPiece = PiecePrefabs[index];

		go.transform.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
		HighlightScript.Target = go.GetComponent<TetrominoScript>();
		return go;
	}
}
