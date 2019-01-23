using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceType {
	I = 0,
	O = 1,
	T = 2,
	S = 3,
	Z = 4,
	J = 5,
	L = 6
}

public class SpawnerScript : MonoBehaviour
{
	public List<GameObject> PiecePrefabs;
	public GameObject NextPiece;
	public GameObject StartPiece;

	public void Start()
	{
		var index = Random.Range(0, PiecePrefabs.Count - 1);
		StartPiece = PiecePrefabs[index];
		SpawnNew();
	}

	public GameObject SpawnNew()
	{
		if (NextPiece == null)
			NextPiece = StartPiece;

		var go = Instantiate(NextPiece, this.transform.position, Quaternion.identity);
		var index = Random.Range(0, PiecePrefabs.Count - 1);
		NextPiece = PiecePrefabs[index];

		return go;
	}
}
