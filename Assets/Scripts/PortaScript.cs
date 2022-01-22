using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaScript : MonoBehaviour
{
    public AudioSource fonteAudio;
    public AudioClip hihiha;
    Collider colisao;
    PlayerGerenciador player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGerenciador>();
        colisao = GetComponent<Collider>();
        //Debug.Log(colisao, player);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.temChave)
        {
            abrir();
        }
    }

    void abrir()
    {
        colisao.enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Espada")
        {
            
            Debug.Log("hihihiha");
            fonteAudio.PlayOneShot(hihiha);
            
        }
    }
}
