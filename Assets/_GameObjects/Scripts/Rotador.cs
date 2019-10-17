using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour
{
    public float multiplicador;
    public float umbralBlur;
    public Avion avion;
    public GameObject heliceBlur;

    
    void Update()
    {
        transform.Rotate(avion.potencia * multiplicador * Time.deltaTime, 0 , 0);    
        if (avion.potencia > umbralBlur)
        {
            heliceBlur.SetActive(true);
        } else
        {
            heliceBlur.SetActive(false);
        }
    }
}
