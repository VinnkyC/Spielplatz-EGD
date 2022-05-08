using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawner2 : MonoBehaviour
{

    public List<GameObject> spawnObjects;
    public float spawnTime;
    public float spawnDelay;
    public bool startspawning;
    private float timer;
    public int maxSpawnTimes;
    public Vector3 pos;
    int counter = 0;


    void Update()
    {
        if (startspawning)
        {
            counter = 0;
            InvokeRepeating("Spawner", spawnTime, spawnDelay);
            startspawning = false;
        }
    }

    void Spawner()
    {

        if(counter < maxSpawnTimes)
        {

            pos = transform.position;
            int rand = Random.Range(0, 3);
            var prototype = Instantiate(spawnObjects[rand], pos, Quaternion.identity);
            //prototype.GetComponent<MeshRenderer>().sharedMaterial.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            counter++;
        }
        else
        {
            CancelInvoke();
        }
    }
}
