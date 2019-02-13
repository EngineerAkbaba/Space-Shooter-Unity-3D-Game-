using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard; //Referances to asteroids
    public Vector3 spawnValues; //Coordinates of asteroids

    public int hazardCount; //Number of asteroids
    private float spawnWait; //The time that an asteroid will wait after another one
    public float startWait; //The time that asteroid will wait before coming first time
    public float waveWait; //The time that another asteroid SET will come

    public Text scoreText; //The UI variable to referance scoreText
    public Text gameOverText; //The UI variable to referance gameOverText
    public Text restartText; //The UI variable to referance restartText

    private bool gameOver; //The variable to check whether the game is over or not
    private bool restart; //The variable to check whether the game restart  or not
    private int score; //Score of the player

    //Start runs when the scene starts running
    void Start ()
    {
        gameOver = false; //Initialy gameOver should be false
        restart = false; //Initialy restart should be false
        gameOverText.text = ""; //Initialy gameOverText should be empty
        restartText.text = ""; //Initialy restartText should be empty
        score = 0; //Initialy the score is zero
        UpdateScore(); //Call UpdateScore to display empty score text
        StartCoroutine(SpawnWaves()); //Call function
        spawnWait = 1f; //Let the asteroids come every 1f initialy
    }

    //Update executes per frame
    void Update()
    {
        if (restart) //If the user want to restart the game
        {
            if (Input.GetKeyDown(KeyCode.R)) //Use the 'R' key to restart
            {
                Application.LoadLevel(Application.loadedLevel); //Load the current level/scene
            }
        }
    }

    //Create asteroid spawns
    IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                yield return new WaitForSeconds(startWait); //Wait before starting of coming asteroids
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);//Assign asteroid coordinates by using vector3
                Quaternion spawnRotation = Quaternion.identity; //Rotation of asteroid
                Instantiate(hazard, spawnPosition, spawnRotation); //Create asteroid
                yield return new WaitForSeconds(spawnWait); //Wait after an asteroid has came
                if (gameOver) //If the game is end
                {
                    restartText.text = "Press 'R' to Restart"; //Message the restart option
                    restart = true; //The bool variable restart should be true in this case
                    break; //Break the while loop (Stop creating asteroid)
                }
            }
            yield return new WaitForSeconds(waveWait); //Wait for another asteroid set
        }
    }

    //Count score
    public void AddScore (int newScoreValue)
    {
        score = score + newScoreValue; //Increase the score
        UpdateScore(); //Call UpdateScore to dispyal the score
    }

    //Display the score on the screen
    void UpdateScore()
    {
        scoreText.text = "   Score : " + score; //Update scoreTest UI value

        //Decrease spawnWait (increase the rate of coming of asteroid) every 100 points
        if (score >= 0 && score <= 100)
        {
            spawnWait = 0.5f;
        }
        if (score > 100 && score <= 200)
        {
            spawnWait = 0.3f;
        }
        if (score > 200 && score <= 300)
        {
            spawnWait = 0.1f;
        }
        if (score > 300 && score <= 400)
        {
            spawnWait = 0.05f;
        }
        if (score > 400 && score <= 500)
        {
            spawnWait = 0.025f;
        }
        if (score > 500 && score <= 600)
        {
            spawnWait = 0.0125f;
        }
        if (score > 600 && score <= 700)
        {
            spawnWait = 0.00625f;
        }
        if (score > 700 && score <= 800)
        {
            spawnWait = 0.003125f;
        }
        if (score > 800 && score <= 900)
        {
            spawnWait = 0.0015625f;
        }
        if (score > 900 && score <= 1000)
        {
            spawnWait = 0.00078125f;
        }
        if (score > 1000)
        {
            spawnWait = 0.0003900625f;
        }
    }

    //End the game
    public void GameOver()
    {
        gameOverText.text = "Game Over!"; //Message that the game is over
        gameOver = true; //The bool variable gameOver should be true in this case
    }
}
