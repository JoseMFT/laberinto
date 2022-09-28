using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectorMeta : MonoBehaviour {

    [SerializeField]
    GameObject pantallaFinal;
    [SerializeField]
    TextMeshProUGUI textTiempo;

    float DetectorTiempo = 0.0f;
    bool Jugando = true;

    private void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") {
            Debug.Log ("Jugador llegó a la meta");
            textTiempo.text = DetectorTiempo.ToString();
            pantallaFinal.SetActive (true);
            other.GetComponent<MovimientoJugador> ().enabled = false;
            Jugando = false;            
        }
    }

    private void Update () {
        if (Jugando == true) {
            DetectorTiempo = DetectorTiempo + Time.deltaTime;
        }        
    }
}
