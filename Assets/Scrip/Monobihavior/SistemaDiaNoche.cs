using System.Collections;
using UnityEngine;

public class SistemaDiaNoche : MonoBehaviour
{
    GameObject luzObjeto;
    Light luz;
    Spawn spawn;

    float valorNoche = 20000f;
    float valorDia = 5000f;

    public int enemigosVivosOleada;

    [Header("Datos de Hora De Juego")]
    [SerializeField] int cadaCuentoSegundosSeCambiaDeHora;

    void Start()
    {
        luzObjeto = GameObject.Find("Directional Light");
        luz = luzObjeto.GetComponent<Light>();

        spawn = FindAnyObjectByType<Spawn>();

        StartCoroutine(HoraAmPm());
    }

    IEnumerator HoraAmPm()
    {
        if (valorDia < valorNoche)
        {
            StartCoroutine(spawn.spawnsNormal());
        }

        while (valorDia < valorNoche)
        {
            luz.colorTemperature = valorDia += 1000 * Time.deltaTime;
            Debug.Log(valorDia);

            yield return new WaitForSeconds(cadaCuentoSegundosSeCambiaDeHora);
        }

        if (valorDia >= valorNoche)
        {
            StartCoroutine(spawn.spawnsOrdaFinal());
        }

        yield return null;
    }
    public void MurioEnemigoDeNoche()
    {
        if (enemigosVivosOleada <= 0) return;

        enemigosVivosOleada--;

        if (enemigosVivosOleada == 0)
        {
            valorDia = 5000f;
            luz.colorTemperature = valorDia;
            //StartCoroutine(HoraAmPm());
        }
    }
}
