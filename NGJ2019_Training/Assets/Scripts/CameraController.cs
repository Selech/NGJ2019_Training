using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject[] Players;
	public List<SpawnerScript> Spawners = new List<SpawnerScript>();

	// Start is called before the first frame update
	void Start()
	{
		Players = GameObject.FindGameObjectsWithTag("Player");
		foreach (var player in Players)
		{
			Spawners.Add(player.GetComponentInChildren<SpawnerScript>());
		}
	}

	// Update is called once per frame
	void Update()
	{
		var position = this.transform.position;
		foreach (var spawner in Spawners)
		{
			if (spawner.transform.position.y > position.y)
			{
				position = new Vector3(position.x, spawner.transform.position.y - 10, position.z);
			}
		}

		this.transform.position = Vector3.MoveTowards(this.transform.position, position, 0.5f * Time.deltaTime);
	}
}
