using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawGnerator : MonoBehaviour {

    public Objectpoller pickUpsPool;

    public float distanceBetweenPickUps;
    private SawGnerator sawGenerator;
    
    private void Update()
    {
        
    }
    public void SpawnSaw(Vector3 startPosition)
    {




        GameObject saw = pickUpsPool.GetPooledObject();   // took the object from Array of Objects 
        saw.transform.position = startPosition;
        saw.SetActive(true);
    }
}
