using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameControllerCommunicator
{
    public ParticleSystem Win;

    public GameObject CurrentPiece;

    public KeyCode Rotate;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Down;
    public KeyCode LeftDash;
    public KeyCode RightDash;
    public KeyCode Defense;
    public KeyCode Offense;

    private SpawnerScript Spawner;
    private GameController Controller;

    private int i;
    private bool IsFinished = false;
    public bool BoxInside = false;
    private int timer;

    private int movePieceInterval = 8;

    private float LeftBorder;
    private float RightBorder;

    private bool HasPower;

    public List<TetrominoScript> Pieces = new List<TetrominoScript>();

    void Awake()
    {
        Controller = GameObject.FindObjectOfType<GameController>();
        Spawner = GetComponentInChildren<SpawnerScript>();
        LeftBorder = this.transform.position.x - this.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        RightBorder = this.transform.position.x + this.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    public override void OnGameStart()
    {
        CurrentPiece = Spawner.SpawnNew(this);
    }

    public override void FuckMeUp()
    {
        CurrentPiece.transform.localScale *= 2;
        CurrentPiece.GetComponent<Rigidbody2D>().mass *= 2;
    }

    public void PlayerFinished()
    {

        if (!IsFinished)
        {         //Spawner.NextPiece = null;
            Destroy(CurrentPiece);
            IsFinished = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HasWon) return;

        if (BoxInside)
        {
            timer++;
        }
        else if (IsFinished)
        {
            timer = 0;
            CurrentPiece = Spawner.SpawnNew(this);
            IsFinished = false;
        }
        if (timer > 200)
        {
            Instantiate(Win, new Vector3(this.transform.position.x, Controller.CurrentHighPoint), Quaternion.identity);
            HasWon = true;
        }

        i++;
        if (CurrentPiece == null)
        {
            return;
        }

        Rigidbody2D rb = CurrentPiece.GetComponent<Rigidbody2D>();
        TetrominoScript ts = CurrentPiece.GetComponent<TetrominoScript>();

        //rb.position += (Vector2.down * Time.deltaTime) * 4;

        if (Input.GetKeyDown(Rotate))
        {
            if (i > movePieceInterval / 2)
            {
                rb.rotation -= 90;
                ts.ExpectedAngle -= 90;
                i = 0;
            }
        }

        if (Input.GetKey(Left) && rb.position.x > LeftBorder)
        {
            if (i > movePieceInterval)
            {
                rb.position += (Vector2.left / 2);
                i = 0;
            }
        }

        if (Input.GetKey(Right) && rb.position.x < RightBorder)
        {
            if (i > movePieceInterval)
            {
                rb.position += (Vector2.right / 2);
                i = 0;
            }
        }

        if (Input.GetKey(Down))
        {
            rb.position += Vector2.down / 10;
        }

        if (Input.GetKeyDown(LeftDash) && rb.position.x > LeftBorder)
        {
            rb.position += (Vector2.left);
        }

        if (Input.GetKeyDown(RightDash) && rb.position.x < RightBorder)
        {
            rb.position += (Vector2.right);
        }

        if (Input.GetKeyDown(Offense))
        {
            Controller.UsePower(this.GetComponent<GameControllerCommunicator>());
        }

        if (Input.GetKeyDown(Defense))
        {
            Controller.UsePower(this.GetComponent<GameControllerCommunicator>());
        }
    }

    public bool HasWon { get; set; }

    public void TetrominoCollided()
    {
        CurrentPiece.GetComponent<Rigidbody2D>().gravityScale = 1f;
        foreach (var tetrominoScript in Pieces)
        {
            //tetrominoScript.SetPreviousState();
        }
        Pieces.Add(CurrentPiece.GetComponent<TetrominoScript>());
        CurrentPiece = Spawner.SpawnNew(this);
    }

    public void TetrominoLost()
    {
        // TODO
    }
}
