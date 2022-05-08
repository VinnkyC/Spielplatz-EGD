using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;


    private void FixedUpdate()
    {
        //Richtungseinabe des Spielers in zwei Variablen speichern
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Referenz auf die Rigidbody Komponente des Game Objects holen
        Rigidbody myRigidbody = gameObject.GetComponent<Rigidbody>();

        //Kraftvektor mit gew�nschter Richtung erstellen
        Vector3 direction = new Vector3(h, 0f, v);

        //Kraft auf den Rigidbody aus�ben
        //Der Kraftvektor wird mit der einstellbaren Variablen <speed> multipliziert (h�here Kraft bei h�her eingestelltem <speed> Wert
        myRigidbody.AddForce(direction * speed);

    }
}
