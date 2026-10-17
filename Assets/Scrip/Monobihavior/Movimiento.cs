using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Movimiento : MonoBehaviour
{
    [SerializeField] CharacterController cC;
    [SerializeField] float velocidadDeMovimento;
    Vector3 movVector = Vector3.zero;
    [SerializeField] LayerMask aQueLePegamosMiChan;
    //---Collider----//
    [SerializeField] GameObject obj;
    //public float radioDeTaque;
    //public Transform posicionDeLaMele;

    [SerializeField] float radioInteractuable;
    void Update()
    {
        //Dar Direcion 
        movVector.x = Input.GetAxis("Horizontal");
        movVector.y = 0;
        movVector.z = Input.GetAxis("Vertical");

        cC.Move(movVector * velocidadDeMovimento * Time.deltaTime);


        Ray rayoPoscionCursorDelMaus = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(rayoPoscionCursorDelMaus, out hitInfo, 100f))
        {
            Vector3 posicion = hitInfo.point;
            posicion.y = transform.position.y;
            transform.LookAt(posicion);
        }
         
        if (Input.GetMouseButtonDown(0))
        {
            obj.SetActive(true);
            Invoke("ApagarhitBox", 1.5f);
        }
        Interacion();
    }
    void ApagarhitBox()
    {
        obj.SetActive(false);
    }
    private void Interacion()
    {
        IInteractable interactuableMasSercano = null;
        IDanables interactuableMasSercanoDano = null;
        List<Collider> colisionInteractuable = Physics.OverlapSphere(transform.position + transform.forward, radioInteractuable, aQueLePegamosMiChan).ToList();
        float distacia = 1000f;

        float distaciaEnemigo = 500f;

        if (colisionInteractuable.Count > 0)
        {
            foreach (Collider colisiones in colisionInteractuable)
            {
                if (colisiones.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    if (Vector3.Distance(colisiones.transform.position, transform.position) < distacia)
                    {
                        interactuableMasSercano = interactable;
                        distacia = Vector3.Distance(colisiones.transform.position, transform.position);

                    }
                }
                if (colisiones.transform.TryGetComponent<IDanables>(out IDanables dañables))
                {
                    if (Vector3.Distance(colisiones.transform.position, transform.position) < distaciaEnemigo)
                    {
                        interactuableMasSercanoDano = dañables;
                        distaciaEnemigo = Vector3.Distance(colisiones.transform.position, transform.position);

                    }
                }
            }
        }
        else
        {
            interactuableMasSercano = null;
            interactuableMasSercanoDano = null;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            interactuableMasSercano?.Interac();

        }
        if (Input.GetMouseButtonDown(0))
        {

            interactuableMasSercanoDano?.daño();

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.coral;
        Gizmos.DrawSphere(transform.position + transform.forward, radioInteractuable);
    }
}
 