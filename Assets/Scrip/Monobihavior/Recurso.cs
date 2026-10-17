using UnityEngine;

public class Recurso : MonoBehaviour, IInteractable
 
{
          private Invetario inventario;
    private bool recolectado;

    void Start()
    {
        inventario = GameObject.Find("Player").GetComponent<Invetario>();
    }

    public void Interac()
    {
        if (recolectado) return;

        recolectado = true;
        inventario.recursos += 1;

        Debug.Log($"Recursos: {inventario.recursos}");
        Destroy(gameObject);
    }
}

