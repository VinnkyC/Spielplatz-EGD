using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelloaderScript : MonoBehaviour
{

    public Animator transition;
    [SerializeField] float transitionTime = 1f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Debug.Log("Stufe1");
            StartCoroutine(LoadLevel(0));
        }
        else if (Input.GetKeyDown("2"))
        {
            Debug.Log("Stufe2");
            StartCoroutine(LoadLevel(1));
        }
        else if (Input.GetKeyDown("3"))
        {
            Debug.Log("Stufe3");
            StartCoroutine(LoadLevel(2));
        }
    }

     IEnumerator LoadLevel(int pLevelID)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load Scene
        SceneManager.LoadScene(pLevelID);
    }
}
