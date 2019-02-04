using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightScript : MonoBehaviour
{
	public TetrominoScript Target;
	private int width = 1;
	private int hight = 100;
	private SpriteRenderer spriteRenderer;

	void Awake()
	{
		spriteRenderer = this.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		spriteRenderer.enabled = Target != null;
		if (Target != null)
		{
			UpdateWidth();
			this.transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, this.transform.position.z);
			this.transform.localScale = new Vector3(width, hight, 1);
		}
	}

	private void UpdateWidth()
	{
		switch (Target.Type)
		{
			case TetrominoType.I:
				width = IsRotated() ? 1 : 4;
				break;
			case TetrominoType.J:
			case TetrominoType.L:
				width = IsRotated() ? 2 : 3;
				break;
			case TetrominoType.O:
				width = 2;
				break;
			case TetrominoType.T:
				width = IsRotated() ? 2 : 3;
				break;
			case TetrominoType.S:
			case TetrominoType.Z:
				width = IsRotated() ? 2 : 3;
				break;
		}
	}

	private bool IsRotated()
	{
		var rotation = Math.Abs((int)Target.transform.rotation.eulerAngles.z);
		if (rotation == 0 || rotation == 180)
		{
			return false;
		}
		return true;
	}
}
