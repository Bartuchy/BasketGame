using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private AudioSource bounce;
    private ModeManagerScript challangeModeManager;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bounce = gameObject.GetComponent<AudioSource>();
        if(gameManager.gameMode == 1)
        {
            challangeModeManager = GameObject.Find("ModeManager").GetComponent<ModeManagerScript>();
        }
        
    }

    IEnumerator BallTouchGround()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        if(gameManager.gameMode == 1)
        {
            challangeModeManager.shots--;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        bounce.Play();
        if (collision.gameObject.CompareTag("floor"))
        {
            StartCoroutine(BallTouchGround());
        } 
    }
}
