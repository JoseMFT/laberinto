using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // La librería TMPro nos permite acceder a los text mesh pro desde los scripts

public class DetectorMeta : MonoBehaviour {
 
    [SerializeField]    // pantallaFinal será el canvas con la pantalla final que, por defecto, se encuentra desactivado
    GameObject pantallaFinal;
    [SerializeField]     // Tiempo es un text mesh que se encuentra también en el juego, pero que debemos declarar para poder utilizar
    TextMeshProUGUI textTiempo;

    float DetectorTiempo = 0.0f; // La variable flotatnte DetectorTiempo representa el tiempo que tarda  el jugador en llegar a la meta
    bool Jugando = true;  // La variable booleana Jugando representa si la partida ha acabado o no
        
    private void OnTriggerEnter (Collider other) { // Algo hace contacto con la meta
                                                   // 
        if (other.tag == "Player") { // Si ese algo tiene el tag "Player" (solo aplicado sobre el jugador):
            Debug.Log ("Jugador llegó a la meta"); // Aparecerá este texto en la consola de debug
            textTiempo.text = DetectorTiempo.ToString(); // La variable DetectorTiempo se convertirá en un string y aparecerá en el text mesh Tiempo
            pantallaFinal.SetActive (true); // Se activará finalmente el canvas de pantallaFinal
            other.GetComponent<MovimientoJugador> ().enabled = false; // El jugador no podrá moverse de este momento
            Jugando = false;  //  La partida acabará         
        }
    }

    private void Update () {

        if (Jugando == true) { // Si la partida no ha acabado:
            DetectorTiempo = DetectorTiempo + Time.deltaTime; // DetectorTiempo seguirá aumentando
        }        
    }
}
