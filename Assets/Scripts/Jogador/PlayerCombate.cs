using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombate : MonoBehaviour
{
    public Animator animador;
    Collider colisorEspada;
    CharacterController controlePersonagem;
    
    // Start is called before the first frame update
    void Start()
    {
        colisorEspada = GetComponentInChildren<Collider>();
        colisorEspada.enabled = false;
        controlePersonagem = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animador.SetTrigger("Atacar");
        }
        if (Input.GetButtonDown("Fire2"))
        {

        }
    }
    //Eventos de animação
    public void ativarDano()
    {
        colisorEspada.enabled = true;
    }
    public void desativarDano()
    {
        colisorEspada.enabled = false;
    }

    public void desativarMovimento()
    {
        controlePersonagem.enabled = false;
    }

    public void ativarMovimento()
    {
        controlePersonagem.enabled = true;
    }

    public void Aparar()
    {

    }
    //private void OnTriggerEnter(Collider outro)
    //{

    //    if (outro.gameObject.tag == "Inimigo")
    //    {
    //        
    //        outro.GetComponent<Inimigo>().tomarDano(danoEspada);
    //    }
    //}
}
