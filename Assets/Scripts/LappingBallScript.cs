using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LappingBallScript : MonoBehaviour
{
    public float lapSpeed = 45;
    private GameObject centerPoint;

    // Start is called before the first frame update
    void Start()
    {
        centerPoint = GameObject.Find("CenterPoint");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(centerPoint.transform.position, Vector3.down, lapSpeed * Time.deltaTime);
    }
}
