using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModusKlick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
             Debug.Log("Stufe1");
        }
        else if (Input.GetKeyDown("2"))
        {
             Debug.Log("Stufe2");
        }
        else if (Input.GetKeyDown("3"))
        {
             Debug.Log("Stufe3");
        }
        
    }



}
