using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TetrominoType
{
	I = 0,
	O = 1,
	T = 2,
	S = 3,
	Z = 4,
	J = 5,
	L = 6
}

public class TetrominoScript : MonoBehaviour
{
	private bool HasCollided;
	public TetrominoType Type;
	public PlayerController PlayerController;

	// Start is called before the first frame update
	void Start()
	{
		this.gameObject.layer = LayerMask.NameToLayer("Default");
	}

	void Update()
	{
		if (transform.position.y < -50)
		{
			PlayerController.TetrominoLost();
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (!HasCollided)
		{
			PlayerController.TetrominoCollided();
			this.gameObject.layer = LayerMask.NameToLayer("Tetromino");
			HasCollided = true;
		}
	}
}
