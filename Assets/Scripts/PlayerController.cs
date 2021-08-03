using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float rotationSpeed = 100;
    public float jumpForce = 7.5f;
    public float throwForce = 10;
    public float sensitivity = 50f;

    private float horizontalInput;
    private float verticalInput;
    private float verticalLook;

    private bool isJumpAvalible;
    public bool isBallKept;

    private Rigidbody playerRb;
    private Rigidbody ballRb;

    public GameObject ball;

    private Camera cam;
    private GameManager gameManager;

    void Start()
    {
        isJumpAvalible = true;
        playerRb = GetComponent<Rigidbody>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cam.transform.position = transform.position + new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        FindBall();
        ThrowTheBall();
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(1.5f);
        isJumpAvalible = true;
    }

    private void Movement()
    {

        if(gameManager.gameMode != 1)
        {
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime); 
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotationSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isJumpAvalible)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumpAvalible = false;
            StartCoroutine(Jump());
        }

        CameraOperator();
    }

    private void CameraOperator()
    {
        if (!gameManager.isPaused)
        {
            if (cam.transform.rotation.x < 0.46f && cam.transform.rotation.x > -0.46f)
            {
                verticalLook = -Input.GetAxis("Mouse Y") * sensitivity;
                cam.transform.Rotate(verticalLook, 0, 0);
            }
            if (cam.transform.rotation.x >= 0.45f)
            {
                cam.transform.Rotate(0.5f, 0, 0);
            }
            if (cam.transform.rotation.x <= -0.45f)
            {
                cam.transform.Rotate(-0.5f, 0, 0);
            }
        }  
    }

    private void FindBall()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballRb = ball.GetComponent<Rigidbody>();

        if (isBallKept)
        {
            ball.transform.position = cam.transform.position + cam.transform.forward * 2;
        }
    }
    private void ThrowTheBall()
    {
        
        if (Input.GetMouseButton(0) && throwForce <= 22.5f && isBallKept)
        {
            throwForce += (Time.deltaTime * 8);
        }
        if (Input.GetMouseButtonUp(0) && isBallKept)
        {
            ballRb.useGravity = true;
            ball.GetComponent<AudioSource>().enabled = true;
            isBallKept = false;
            ballRb.AddForce(cam.transform.forward * throwForce, ForceMode.Impulse);
            throwForce = 10;
        }
    }
}
