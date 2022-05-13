using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTriggerLaunch : MonoBehaviour
{
    public GameObject ballToLaunch;
    public GameObject spawner;
    public GameObject launcherBoard;
    public int force = 100;
    public bool juicy;

    private AudioSource launchSound;
    GameObject ballClone;
    Color oldColor;
    Rigidbody ballRigid;
    Transform spawnerTransform;
    Transform launchBoardTransform;

    public float launchControlSensitivity;
    bool isLaunchControl = false;
    bool ballReady = false;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn Ball at start
        spawnerTransform = spawner.GetComponent<Transform>();
        launchSound = GetComponent<AudioSource>();
        launchBoardTransform = launcherBoard.GetComponent<Transform>();
        spawnBall();
    }

    private void Update()
    {
        if (isLaunchControl)
        {
            rotateLaunchBoard();

            if (Input.GetKeyDown(KeyCode.F))
            {
                shootingBall();
            }
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        isLaunchControl = true;
        ballReady = true;

        Renderer render = GetComponent<Renderer>();
        if (juicy)
        {
            oldColor = GetComponent<Renderer>().material.color;
            render.material.color = Color.green;
        }
       

    }

    private void OnTriggerExit(Collider other)
    {
        isLaunchControl = false;

        if (juicy)
        {
            Renderer render = GetComponent<Renderer>();
            render.material.color = oldColor;
        }
        if (!ballReady)
        {
            spawnBall();
        }
        
    }

    public void spawnBall()
    {
        ballClone = Instantiate(ballToLaunch, spawnerTransform.position, spawnerTransform.rotation) as GameObject;
        ballRigid = ballClone.GetComponent<Rigidbody>();
    }

    //launchBoard controller
    public void rotateLaunchBoard()
    {
        float angle = launchBoardTransform.localEulerAngles.x;
        angle = (angle > 180) ? angle - 360 : angle;

        if (Input.GetKey(KeyCode.L) && angle <= 10f)
        {
            launchBoardTransform.Rotate(launchControlSensitivity * Time.deltaTime * Vector3.right);
        }

        if (Input.GetKey(KeyCode.O) && angle >= -10f)
        {
            launchBoardTransform.Rotate(launchControlSensitivity * Time.deltaTime * -Vector3.right);
        }

    }

    public void shootingBall()
    {
        if (ballReady)
        {
            Debug.Log("F Pressed");
            launchSound.Play();


            ballRigid.AddForce((-launchBoardTransform.forward) * force, ForceMode.Impulse);
            ballReady = false;
        }
    }
}
