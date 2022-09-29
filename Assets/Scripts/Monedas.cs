using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour {

    [SerializeField] 
    GameObject Moneda; 
    [SerializeField]
    public float velocidadMoneda = 75f; // define la velocidad de la moneda. Manipulable desde unity
    
    void Update () { // El update hace rotar la moneda mediante transform.Rotate de forma cosntante

        transform.Rotate (0.0f, 0.0f, velocidadMoneda * Time.deltaTime); // La moneda gira a una velocidad constante definida por velocidadMoneda
    }
    
    void OnTriggerEnter (Collider other) { //El objeto entra en contacto con algo

        if (other.tag == "Player") { // Si es el jugador:
            Moneda.SetActive (false); // El objeto escogido como Moneda se desactiva y desaparece
        }
    }
}
