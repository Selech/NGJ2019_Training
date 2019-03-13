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
    private bool Corrected;
    public float ExpectedAngle;

    public float OverlapFactor = 0.01f;

    //public Vector3 PrevPosition;
    //public float PrevRotation;
    //public Vector2 PrevVelocity;
    //public float PrevAngularVelocity;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!HasCollided)
        {
            PlayerController.TetrominoCollided(collision);
            this.gameObject.layer = LayerMask.NameToLayer("Tetromino");
            HasCollided = true;
        }
    }

    //public void SetPreviousState()
    //{
    //    this.transform.position = PrevPosition;
    //    this.transform.rotation = Quaternion.Euler(0, 0, PrevRotation);
    //    this.rigidbody2d.velocity = PrevVelocity;
    //    this.rigidbody2d.angularVelocity = PrevAngularVelocity;
    //}

    void FixedUpdate()
    {
        if ((rigidbody2d.velocity.magnitude > speed || rigidbody2d.velocity.magnitude < speed) && !HasCollided)
        {
            rigidbody2d.velocity = rigidbody2d.velocity.normalized * speed;
        }

        //if (HasCollided && !Corrected)
        //{
        //    print(rigidbody2d.velocity);

        //    rigidbody2d.velocity = Vector2.zero;
        //    rigidbody2d.angularVelocity = 0;
        //    var height = (int)((transform.position.y + 0.1f) * 2);
        //    this.transform.position = new Vector3(this.transform.position.x, height / 2f, 0);

        //    var newRotation = Quaternion.Euler(0, 0, ExpectedAngle);
        //    this.transform.localRotation = newRotation;

        //    //this.transform.rotation = newRotation;
        //    Corrected = true;
        //}

        //SaveState();
    }

    //private void SaveState()
    //{
    //    PrevPosition = this.transform.position;
    //    PrevRotation = this.transform.rotation.eulerAngles.z;
    //    PrevVelocity = this.rigidbody2d.velocity;
    //    PrevAngularVelocity = this.rigidbody2d.angularVelocity;
    //}

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (!HasCollided)
    //    {
    //        Camera.main.GetComponent<CameraController>().ShakeCamera();

    //        var testCollider = collision.collider.bounds;
    //        testCollider.size = new Vector3(testCollider.size.x * 1f, testCollider.size.y * 1, testCollider.size.z * 1);
    //        HasCollided = testCollider.Intersects(collision.otherCollider.bounds);
    //        //print(testCollider.Intersects(collision.otherCollider.bounds));
    //        //print("This: " + collision.collider.bounds);
    //        //print("Other: " + collision.otherCollider.bounds);
    //        CallCollided();
    //    }
    //}

    private bool hasCalledCollided = false;
    private void CallCollided()
    {
        if (!hasCalledCollided)
        {
            //rigidbody2d.mass = 500f;
            rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
            PlayerController.TetrominoCollided(null);
            hasCalledCollided = true;
            this.gameObject.layer = LayerMask.NameToLayer("Tetromino");
        }
    }
}
