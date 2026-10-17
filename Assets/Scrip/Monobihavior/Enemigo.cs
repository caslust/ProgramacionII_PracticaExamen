using UnityEngine;

public class Enemigo : MonoBehaviour, IDanables
{
    public GameObject Recurso;

    [Range(0, 100)]
    public int porcentajeDeRecurso = 50;

    public float vidaEnemigo;
    public float dano;

    private bool muerto;
    Movimiento detectarSiPatamosAlEnemigo;

    void Start()
    {
        detectarSiPatamosAlEnemigo =
            GameObject.Find("Player").GetComponent<Movimiento>();
    }

    public void daño()
    {
        if (muerto) return;

        vidaEnemigo -= dano;
        Debug.Log($"tiene de vida {vidaEnemigo}");

        if (vidaEnemigo <= 0)
        {
            muerto = true;

            int numero = Random.Range(0, 100);

            if (numero < porcentajeDeRecurso && Recurso != null)
            {
                Instantiate(  Recurso,  transform.position,  Quaternion.identity );
            }

            detectarSiPatamosAlEnemigo.mateEnemigo = true;
            Destroy(gameObject);
        }
    }
}
