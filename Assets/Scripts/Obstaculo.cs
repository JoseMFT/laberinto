using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour {
    public float desplazamientoX = 1.5f; // desplazamientoX definirá el número de unidades que el bloque recorrerá por cada frame (velocidad)
    float vuelta = 0.25f; // vuelta indicará el sentido hacia el que se desplazará el bloque
    public float distancia = 0.0f; // distancia definirá el principio y final del recorrido

    private void Update () {
        if (distancia > 10f) { // Si distancia es superior a 10:
            vuelta = -0.25f; // El sentido será negativo

        }
        if (distancia < -10f) { // Si distancio es inferior a -10
            vuelta = 0.25f; // El sentido será positivo

        }
        desplazamientoX = desplazamientoX * Time.deltaTime * vuelta; // desplazamientoX se multiplica por el tiempo para no variar según la máquina que lo ejecuta, y su sentido es definido por vuelta.
        distancia = distancia + desplazamientoX * 7.5f; // distancia se suma a sí misma (su valor previo) junto con el desplazamiento multiplicado por 7,5 (el valor de este se vuelve muy pequeño al multiplicarse por Time.deltaTime
        transform.Translate (desplazamientoX, 0f, 0f); // El objeto se mueve el número de unidades definidas por el desplazamiento
        desplazamientoX = 1.5f; // desplazamiento vuelve a su valor inicial, ya que de no ser así decrecería exponencialmente y el objeto se realentizaría cada vez más
        }
}
