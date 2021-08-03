using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowingForcScript : MonoBehaviour
{
    public int max;
    public float bonusForce;

    private Image mask;

    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        mask = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
        playerController = GameObject.Find("player").GetComponent<PlayerController>();
         
    }

    // Update is called once per frame
    void Update()
    {
        bonusForce = (playerController.throwForce - 10) * 8;
        GetCurrentFill(bonusForce);
    }

    void GetCurrentFill(float current)
    {
        float fillAmount = current / (float)max;
        mask.fillAmount = fillAmount;
    }
}
