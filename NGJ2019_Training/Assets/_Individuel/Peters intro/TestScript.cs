using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
	public Material Green;
	public float movespeed = 0.01f;
	private SpawnerScript spawnerScript;
	 

	// Start is called before the first frame update
	void Start()
	{
		var col = this.GetComponent<BoxCollider>();
		//this.GetComponent<Rigidbody>().useGravity = false;
		movespeed = 2;

		spawnerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnerScript>();
		//col.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			this.GetComponent<MeshRenderer>().materials = new Material[] { Green };
			this.GetComponent<Rigidbody>().position = new Vector3(0, 6, 0);
			this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			this.GetComponent<Rigidbody>().position = this.GetComponent<Rigidbody>().position + new Vector3(-movespeed, 0, 0);
		}

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			this.GetComponent<Rigidbody>().position = this.GetComponent<Rigidbody>().position + new Vector3(movespeed, 0, 0);
		}

		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			transform.RotateAround(transform.position, Vector3.forward, 45);
			Physics.gravity = new Vector3(0,0,0);
			//this.GetComponent<Rigidbody>().rotation =
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			spawnerScript.SpawnNew();
			//transform.RotateAround(transform.position, Vector3.forward, 45);
			//Physics.gravity = new Vector3(0, 0, 0);
			//this.GetComponent<Rigidbody>().rotation =
		}
	}

	void OnCollisionEnter(Collision col)
	{

	}
}
