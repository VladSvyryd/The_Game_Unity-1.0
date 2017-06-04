using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTool : MonoBehaviour
{

    public Transform platformGenerator;
    private Vector3 platfrotmStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private ScoreManager scoreManager;

    private PlatformDestroyer[] platformList;

    public DeathMenu deathMenu;

    // Use this for initialization
    void Start()
    {
        platfrotmStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()
    {
        scoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        deathMenu.gameObject.SetActive(true);
        // StartCoroutine("RestartGameCo");
    }
    public void Reset()
    {
        deathMenu.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroyer>();          //finding all platforms that were created in our game
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);                //making evera object in that list of generating platforms false.
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platfrotmStartPoint;
        thePlayer.gameObject.SetActive(true);       // reincornation of the hero , on the start point

        scoreManager.scoreCount = 0;
        scoreManager.scoreIncreasing = true;
    }
    //add some delayes between restarting game
    /*public IEnumerator RestartGameCo()
    {
        scoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);  //set the player invisible , so die
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();          //finding all platforms that were created in our game
        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);                //making evera object in that list of generating platforms false.
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platfrotmStartPoint;
        thePlayer.gameObject.SetActive(true);       // reincornation of the hero , on the start point

        scoreManager.scoreCount = 0;
        scoreManager.scoreIncreasing = true;
    }*/
}
