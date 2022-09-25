using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movible : MonoBehaviour {

    bool vuelta = false;
    [SerializeField]
    float velMovimiento = 1.5f;
    // Update is called once per frame
    private void Update()
    {
        void OnCollisionEnter(Collision choque)
        {
            if (vuelta == true)
            {
                transform.Translate(-1f * velMovimiento, 0f, 0f);
                if (choque.gameObject.tag != "Player")
                {
                    vuelta = false;
                }
            }

            if (choque.gameObject.tag != "Player")
            {
                vuelta = true;
            }

        }

        transform.Translate(1f * velMovimiento, 0f, 0f);
    }
    }

