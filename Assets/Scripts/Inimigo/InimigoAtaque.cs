using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAtaque : MonoBehaviour
{
    PlayerGerenciador gerenciadorPlayer;
    Inimigo inimigo;
    // Start is called before the first frame update
    void Start()
    {
        inimigo = GetComponentInParent<Inimigo>();
        gerenciadorPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGerenciador>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void atacar(int danoInfligido)
    {
        if()
        gerenciadorPlayer.tomarDano(danoInfligido);
    }
}
