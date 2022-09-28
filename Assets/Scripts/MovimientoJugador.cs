using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour {
    [SerializeField]
    GameObject IndicadorInvertido;

    public float movimientoEjeX;
    public float movimientoEjeY;
    public float movimientoEjeZ;
    public float velMovimiento = 2.3f;
    public float sentido = 1f;
    double tiempoInvertido = 5.0d;
    bool controlesInvertidos = false;

    // Update is called once per frame
    void Update () {
        movimientoEjeX = Input.GetAxis ("Horizontal") * Time.deltaTime * velMovimiento;
        movimientoEjeZ = Input.GetAxis ("Vertical") * Time.deltaTime * velMovimiento;
        transform.Translate (sentido * movimientoEjeX, movimientoEjeY, sentido * movimientoEjeZ);
        if (controlesInvertidos == true) {
            tiempoInvertido = tiempoInvertido - Time.deltaTime;            
            if (tiempoInvertido < 0.0d) {
                Debug.Log ("Los controles ya no están invertidos");
                sentido = 1f;
                tiempoInvertido = 5.0d;
                controlesInvertidos = false;
                IndicadorInvertido.SetActive (false);
            }
        }
    }

    void OnTriggerEnter (Collider other) {
        if (other.tag == "Respawn") {
            sentido = -1f;
            Debug.Log ("Los controles han sido invertidos");
            controlesInvertidos = true;
            IndicadorInvertido.SetActive (true);
        }
    }
}