using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocha : MonoBehaviour
{
    Collider colisor;
    Rigidbody rigidbody;
    private Transform jogador;
    PlayerGerenciador player;
    public GameObject cleiton;

    // Start is called before the first frame update
    void Start()
    {
        colisor = GetComponent<Collider>();
        cleiton = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGerenciador>();
        rigidbody = GameObject.FindGameObjectWithTag("Rocha").GetComponent<Rigidbody>();
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jogador.position);
        if(distancia < 10)
        {
            rigidbody.isKinematic = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.mortePlayer(cleiton);
        }
    }
}
