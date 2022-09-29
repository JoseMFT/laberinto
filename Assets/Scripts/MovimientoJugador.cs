using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // La librer�a TMPro nos permitir� acceder a los TextMeshPro desde los scripts

public class MovimientoJugador : MonoBehaviour {
    [SerializeField]
    GameObject IndicadorInvertido; // IndicadorInvertido ser� un canvas que aplicar� un filtro amarillo a la pantalla
    [SerializeField]
    TextMeshProUGUI textCoins; // Coins es un texto que mostrar� el n�mero de monedas recogidas al final de la partida

    public float movimientoEjeX; // Representa el eje X
    public float movimientoEjeY; // Representa el eje Y
    public float movimientoEjeZ; // Representa el eje Z
    public float velMovimiento = 2.3f; // define la velocidad de movimiento
    public float sentido = 1f; // Define el sentido en el que se desplaza el cubo
    double tiempoInvertido = 5.0d; // Representa el tiempo que pasar� el jugador con los controles invertidos
    bool controlesInvertidos = false; // Representa si los controles han sido invertidos o no
    int contadorMonedas = 0; // Cuenta el n�mero de monedas que el jugador recoge a lo largo de la partida

    void Update () {
        movimientoEjeX = Input.GetAxis ("Horizontal") * Time.deltaTime * velMovimiento; // Adoptar� un valor definido por el eje horizontal, Time.deltaTime, y la velocidad de movimiento
        movimientoEjeZ = Input.GetAxis ("Vertical") * Time.deltaTime * velMovimiento; // Adoptar� un valor definido por el eje verical, Time.deltaTime, y la velocidad de movimiento
        transform.Translate (sentido * movimientoEjeX, movimientoEjeY, sentido * movimientoEjeZ); // El movimiento ser� aplicado al objeto, dependiendo del sentido ser� normal o invertido
        if (controlesInvertidos == true) { // Si los controles han sido invertidos:
            tiempoInvertido = tiempoInvertido - Time.deltaTime; // El tiempo que pasar�n invertidos comenzar� a disminuir            
            if (tiempoInvertido < 0.0d) { // Si el tiempo invertido llega a 0:
                Debug.Log ("Los controles ya no est�n invertidos"); // Aparecer� un mensaje en la consola que diga "Los controles ya no est�n invertidos"
                sentido = 1f; // El sentido vuelve a ser el normal
                tiempoInvertido = 5.0d; // El tiempoInvertido volver� a su valor incial, por si el jugador hace contacto con otra trampa
                controlesInvertidos = false; // controlesInvertidos pasar� a ser falsa, el bloque dejar� de ejecutarse
                IndicadorInvertido.SetActive (false); // El canvas que aplica el filtro desparecer�
            }
        }
    }

    void OnTriggerEnter (Collider other) { // Detecta si el jugador ha hecho contacto con algo
        if (other.tag == "Respawn") { // Si ese algo tiene el tag "Respawn" (que es el que he aplicado a las trampas):
            sentido = -1f; // El sentido ser� negativo, los controles se invertir�n
            Debug.Log ("Los controles han sido invertidos"); // Aparecer� un mensaje en la consola que diga "Los controles han sido invertidos"
            controlesInvertidos = true; // Controles invertidos pasar� a ser verdadera
            IndicadorInvertido.SetActive (true); // Se aplicar� el canvas con el filtro amarillo
        }
        if (other.tag == "Coin") { // Si ese algo tiene el tag "Coin" (que he creado n�nicamente para las monedas):
            contadorMonedas++; // contadorMonedas aumentar� una unidad 
            Debug.Log ("+1 monedas"); // Aparecer� un mensaje en la consola que diga "+1 monedas"
        }
        if (other.tag == "Finish") { // Si ese algo tiene el tag "Finish" (que he aplicado sobre la meta):
            textCoins.text = contadorMonedas.ToString (); // Se mostrar� el n�mero de monedas recogidas en la caja de texto Coins, que aparecer� una vez finalizada la partida
        }
    }
}