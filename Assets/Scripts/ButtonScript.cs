using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class ButtonScript : MonoBehaviour
{
    private GameObject childGameObject;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Load);
        childGameObject = gameObject.transform.GetChild(0).gameObject;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void CheckPause()
    {
        if (gameManager.isPaused)
        {
            gameManager.Pause();
        }
    }

    private void Load()
    {
        switch (childGameObject.name)
        {
            case "Challange":
                SceneManager.LoadScene("BasketballSceneChallange");
                gameManager.gameMode = 1;
                break;

            case "OpenMode":
                SceneManager.LoadScene("BasketballScene");
                gameManager.gameMode = 2;
                break;

            case "Settings":
                    
                break;

            case "Restart":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                CheckPause();
                break;

            case "Menu":
                SceneManager.LoadScene("TitleScene");
                CheckPause();
                break;
        }
        
    }
}
