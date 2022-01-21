using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class PlayerController : MonoBehaviour
{
    public float velocidadeDeMovimento;
    public float forcaDoPulo;
    //public Rigidbody rigidbody;
    public Transform checagemChao;
    public LayerMask chaoLayer;
    public LayerMask instakill;
    public Collision colisaoPlayer;

    public CharacterController controlePersonagem;
    private Vector3 direcaoMovimento;
    public float gravidadeEscala;
    
    
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
        colisorEspada.enabled = false;
        morto = false;
    }

    void Update()
    {

        
            //Movimento utilizando Character Controller
            direcaoMovimento = new Vector3(Input.GetAxis("Horizontal") * velocidadeDeMovimento, controlePersonagem.velocity.y, controlePersonagem.velocity.z);
            if (Input.GetButtonUp("Horizontal"))
            {
                direcaoMovimento.x = direcaoMovimento.x * 0.1f;
            }
            if (Input.GetButtonDown("Vertical"))
            {
                animador.SetFloat("direcaoStrafe", direcaoMovimento.z);
                animador.SetBool("strafando", true);
            }
            if (Input.GetButtonUp("Vertical"))
            {
                animador.SetBool("strafando", false);
            }
            

                //Pulo
                bool noChao = Physics.CheckSphere(checagemChao.position, 0.20f, chaoLayer);
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

            //Animações
            animador.SetFloat("Velocidade", Mathf.Abs(Input.GetAxis("Horizontal")));
            animador.SetBool("noChao", noChao);
            animador.SetFloat("VelocidadeVertical", Mathf.Abs(controlePersonagem.velocity.y));
      
            if(Physics.CheckSphere(checagemChao.position, 0.20f, instakill))
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
            
        


        
        //Gravidade
        direcaoMovimento.y += (Physics.gravity.y * gravidadeEscala) * Time.deltaTime;
        controlePersonagem.Move(direcaoMovimento*Time.deltaTime);




        //direcaoDeMovimento = new Vector3(Input.GetAxis("Horizontal") * velocidadeDeMovimento, player.velocity.y, player.velocity.z);
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
