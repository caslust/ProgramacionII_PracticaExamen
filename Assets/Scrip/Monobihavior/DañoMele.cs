
using UnityEngine;

public class DañoMele : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Enemigo enemigo = other.GetComponentInParent<Enemigo>();

            if (enemigo != null)
            {
                enemigo.daño();
            }
        }
    }
}