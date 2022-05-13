using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehaviour : MonoBehaviour
{
    public List<GroundType> GroundTypes = new List<GroundType>();
    public GameObject firstPersonController;
    public string currentGround;

    private FirstPersonAudio firstPersonAudio;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonAudio = GetComponent<FirstPersonAudio>();
        setGroundType(GroundTypes[0]);
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        DetectGround();
    }


    public void setGroundType(GroundType ground)
    {
        if(currentGround != ground.name)
        {
            firstPersonAudio.stepAudio.clip = ground.footstepSounds;
            firstPersonAudio.runningAudio.clip = ground.runningSound;

           //ground.initializeLandingSFX();
            firstPersonAudio.landingSFX = ground.landingSFX;
            currentGround = ground.name;
        }
    }

    public void DetectGround()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit,2))
        {
            if (hit.collider.tag =="Terrain")
                setGroundType(GroundTypes[1]);
            //Here put more Ground Tags
            else if (hit.collider.tag == "Wood")
                setGroundType(GroundTypes[2]);
            else
                setGroundType(GroundTypes[0]);
        }
    }
}

[System.Serializable]
public class GroundType
{
    public string name;

    public AudioClip footstepSounds;
    public AudioClip runningSound;

    //Need 3 AudioClips
    public AudioClip[] landingSFX;

}