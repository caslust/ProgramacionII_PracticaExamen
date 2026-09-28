using UnityEngine;

public class DañoMele : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     
     
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Debug.Log("le quitaste vida al enemigo");
        }
    }
}
