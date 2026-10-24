using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{


    [Header("Intaciar Objeto ")]
    [SerializeField] GameObject enemigo;
    [SerializeField] GameObject enemigoOleanaDeNoche;
    [SerializeField] Transform posicionEnemigo;

    [Header ("Tiempo de Spawn")] 
    [SerializeField ]  int cuantosEnemigosQuieresQueSalgan;
    [SerializeField] int comienzo;
    [SerializeField] int EsperaDeCadaIntaciamiento;
    [Header("Spawn Oleada Final")]
    [SerializeField] int  CuantosEnemigosQuieres;
    [SerializeField] int  segundosDeEsperaAntesDeLaOleada;
     Transform[] spawnEnemigo  ;

    

    private Coroutine spawncorrutina;

    Vector3 minimo = new Vector3(-17.57f, 0f, -18.19f);
    Vector3 maximo = new Vector3(17.57f, 0f, 18.19f);
    public void Start()
    {

        if(spawncorrutina != null) { return; }
        spawnEnemigo = new Transform[CuantosEnemigosQuieres];
        
        
        
    }
    public IEnumerator spawnsNormal()
    {
        while ( comienzo < cuantosEnemigosQuieresQueSalgan)
        {
            comienzo++;
            //Debug.Log(comienzo);
            Vector3 posicion = new Vector3(Random.Range(minimo.x, maximo.x), minimo.y, Random.Range(minimo.z, maximo.z));
            Instantiate(enemigo, posicion, posicionEnemigo.rotation);
            
            yield return new WaitForSeconds(EsperaDeCadaIntaciamiento);
        }
        yield return  null;

    }
    public IEnumerator spawnsOrdaFinal()
    {
        yield return new WaitForSeconds(segundosDeEsperaAntesDeLaOleada);
        FindAnyObjectByType<SistemaDiaNoche>().enemigosVivosOleada = spawnEnemigo.Length;
        for (int i = 0; i < spawnEnemigo.Length; i++)
        {
             
            Vector3 posicionOleada = new Vector3(  Random.Range(minimo.x, maximo.x),  minimo.y,  Random.Range(minimo.z, maximo.z));
            spawnEnemigo[i] = Instantiate(enemigoOleanaDeNoche, posicionOleada, posicionEnemigo.rotation ).transform;
        }
    }
     
}
