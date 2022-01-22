using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerGerenciador : MonoBehaviour
{

    public int vida;
    public Animator animador;
    //PlayerController player;
    public GameObject player;
    //public int qtdVida;
    public int vidaMax;
    public Collider collider;
    public int danoEspada;
    public bool temChave;
    private Slider barraDeVida;
    public GameObject telaFimDeJogo;
    public bool vulneravel;
    public Animator esqueletoAnim;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        vidaMax = 10;
        vida = vidaMax;
        temChave = false;
        barraDeVida = GameObject.FindGameObjectWithTag("BarraDeVida").GetComponent<Slider>();
        vulneravel = true;
    }

    // Update is called once per frame
    void Update()
    {
        barraDeVida.value = vida;
        Debug.Log(vida);
        //Morrer
        if (vida <= 0)
        {
            mortePlayer(player);
        }
    }

    public void mortePlayer(GameObject player)
    {
        animador.Play("Morte");
        this.player.GetComponent<PlayerController>().enabled = false;
        collider.enabled = false;
        telaFimDeJogo.SetActive(true);
    }
    public void tomarDano(int danoTomado)
    {
        if(vulneravel == true)
        vida -= danoTomado;
    }
}
