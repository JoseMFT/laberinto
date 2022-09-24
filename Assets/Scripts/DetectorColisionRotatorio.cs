using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorColisionRotatorio : MonoBehaviour
{
    [SerializeField]
    Material murosRotatorios;
    [SerializeField]
    Material choqueRotatorios;
    [SerializeField]

    bool colorChoque = false;
    double tiempoChoque = 0.5d;

    private void Update()
    {
        if (colorChoque == true)
        {
            tiempoChoque = tiempoChoque - Time.deltaTime;
            if (tiempoChoque < 0.0d)
            {

                gameObject.GetComponent<MeshRenderer>().material = murosRotatorios;
                colorChoque = false;
                tiempoChoque = 0.5d;
            }

        }

    }
    private void OnCollisionEnter(Collision choque)
    {

        if (choque.gameObject.tag == "Player")
        {
            Debug.Log(choque.gameObject.name);
            gameObject.GetComponent<MeshRenderer>().material = choqueRotatorios;

            colorChoque = true;

        }
    }
}

