using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDiaNoche : MonoBehaviour
{
    GameObject luzObjeto;
     Light luz;
    float valorNoche = 20000f;
    float valorDia = 5000f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        luzObjeto = GameObject.Find("Directional Light");
        luz = luzObjeto.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(HoraAmPm());
    }
    IEnumerator HoraAmPm()
    {
        yield return new WaitForSeconds(4f);
    }
}
