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
    public bool ganhouFase;
    public GameObject telaVitoria;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        vidaMax = 10;
        vida = vidaMax;
        temChave = false;
        barraDeVida = GameObject.FindGameObjectWithTag("BarraDeVida").GetComponent<Slider>();
        vulneravel = true;
        ganhouFase = false;
    }

    // Update is called once per frame
    void Update()
    {
        barraDeVida.value = vida;
        //Morrer
        if (vida <= 0)
        {
            animador.Play("Morte");
            this.player.GetComponent<PlayerController>().enabled = false;
            collider.enabled = false;
            Invoke("mortePlayer", 2);
        }

        if (ganhouFase)
        {
            this.player.GetComponentInParent<PlayerController>().enabled = false;
            transform.Rotate(0.0f, 90f, 0.0f);
            animador.SetTrigger("venceu");
            Invoke("vitoria", 2);
            ganhouFase = false;

        }
    }

    public void vitoria()
    {
        
        collider.enabled = false;
        telaVitoria.SetActive(true);
    }

    public void mortePlayer()
    {
        
        telaFimDeJogo.SetActive(true);
    }
    public void tomarDano(int danoTomado)
    {
        if(vulneravel == true)
        vida -= danoTomado;
    }
}
