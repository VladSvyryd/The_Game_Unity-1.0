using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : MonoBehaviour {

    public int scoreToGive;
    
    private ScoreManager theScoreManager;

	// Use this for initialization
	void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Rogue_06")
        {
            //theScoreManager.scoreCount += scoreToGive;                easy way to do it

            theScoreManager.AddScore(scoreToGive);

            gameObject.SetActive(false);
                

        }
    }
}
