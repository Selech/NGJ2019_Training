using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceGoalScript : MonoBehaviour
{
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] hit2Ds = Physics2D.BoxCastAll(this.gameObject.transform.position, this.gameObject.transform.localScale, 0.0f, Vector2.zero, 0.0f, layerMask);
        foreach (RaycastHit2D hit2D in hit2Ds)
        {
            hit2D.collider.gameObject.GetComponent<TetrominoScript>().PlayerController.PlayerFinished();
        }
    }
}
