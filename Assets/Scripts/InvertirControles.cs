using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertirControles : MonoBehaviour {
    public float velMovimiento = 2.3f;

    private void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") {
            Debug.Log ("Los controles han sido invertidos"); 
            other.GetComponent<MovimientoJugador> ().movimientoEjeX = -Input.GetAxis ("Horizontal") * Time.deltaTime * velMovimiento;
            other.GetComponent<MovimientoJugador> ().movimientoEjeZ = -Input.GetAxis ("Vertical") * Time.deltaTime * velMovimiento;
        }
    }
}