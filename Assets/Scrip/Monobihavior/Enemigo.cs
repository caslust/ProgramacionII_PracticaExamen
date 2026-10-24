using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour, IDanables
{
    [Header("Recurso ")]
    public GameObject Recurso;

    [Range(0, 100)]
    public int porcentajeDeRecurso = 50;
    [Header("Dato De Enemigo")]
    public float vidaEnemigo;
    public float dano;

    [Header("Deteccion y attacke")]
    [SerializeField] private float RadioDeDeteccion;
    [SerializeField] private float RadioDeAttaque;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private NavMeshAgent agente;

    [SerializeField] bool quienEsEnemigoNoche;

    private bool muerto;
    Movimiento Player;

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Movimiento>();
    }
    private void Update()
    {
        if (Physics.CheckSphere(transform.position, RadioDeDeteccion, playerMask))
        {
            agente.SetDestination(Player.transform.position);
        }

        // Ataque al jugador
        if (Physics.CheckSphere(transform.position, RadioDeAttaque, playerMask))
        {
            Vector3 direction = Player.transform.position   - transform.position;
            Ray attackRay = new Ray(transform.position, direction);

            if (Physics.Raycast(attackRay, RadioDeAttaque, playerMask))
            {
                Debug.Log("Le pego al jugador");
            }
        }
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
            if (quienEsEnemigoNoche)
            {
                FindAnyObjectByType<SistemaDiaNoche>() .MurioEnemigoDeNoche();
            }
            Player.mateEnemigo = true;
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Radio de detección
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, RadioDeDeteccion);

        // Radio de ataque
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadioDeAttaque);
    }
}
