using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
    private Rigidbody2D rigidbody2d;
    private float speed = 5f;//Replace with your max speed

    public float OverlapFactor = 0.01f;

	// Start is called before the first frame update
	void Start()
	{
		this.gameObject.layer = LayerMask.NameToLayer("Default");
	    rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (transform.position.y < -50)
		{
			PlayerController.TetrominoLost();
			Destroy(this.gameObject);
		}
	}

    /*void OnCollisionEnter2D(Collision2D collision)
	{
		if (!HasCollided)
		{
			PlayerController.TetrominoCollided();
			this.gameObject.layer = LayerMask.NameToLayer("Tetromino");
			HasCollided = true;
		}
	}*/

    void FixedUpdate()
    {
        if ((rigidbody2d.velocity.magnitude > speed || rigidbody2d.velocity.magnitude < speed) && !HasCollided)
        {
            print(rigidbody2d.velocity);
            rigidbody2d.velocity = rigidbody2d.velocity.normalized * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!HasCollided)
        {
            Camera.main.GetComponent<CameraController>().ShakeCamera();

            var testCollider = collision.collider.bounds;
            testCollider.size = new Vector3(testCollider.size.x * 1f, testCollider.size.y * 1, testCollider.size.z * 1);
            HasCollided = testCollider.Intersects(collision.otherCollider.bounds);
            //print(testCollider.Intersects(collision.otherCollider.bounds));
            //print("This: " + collision.collider.bounds);
            //print("Other: " + collision.otherCollider.bounds);
            CallCollided();
        }
    }

    private bool hasCalledCollided = false;
    private void CallCollided()
    {
        if (!hasCalledCollided)
        {
            //rigidbody2d.mass = 500f;
            rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
            hasCalledCollided = true;
            PlayerController.TetrominoCollided();
            this.gameObject.layer = LayerMask.NameToLayer("Tetromino");
        }
    }
}
