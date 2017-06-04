using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformGenerator : MonoBehaviour {

    private PickUpsGenerator pickupsGenerator;

    private SawGnerator sawGenerator;
    

    public Objectpoller [] theObjectPools;
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    //private float platformWidth;
    public float platformBetweenMin;
    public float platformBetweenMax;
    //private float platformHeight;
    private int platformSelector;
    //public GameObject[] thePlatforms;
    private float[] platformWidths;


    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;
    
    //private float distanceBetweenHeight;
    // Use this for initialization
    void Start () {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        //platformHeight = thePlatform.GetComponent<BoxCollider2D>().size.y;
        platformWidths = new float[theObjectPools.Length];
        for(int i = 0; i< theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        pickupsGenerator = FindObjectOfType<PickUpsGenerator>();
        sawGenerator = FindObjectOfType<SawGnerator>();
       
    }
	
	// Update is called once per frame
	void Update () {
        //distanceBetweenHeight = Random.Range(-1, 1);

		if(transform.position.x< generationPoint.position.x)
            {
            distanceBetween = Random.Range(platformBetweenMin, platformBetweenMax); //distance between platfroms

            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector])*3 + distanceBetween, heightChange, transform.position.z);



            //Instantiate(/*thePlatform*/ thePlatforms[platformSelector], transform.position, transform.rotation);   // creating new object 
           
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            
            newPlatform.SetActive(true);
            
            pickupsGenerator.SpawnPickUps(new Vector3(transform.position.x,transform.position.y + 1f,transform.position.z));        // making pickups to appear



            
            
            sawGenerator.SpawnSaw(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z));
             
            
           

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]) / 2, transform.position.y, transform.position.z);

        }
    }
}
