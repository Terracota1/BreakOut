using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bola : MonoBehaviour
{
    public bool isGameStarted;
    [SerializeField] public float velocidadBola = 12.0f;
    Vector3 ultimaposicion = Vector3.zero;
    Vector3 direccion = Vector3.zero;
    Rigidbody rigidBody;
    private Control_Bordes control;
    public UnityEvent BolaDestruida;

    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<Control_Bordes>();
        isGameStarted = false;
        Vector3 posicionInicial = GameObject.FindGameObjectWithTag("Jugador").transform.position;
        posicionInicial.y += 2;
        this.transform.position = posicionInicial;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Jugador").transform);
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (control.salioAbajo)
        {
            BolaDestruida.Invoke();
            Destroy(this.gameObject);
        }

        if (control.salioArriba)
        {
            direccion = transform.position - ultimaposicion;
            Debug.Log("La bola toco el borde superior");
            direccion.y *= -1;
            direccion = direccion.normalized;
            rigidBody.velocity = velocidadBola * direccion;
            control.salioArriba = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.2f);
        }

        if (control.salioDerecha)
        {
            direccion = transform.position - ultimaposicion;
            Debug.Log("La bola toco el borde derecho");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidBody.velocity = velocidadBola * direccion;
            control.salioDerecha = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.2f);
        }

        if (control.salioIzquierda)
        {
            direccion = transform.position - ultimaposicion;
            Debug.Log("La bola toco el borde izquierdo");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidBody.velocity = velocidadBola * direccion;
            control.salioIzquierda = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.2f);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Submit")) 
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                this.transform.SetParent(null);
                GetComponent<Rigidbody>().velocity = velocidadBola * Vector3.up;
            }
        }
        
    }

    private void HabilitarControl()
    {
        control.enabled = true;
    }

    private void FixedUpdate()
    {
        ultimaposicion = transform.position;
    }

    private void LateUpdate()
    {
        if (direccion != Vector3.zero) direccion = Vector3.zero;
    }

}
