using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;

    public float chaseRange = 5;
    public float attackRange = 2;
    public float speed = 3;
    public int dano;

    public int vida;
    public int vidaMax;

    public Animator animator;

    public bool vivo;

    PlayerGerenciador player;

    InimigoAtaque ataque;

    Collider colisor;

    //Gravidade
    private Vector3 direcaoMovimento;
    public float gravidadeEscala;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        ataque = GetComponentInChildren<InimigoAtaque>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGerenciador>();
        colisor = GetComponent<Collider>();

        vida = vidaMax;
        vivo = true;
    }

    // Update is called once per frame
    void Update()
    {


        
        if(vivo == true)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (currentState == "IdleState")
            {
                if (distance < chaseRange)
                    currentState = "ChaseState";
            }
            else if (currentState == "ChaseState")
            {
                //play the run animation
                animator.SetTrigger("chase");
                animator.SetBool("isAttacking", false);

                if (distance < attackRange)
                    currentState = "AttackState";

                //move towards the player
                if (target.position.x > transform.position.x)
                {
                    //move right
                    transform.Translate(transform.right * speed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    //move left
                    transform.Translate(-transform.right * speed * Time.deltaTime);
                    transform.rotation = Quaternion.identity;
                }

            }
            else if (currentState == "AttackState")
            {
                animator.SetBool("isAttacking", true);
                if (distance > attackRange)
                currentState = "ChaseState";
                
            }
        }  
        if (vida <= 0 && vivo == true)
            {

            morrer();
            
            }
        //direcaoMovimento.y += (Physics.gravity.y * gravidadeEscala) * Time.deltaTime;
        //transform.Translate(direcaoMovimento * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Espada")
        {
            tomarDano(player.danoEspada);
            Debug.Log(player.danoEspada);
        }
    }

    public void morrer()
    {
        animator.SetTrigger("Morreu");
        vivo = false;
        colisor.enabled = false;
        Debug.Log("Morreu");
    }
    public void tomarDano(int danoTomado)
        {
        vida -= danoTomado;
        //animator.SetTrigger("Dano");
        //Debug.Log(vida);
        Debug.Log("Hitou");
    }
}
