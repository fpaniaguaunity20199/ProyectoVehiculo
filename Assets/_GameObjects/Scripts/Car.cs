using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public WheelCollider[] ruedasMotrices;
    public WheelCollider[] ruedasDirectrices;
    public WheelCollider[] ruedasFrenado;
    [Range(1, 1000)]
    public float potencia = 1;
    [Range(1, 10)]
    public float multiplicadorGiro = 1;
    [Range(1, 10000)]
    public float fuerzaFrenado = 1;
    float dir;//dirección
    float acc;//aceleración
    bool frenoDeMano = false;
    //PARA EL TUBARRO
    public GameObject tubarros;
    //PARA LA LUZ DE FRENO
    public GameObject lucesFreno;
    private Material materialFrenado;
    private Material materialLuzFrenoOriginal;

    private void Start()
    {
        materialFrenado = Resources.Load<Material>("Materials/LuzFreno");
        materialLuzFrenoOriginal = lucesFreno.GetComponent<Renderer>().material;
        //TextAsset textFile = Resources.Load<TextAsset>("Textos/castellano");
        //print(textFile.text);
        float x = PlayerPrefs.GetFloat("x", -1);
        float y = PlayerPrefs.GetFloat("y", 1);
        float z = PlayerPrefs.GetFloat("z", 5);
        transform.position=new Vector3(x, y, z);
    }

    void Update()
    {
        dir = Input.GetAxis("Horizontal");
        acc = Input.GetAxis("Vertical");
        frenoDeMano = Input.GetButton("Fire1");
        Acelerar();
        Girar();
        Frenar();
        
    }
    void Acelerar()
    {
        if (Mathf.Abs(acc) > 0.1f)
        {
            tubarros.SetActive(true);
        } else
        {
            tubarros.SetActive(false);
        }
        foreach(WheelCollider ruedaMotriz in ruedasMotrices)
        {
            ruedaMotriz.motorTorque = acc * potencia;
        }
    }
    void Girar()
    {
        foreach(WheelCollider ruedaDirectriz in ruedasDirectrices)
        {
            ruedaDirectriz.steerAngle = dir * multiplicadorGiro; 
        }
    }
    void Frenar()
    {
        if (frenoDeMano)
        {
            lucesFreno.GetComponent<Renderer>().material = materialFrenado;
            foreach (WheelCollider ruedaFrenado in ruedasFrenado)
            {
                ruedaFrenado.brakeTorque = fuerzaFrenado;
            }
        }
        else
        {
            lucesFreno.GetComponent<Renderer>().material = materialLuzFrenoOriginal;
            foreach (WheelCollider ruedaFrenado in ruedasFrenado)
            {
                ruedaFrenado.brakeTorque = 0;
            }
        }
    }

    private void OnApplicationQuit()
    {
        //GuardarEstado();
    }

    private void GuardarEstado()
    {
        PlayerPrefs.SetFloat("x", transform.position.x);
        PlayerPrefs.SetFloat("y", transform.position.y);
        PlayerPrefs.SetFloat("z", transform.position.z);
        PlayerPrefs.Save();
    }

    /*
        //IF ELSE DE TODA LA VIDA
        if (Input.GetKey(KeyCode.Space))
        {
            frenoDeMano = true;
        } else
        {
            frenoDeMano = false;
        }
        //OPERADOR TERNARIO
        frenoDeMano = Input.GetKey(KeyCode.Space) ? true : false;
        */
    /*//Ejemplo de ternaria (no tiene nada que ver con el coche
    int edad = 40;
    int categoria = 3;
    int salario;
    if (edad>=40 && categoria >= 2)
    {
        salario = 40000;
    } else
    {
        salario = 20000;
    }
    salario = (edad >= 40 && categoria >= 2) ? 40000 : 20000;
    */
}
