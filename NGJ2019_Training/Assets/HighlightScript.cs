using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightScript : MonoBehaviour
{
	public TetrominoScript Target;
	private int width = 1;
	private int hight = 50;
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
				//width = Target.transform.rotation.eulerAngles.z == 
				break;
			case TetrominoType.J:
			case TetrominoType.L:
				break;
			case TetrominoType.O:
				width = 2;
				break;
			case TetrominoType.T:

				break;
			case TetrominoType.S:
			case TetrominoType.Z:
				break;
		}
	}
}
