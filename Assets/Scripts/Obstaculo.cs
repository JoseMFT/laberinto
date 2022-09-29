using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour {
    public float desplazamientoX = 1.5f; // desplazamientoX definir� el n�mero de unidades que el bloque recorrer� por cada frame (velocidad)
    float vuelta = 0.25f; // vuelta indicar� el sentido hacia el que se desplazar� el bloque
    public float distancia = 0.0f; // distancia definir� el principio y final del recorrido

    private void Update () {
        if (distancia > 10f) { // Si distancia es superior a 10:
            vuelta = -0.25f; // El sentido ser� negativo

        }
        if (distancia < -10f) { // Si distancio es inferior a -10
            vuelta = 0.25f; // El sentido ser� positivo

        }
        desplazamientoX = desplazamientoX * Time.deltaTime * vuelta; // desplazamientoX se multiplica por el tiempo para no variar seg�n la m�quina que lo ejecuta, y su sentido es definido por vuelta.
        distancia = distancia + desplazamientoX * 7.5f; // distancia se suma a s� misma (su valor previo) junto con el desplazamiento multiplicado por 7,5 (el valor de este se vuelve muy peque�o al multiplicarse por Time.deltaTime
        transform.Translate (desplazamientoX, 0f, 0f); // El objeto se mueve el n�mero de unidades definidas por el desplazamiento
        desplazamientoX = 1.5f; // desplazamiento vuelve a su valor inicial, ya que de no ser as� decrecer�a exponencialmente y el objeto se realentizar�a cada vez m�s
        }
}
