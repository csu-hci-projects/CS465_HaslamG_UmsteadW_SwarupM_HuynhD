using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanish : MonoBehaviour
{
    private Renderer rend;
    private Collider coli;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        coli = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") || other.CompareTag("GameControllerGame"))
        {
            rend.enabled = false;
            coli.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand") || other.CompareTag("GameController"))
        {
            rend.enabled = true;
            coli.enabled = true;
        }
    }
}
