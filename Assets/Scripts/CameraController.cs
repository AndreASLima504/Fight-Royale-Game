using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    public float velocidadeSuave = 0.5f;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = target.position + offset;
        Vector3 posicaoDesejada = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, posicaoDesejada, velocidadeSuave);
    }
}
