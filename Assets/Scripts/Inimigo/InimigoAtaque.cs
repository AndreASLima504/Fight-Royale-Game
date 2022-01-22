using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAtaque : MonoBehaviour
{
    PlayerGerenciador gerenciadorPlayer;
    Inimigo inimigo;
    public Animator animador;

    // Start is called before the first frame update
    void Start()
    {
        inimigo = GetComponentInParent<Inimigo>();
        gerenciadorPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGerenciador>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gerenciadorPlayer);
    }
    public void atacar(int danoInfligido)
    {
        if(gerenciadorPlayer.vulneravel == true)
        gerenciadorPlayer.tomarDano(danoInfligido);
        else
        {
            animador.SetTrigger("Dano");
        }
    }
}
