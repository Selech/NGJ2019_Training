using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : GameControllerCommunicator
{
	public GameController Controller;
	public float HightFloatHighestPoint = 5;

	void Awake()
	{
		Controller = GameObject.FindObjectOfType<GameController>();
	}

	// Update is called once per frame
	void Update()
	{
		var position = this.transform.position;
		position = new Vector3(position.x, Controller.CurrentHighPoint + HightFloatHighestPoint, position.z);
		if (position.y < 10)
		{
			return;
		}
		this.transform.position = Vector3.Slerp(this.transform.position, position, 0.15f * Time.deltaTime);
	}
}
