using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeManagerScript : MonoBehaviour
{
    private float timer;
    public int shots;

    public Text timerText;
    public Text scoreText;

    private Vector3 randomPosition;

    public GameObject ballPrefab;
    public GameObject gameOver;
    public GameObject sensor;

    private GameObject player;
    private Rigidbody ballRb;

    private PlayerController playerController;
    private GameManager gameManager;
    private Counter counter;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.modeManagerScript = gameManager.GetComponent<ModeManagerScript>();
        
        if(gameManager.gameMode == 1)
        {
            counter = GameObject.Find("sensor").GetComponent<Counter>();
        }
        

        playerController = player.GetComponent<PlayerController>();
        ballRb = ballPrefab.GetComponent<Rigidbody>();

        
        shots = 0;
        timer = 60;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBall();

        if(gameManager.gameMode == 1)
        {
            StartCoroutine(Timer());
            ChangePosition();
            if(timer <= 0)
            {
                gameOver.SetActive(true);
                playerController.enabled = false;
                scoreText.text = "Your score: " + counter.count;
            }
        }
    }

    private void SpawnBall()
    {
        if (GameObject.FindWithTag("Ball") == null)
        {
            Instantiate(ballPrefab, player.transform.position + (Vector3.forward * 1.5f), ballPrefab.transform.rotation);
            ballPrefab.GetComponent<AudioSource>().enabled = false;
            ballRb.useGravity = false;

            playerController.isBallKept = true;
        }
    }

    IEnumerator Timer()
    {
        if (gameManager.isPaused)
        {
            yield return new WaitForSeconds(100000);
        }
        else
        {
            yield return new WaitForSeconds(1);
        }

        if(timer >= 0)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + (int)timer;
        }
        
    }

    private void ChangePosition()
    {
        if (shots == 0)
        {
            randomPosition = new Vector3(Random.Range(15, 45), 2.30f, Random.Range(20, 40));
            player.transform.position = randomPosition;
            shots = 2;
        }
    }
}
