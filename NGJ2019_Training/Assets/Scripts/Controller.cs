using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            this.gameObject.transform.Rotate(Vector3.back, 90);
        }

        if (Input.GetKeyDown("left"))
        {
            this.gameObject.transform.position += (Vector3.left/2);
        }

        if (Input.GetKeyDown("right"))
        {
            this.gameObject.transform.position += (Vector3.right/2);
        }

        if (Input.GetKeyDown("down"))
        {
            this.gameObject.transform.position += (Vector3.down);
        }
    }
}
