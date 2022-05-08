using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTriggerLaunch : MonoBehaviour
{
    public GameObject ballToLaunch;
    public GameObject spawner;
    public int force = 100;
    public bool juicy;

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

    private void OnTriggerEnter(Collider other)
    {
        launchSound.Play();
        Renderer render = GetComponent<Renderer>();
        if (juicy)
        {
            oldColor = GetComponent<Renderer>().material.color;
            render.material.color = Color.green;
        }
        ballRigid.AddForce(Vector3.forward * force, ForceMode.Impulse);
    }

    private void OnTriggerExit(Collider other)
    {

        if (juicy)
        {
            Renderer render = GetComponent<Renderer>();
            render.material.color = oldColor;
        }
        spawnBall();
    }

    public void spawnBall()
    {
        ballClone = Instantiate(ballToLaunch, spawnerTransform.position, spawnerTransform.rotation) as GameObject;
        ballRigid = ballClone.GetComponent<Rigidbody>();
    }
}
