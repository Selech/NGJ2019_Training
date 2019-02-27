using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class HightController : GameControllerCommunicator
{
	public Vector3 CurrentPosition;
	private Vector2 size = new Vector2(50, 100);
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
			RaycastHit2D[] hits = Physics2D.BoxCastAll(CurrentPosition, size, 0, new Vector2(0, -1), 1, Layer);
			GameController.CurrentHighPoint = GetHighestPoint(hits);
			yield return new WaitForSeconds(1f);
		}
	}

	private float GetHighestPoint(RaycastHit2D[] hits)
	{
		if (hits.Length > 0)
		{
			return hits.Max(r => r.point.y);
		}

		return 0;
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position + transform.forward * size.y, size);
	}
}
