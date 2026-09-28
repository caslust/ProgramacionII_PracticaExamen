using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] CharacterController cC;
    [SerializeField] float velocidadDeMovimento;
    Vector3 movVector = Vector3.zero;
    //[SerializeField] LayerMask aQueLePegamosMiChan;
    //---Collider----//
    [SerializeField] GameObject obj;
    //public float radioDeTaque;
    //public Transform posicionDeLaMele;


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
         
    }
    void ApagarhitBox()
    {
        obj.SetActive(false);
    }

}
 