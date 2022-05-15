using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class PlayerController : MonoBehaviour
{

    public float velocidadeDeMovimento;
    public float forcaDoPulo;
    public bool noChao;
    public float tamanhoChecagemChao;

    //public Rigidbody rigidbody;
    public Transform checagemChao;
    public LayerMask chaoLayer;
    public LayerMask instakill;
    public Collision colisaoPlayer;

    public CharacterController controlePersonagem;
    private Vector3 direcaoMovimento;
    public float gravidadeEscala;

    //Agregando combate do player
    //PlayerCombate gerenciadorCombate;

    public Animator animador;
    public Transform modelo;
    //private bool morto = false;

    //Combate
    public float danoEspada;
    Collider colisorEspada;
    public GameObject cleiton;
    public bool morto;

    PlayerGerenciador gerenciador;




    void Start()
    {
        //player = GetComponent<Rigidbody>();
        gerenciador = GetComponent<PlayerGerenciador>();
        controlePersonagem = GetComponent<CharacterController>();
        colisorEspada = GetComponent<Collider>();
        //gerenciadorCombate = GetComponentInChildren<PlayerCombate>();
        colisorEspada.enabled = false;
        morto = false;
    }

    void Update()
    {

        float xDirection = Input.GetAxis("Horizontal");

        Vector3 movement = transform.right * xDirection;
        controlePersonagem.Move(movement * velocidadeDeMovimento * Time.deltaTime);



        //Pulo
        noChao = Physics.CheckSphere(checagemChao.position, tamanhoChecagemChao, chaoLayer);
            if (Input.GetButtonDown("Jump") && noChao)
            {
                //direcaoMovimento = new Vector3(controlePersonagem.velocity.x, forcaDoPulo, controlePersonagem.velocity.z);
                direcaoMovimento.y = forcaDoPulo;
                animador.SetTrigger("Pulou");
            }
            if (Input.GetButtonUp("Jump"))
            {
                direcaoMovimento.y = direcaoMovimento.y * 0.5f;
            }

        //Gravidade
        direcaoMovimento.y += (Physics.gravity.y * gravidadeEscala) * Time.deltaTime;
        controlePersonagem.Move(direcaoMovimento*Time.deltaTime);
        if (noChao && direcaoMovimento.y < 0)
            direcaoMovimento.y = -2f;

            //Animações
            animador.SetFloat("Velocidade", Mathf.Abs(Input.GetAxis("Horizontal")));
            animador.SetBool("noChao", noChao);
            animador.SetFloat("VelocidadeVertical", Mathf.Abs(controlePersonagem.velocity.y));
      if(Input.GetButtonDown("Horizontal"))
        {
            animador.SetBool("andando", true);
            if (Input.GetButtonUp("Horizontal"))
            {
                animador.SetBool("andando", false);
            }
        }
            if(Physics.CheckSphere(checagemChao.position, tamanhoChecagemChao, instakill))
            {
                gerenciador.tomarDano(gerenciador.vidaMax);
            }
            //Rotacionar
            if(Input.GetAxis("Horizontal") != 0)
            {
                Quaternion novaRotacao = Quaternion.LookRotation(new Vector3(Input.GetAxis("Horizontal"), 0, 0));
                modelo.rotation = novaRotacao;
            }
        
            //Golpe de espada leve
            if (Input.GetButtonDown("Fire1"))
            {
                animador.SetTrigger("Atacar");

            }
            
        


        



        //Movimento utilizando Character Controller método 1
        //direcaoMovimento = new Vector3(Input.GetAxis("Horizontal") * velocidadeDeMovimento, controlePersonagem.velocity.y, controlePersonagem.velocity.z);
        //if (Input.GetButtonUp("Horizontal"))
        //{
        //    direcaoMovimento.x = direcaoMovimento.x * 0.1f;
        //}


        //Strafe descartado
        //if (Input.GetButtonDown("Vertical"))
        //{
        //    animador.SetFloat("direcaoStrafe", direcaoMovimento.z);
        //    animador.SetBool("strafando", true);
        //}
        //if (Input.GetButtonUp("Vertical"))
        //{
        //    animador.SetBool("strafando", false);
        //}

    }

    
    public void ativarDano()
    {
        colisorEspada.enabled = true;
    }
    public void desativarDano()
    {
        colisorEspada.enabled = false;
    }
}
