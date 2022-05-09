using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehaviour : MonoBehaviour
{
    public List<GroundType> GroundTypes = new List<GroundType>();
    public GameObject firstPersonController;
    public string currentGround;

    private FirstPersonAudio firstPersonAudio;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonAudio = GetComponent<FirstPersonAudio>();
        setGroundType(GroundTypes[0]);
    }

    // Update is called once per frame
    void Update()
    {
        DetectGround();
    }

    /*private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Terrain"))
            setGroundType(GroundTypes[1]);
        else if (hit.transform.tag == "Grass")
            setGroundType(GroundTypes[2]);
        else
            setGroundType(GroundTypes[0]);
    }*/

    public void setGroundType(GroundType ground)
    {
        if(currentGround != ground.name)
        {
            firstPersonAudio.stepAudio = ground.footstepSounds;
            firstPersonAudio.runningAudio = ground.runningSound;
            currentGround = ground.name;
        }
    }

    public void DetectGround()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag =="Terrain")
                setGroundType(GroundTypes[1]);
            /*else if (hit.collider.tag == "Grass")
                setGroundType(GroundTypes[2]);*/
            else
                setGroundType(GroundTypes[0]);
        }
    }
}

[System.Serializable]
public class GroundType
{
    public string name;

    public AudioSource footstepSounds;
    public AudioSource runningSound;
}