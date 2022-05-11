using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeAndThrow : MonoBehaviour
{
    public int GRABI;
    public float grabPower = 10.0f;
    public float throwPower = 10f;   //скорость толчка
    public float RayDistance = 30.0f;   //дистанция

    private bool Grab = false;   //ф-ция притяжения
    private bool Throw = false;   //ф-ция толчка
    public Transform offset;
    public Camera camera;
    RaycastHit hit;   //луч
    public AudioSource buttonPushSFX;
    public AudioSource PingSFX;


    public Spawner2 spawner2;

    //LevelLoader
    public Animator transition;
    [SerializeField] float transitionTime = 0.5f;

    private void Start()
    {
        GRABI = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, RayDistance);
            if (hit.rigidbody)
            {
                GRABI = GRABI + 1;
                switch (GRABI)
                {
                    case 1:
                        Grab = true;
                        break;
                    case 2:
                        Grab = false;
                        break;
                    default:
                        break;
                }
                if (GRABI > 2)
                {
                    GRABI = 0;
                }
                if (Grab == false)
                {
                    GRABI = 0;
                }
            }
            if (hit.transform)
            {
                if (hit.transform.gameObject.tag == "Button")
                {
                    spawner2.startspawning = true;
                    buttonPushSFX.Play();
                    hit.transform.gameObject.AddComponent<Rigidbody>();
                }
                if (hit.transform.gameObject.tag == "Paint")
                {
                    hit.transform.gameObject.AddComponent<Rigidbody>();
                    hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(10, 100), 0, 0));
                    PingSFX.Play();
                }
                if (hit.transform.gameObject.tag == "stufe1")
                {
                    Debug.Log("Stufe1");
                    StartCoroutine(LoadLevel(0));
                }
                else if (hit.transform.gameObject.tag == "stufe2")
                {
                    Debug.Log("Stufe2");
                    StartCoroutine(LoadLevel(1));
                }
                else if (hit.transform.gameObject.tag == "stufe3")
                {
                    Debug.Log("Stufe3");
                    StartCoroutine(LoadLevel(2));
                }
            }

            Debug.Log(GRABI);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Grab)
            {
                GRABI = 0;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {//если нажата лев кн мыши
            if (Grab)
            {
                Grab = false;
                Throw = true;
            }

            //fix here can't throw ball 
          /*  Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, RayDistance);
            if (hit.transform)
            {
                if (hit.transform.gameObject.tag == "Paint")
                {
                    hit.transform.gameObject.AddComponent<Rigidbody>();
                    hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(10, 100), 0, 0));
                    PingSFX.Play();
                }
            }*/
        }

        if (Grab)
        {//ф-ция притяжения
            if (hit.rigidbody)
            {
                hit.rigidbody.velocity = (offset.position - (hit.transform.position + hit.rigidbody.centerOfMass)) * grabPower;

            }
        }

        if (Throw)
        {//ф-ция толчка
            if (hit.rigidbody)
            {
                hit.rigidbody.velocity = camera.ScreenPointToRay(Input.mousePosition).direction * throwPower;
                Throw = false;
            }
        }
    }

    private void Grabb()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, RayDistance);
        if (hit.rigidbody)
        {
            Grab = true;
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