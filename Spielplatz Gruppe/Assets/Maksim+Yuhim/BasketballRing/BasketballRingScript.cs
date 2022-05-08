using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketballRingScript : MonoBehaviour
{
    private bool topColliderFirst = false;
    public int basketBallPoints = 0;
    public GameObject basketballPointsText;
    public AudioSource PointSFX;
    // Start is called before the first frame update
    public void Start()
    {
        basketballPointsText = GameObject.FindWithTag("BasketballPointsText");
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TopBasketballCollider")
        {
            if(!topColliderFirst)
                topColliderFirst = true;
            
        }
        if(other.tag == "BotBasketballCollider")
        {
            if(topColliderFirst)
            {
                basketBallPoints++;
                PointSFX.Play();
                basketballPointsText.GetComponent<Text>().text = "Basketball Points: " +  basketBallPoints.ToString();
                topColliderFirst = false;
            }
        }
    }
}
