using UnityEngine;

public class Enemigo : MonoBehaviour, IDanables
{
    public float vidaEnemigo;
    public float dano;
    
    public void daño()
    {
        vidaEnemigo -= dano;
        Debug.Log($"tiene de vida {vidaEnemigo}");
        if(vidaEnemigo <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
