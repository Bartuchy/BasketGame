using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pasueMenu;
    public bool isPaused = false;
    public int gameMode;
    public ModeManagerScript modeManagerScript;

    private void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "TitleScene" /*&& !modeManagerScript.gameOver.activeInHierarchy*/)
        {
            Pause();
        }
    }

    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("GameManager").Length > 1)
        {
            Destroy(gameObject);
            Destroy(pasueMenu);
        }
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(pasueMenu);
    }

    public void Pause()
    {
        isPaused = !isPaused;
        pasueMenu.SetActive(isPaused);
        if (isPaused)
        {
           Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
