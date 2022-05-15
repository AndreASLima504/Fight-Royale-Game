using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vitoriaScript : MonoBehaviour
{
    PlayerGerenciador gerenciador;

    // Start is called before the first frame update
    void Start()
    {
        gerenciador = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGerenciador>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gerenciador.ganhouFase = true;
        }
    }
}
