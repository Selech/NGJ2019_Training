using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceType
{
	I = 0,
	O = 1,
	T = 2,
	S = 3,
	Z = 4,
	J = 5,
	L = 6
}

public class SpawnerScript : GameControllerCommunicator
{
	public List<GameObject> PiecePrefabs;
	public GameObject NextPiece;
	public GameObject StartPiece;
	private Vector2 CurrentPosition;
	private Vector2 Size = new Vector2(10, 1);
	public LayerMask Layer;

	void Awake()
	{
		var index = Random.Range(0, PiecePrefabs.Count - 1);
		NextPiece = PiecePrefabs[index];
	}

	public override void OnGameStart()
	{
		StartCoroutine(CheckHighestPoint());
	}

	public GameObject SpawnNew(PlayerController player)
	{
		if (NextPiece == null)
			NextPiece = StartPiece;

		var go = Instantiate(NextPiece, this.transform.position, Quaternion.identity);
		go.GetComponent<TetrominoScript>().PlayerController = player;
		var index = Random.Range(0, PiecePrefabs.Count - 1);
		NextPiece = PiecePrefabs[index];

		return go;
	}

	public IEnumerator CheckHighestPoint()
	{
		while (true)
		{
			CurrentPosition = this.transform.position;
			RaycastHit2D hit = Physics2D.BoxCast(CurrentPosition, Size, 0, new Vector2(0, -1), 20, Layer);

			this.transform.position = new Vector3(this.transform.position.x, hit.point.y + 20, 0);

			yield return new WaitForSeconds(1f);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position + transform.forward * Size.y, Size);
	}
}
