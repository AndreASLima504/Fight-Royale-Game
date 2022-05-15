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

    public void atacar(int danoInfligido)
    {
        danoInfligido = GetComponentInParent<Inimigo>().dano;
        if(gerenciadorPlayer.vulneravel == true)
        gerenciadorPlayer.tomarDano(danoInfligido);
        else
        {
            animador.SetTrigger("Dano");
        }
        Debug.Log("infligiu" + danoInfligido);
    }
}
