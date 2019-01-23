using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnerScript : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject.Destroy(collision.gameObject);
	}
}
