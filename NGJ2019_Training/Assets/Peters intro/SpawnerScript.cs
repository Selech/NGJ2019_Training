using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
	public List<GameObject> RandomCubePrefab;

    // Start is called before the first frame update
    void Start()
    {
	    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SpawnNew()
	{
		var go = Instantiate(RandomCubePrefab[0], this.transform.position, Quaternion.identity);
	}
}
