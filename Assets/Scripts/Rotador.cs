using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour {
    float velRotacion = 10f; // velRotacion define la velocidad de las monedas

    void Update() { // Upadte se ejecuta por cada frame de juego
        transform.Rotate(0.0f, Time.deltaTime * velRotacion, 0f); // La moneda rota sobre su eje un número de veces deifinido por velRotacion
    }
}