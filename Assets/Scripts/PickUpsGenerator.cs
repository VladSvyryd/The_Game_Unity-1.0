using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsGenerator : MonoBehaviour {

    public Objectpoller pickUpsPool;

    public float distanceBetweenPickUps;

	public void SpawnPickUps(Vector3 startPosition)
    {
        GameObject coke1 = pickUpsPool.GetPooledObject();   // took the object from Array of Objects 
        coke1.transform.position = startPosition;
        coke1.SetActive(true);

        GameObject coke2 = pickUpsPool.GetPooledObject();   // took the object from Array of Objects 
        coke2.transform.position = new Vector3(startPosition.x - distanceBetweenPickUps, startPosition.y, startPosition.z);     //to create coins a little bit far from each other
        coke2.SetActive(true);

        GameObject coke3 = pickUpsPool.GetPooledObject();   // took the object from Array of Objects 
        coke3.transform.position = new Vector3(startPosition.x + distanceBetweenPickUps, startPosition.y, startPosition.z);     //to create coins a little bit far from each other
        coke3.SetActive(true);
    }
}
