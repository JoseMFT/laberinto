using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // La librer�a TMPro nos permite acceder a los text mesh pro desde los scripts

public class DetectorMeta : MonoBehaviour {
 
    [SerializeField]    // pantallaFinal ser� el canvas con la pantalla final que, por defecto, se encuentra desactivado
    GameObject pantallaFinal;
    [SerializeField]     // Tiempo es un text mesh que se encuentra tambi�n en el juego, pero que debemos declarar para poder utilizar
    TextMeshProUGUI textTiempo;

    float DetectorTiempo = 0.0f; // La variable flotatnte DetectorTiempo representa el tiempo que tarda  el jugador en llegar a la meta
    bool Jugando = true;  // La variable booleana Jugando representa si la partida ha acabado o no
        
    private void OnTriggerEnter (Collider other) { // Algo hace contacto con la meta
                                                   // 
        if (other.tag == "Player") { // Si ese algo tiene el tag "Player" (solo aplicado sobre el jugador):
            Debug.Log ("Jugador lleg� a la meta"); // Aparecer� este texto en la consola de debug
            textTiempo.text = DetectorTiempo.ToString(); // La variable DetectorTiempo se convertir� en un string y aparecer� en el text mesh Tiempo
            pantallaFinal.SetActive (true); // Se activar� finalmente el canvas de pantallaFinal
            other.GetComponent<MovimientoJugador> ().enabled = false; // El jugador no podr� moverse de este momento
            Jugando = false;  //  La partida acabar�         
        }
    }

    private void Update () {

        if (Jugando == true) { // Si la partida no ha acabado:
            DetectorTiempo = DetectorTiempo + Time.deltaTime; // DetectorTiempo seguir� aumentando
        }        
    }
}
