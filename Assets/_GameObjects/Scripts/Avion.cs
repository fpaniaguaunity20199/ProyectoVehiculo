using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avion : MonoBehaviour
{
    public enum Estado { Reposo, Impulsando }
    public float potenciaMax;
    public float tiempoEntreIncrementos;
    public float incrementoPotencia;
    public float decrementoPotencia;
    public Estado estado = Estado.Reposo;
    public float potencia;
    private float x, y;
    private CharacterController cc;

    public float angularSpeed;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        StartCoroutine("GestionarPotencia");
    }
    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            estado = Estado.Impulsando;
        }
        else
        {
            estado = Estado.Reposo;
        }

        //Rotacion
        transform.Rotate(new Vector3(
                        y * angularSpeed * -1,
                        x * angularSpeed * -1,
                        x * angularSpeed) * -1);
        //Movimiento
        cc.Move(transform.forward * Time.deltaTime * potencia);
    }
    IEnumerator GestionarPotencia()
    {
        while (true)
        {
            switch (estado)
            {
                case (Estado.Impulsando):
                    potencia += incrementoPotencia;
                    potencia = Mathf.Min(potencia, potenciaMax);
                    break;
                case (Estado.Reposo):
                    potencia += decrementoPotencia;
                    potencia = Mathf.Max(potencia, 0);
                    break;
            }
            yield return new WaitForSeconds(tiempoEntreIncrementos);
        }
    }

}
