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

public class SpawnerScript : GameControllerCommunicator
{
	public List<GameObject> PiecePrefabs;
	public GameObject NextPiece;
	public GameObject StartPiece;
	private Vector2 CurrentPosition;
	private Vector2 Size = new Vector2(10, 1);

<<<<<<< Updated upstream
    public override void OnGameStart()
    {
        var index = Random.Range(0, PiecePrefabs.Count - 1);
        StartPiece = PiecePrefabs[index];
        SpawnNew();
    }
=======
	public void Start()
	{
		var index = Random.Range(0, PiecePrefabs.Count - 1);
		StartPiece = PiecePrefabs[index];
		SpawnNew();
		StartCoroutine(CheckHighestPoint());
	}
>>>>>>> Stashed changes

    public GameObject SpawnNew()
	{
		if (NextPiece == null)
			NextPiece = StartPiece;

		var go = Instantiate(NextPiece, this.transform.position, Quaternion.identity);
		var index = Random.Range(0, PiecePrefabs.Count - 1);
		NextPiece = PiecePrefabs[index];

		return go;
	}

	public IEnumerator CheckHighestPoint()
	{
		CurrentPosition = this.transform.position;

		RaycastHit2D hit = Physics2D.BoxCast(CurrentPosition, Size, 0, new Vector2(0, -1));
		if (hit)
			Debug.Log("Hit : " + hit.collider.name);
		return new WaitForSeconds(1f);
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position + transform.forward * Size.y, Size);
	}
}
