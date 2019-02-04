using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class HightController : GameControllerCommunicator
{
	public Vector3 CurrentPosition;
	private Vector2 size = new Vector2(50, 1);
	public LayerMask Layer;
	public GameController GameController;

	void Awake()
	{
		GameController = GameObject.FindObjectOfType<GameController>();
		StartCoroutine(CheckHighestPoint());
	}

	public IEnumerator CheckHighestPoint()
	{
		while (true)
		{
			CurrentPosition = this.transform.position;
			RaycastHit2D hit = Physics2D.BoxCast(CurrentPosition, size, 0, new Vector2(0, -1), 100, Layer);
			GameController.CurrentHighPoint = hit.point.y;
			yield return new WaitForSeconds(1f);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position + transform.forward * size.y, size);
	}
}
