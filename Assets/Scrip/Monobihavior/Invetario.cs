using UnityEngine;

public class Invetario : MonoBehaviour
{

    public int recursos;
    [SerializeField] InvetarioSO objetos1;
    [SerializeField] InvetarioSO objetos2;
    [SerializeField] InvetarioSO objetos3;
    [SerializeField] InvetarioSO objetos4;

    public bool tieneObjetos;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && tieneObjetos)
        {
            if (objetos1 == objetos2)
            {
                objetos1 = objetos3;
            }
            else if (objetos1 == objetos3)
            {
                objetos1 = objetos2;
            }
        }
    }

    public void DesbloquearObjetos()
    {
        if (tieneObjetos) return;

        tieneObjetos = true;
        Debug.Log("Desbloqueaste las armas y el equipo predefinidos");
    }
}
 
