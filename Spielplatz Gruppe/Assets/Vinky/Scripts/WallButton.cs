using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ballToLaunch;
    public GameObject spawner;
    public int force;
    public float launchWaitTime;

    private AudioSource launchSound;
    GameObject ballClone;
    Color oldColor;
    Rigidbody ballRigid;
    Transform spawnerTransform;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn Ball at start
        spawnerTransform = spawner.GetComponent<Transform>();
        launchSound = GetComponent<AudioSource>();
        spawnBall();
    }

    private void Update()
    {
        //Spawn ball after old ball is destroyed
        if (GameObject.FindGameObjectWithTag("BallSpawner") == null)
        {
            spawnBall();
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    StartCoroutine(colorChange());
    //    if (GameObject.FindGameObjectWithTag("ballspawner") == null)
    //    {
    //        spawnBall();
    //    }
    //}


    public void launchBall()
    {
        StartCoroutine(colorChange());
        StartCoroutine(launch());
    }

    public void spawnBall()
    {
        ballClone = Instantiate(ballToLaunch, spawnerTransform.position, spawnerTransform.rotation) as GameObject;
        ballRigid = ballClone.GetComponent<Rigidbody>();
    }

    IEnumerator colorChange()
    {
        Renderer render = GetComponent<Renderer>();
        oldColor = GetComponent<Renderer>().material.color;
        render.material.color = Color.green;

        yield return new WaitForSeconds(0.1f);

        render.material.color = oldColor;

    }
    IEnumerator launch()
    {
        yield return new WaitForSeconds(launchWaitTime);
        if (GameObject.FindGameObjectWithTag("BallSpawner") != null)
        {
            launchSound.Play();
            int randomForce = Random.Range(20, force);
            ballRigid.AddForce(Vector3.back * randomForce, ForceMode.Impulse);
        }
    }
}
