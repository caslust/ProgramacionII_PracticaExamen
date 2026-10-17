using UnityEngine;

[CreateAssetMenu(fileName = "InvetarioSO", menuName = "Scriptable Objects/InvetarioSO")]
public class InvetarioSO : ScriptableObject
{
   public TipoEquipamiento tipoEquipamiento;
   public  string nombreObjeto;
    public float velocidadDeAttaque;
    public float danio;
    public float vidaExtra;
}
public enum TipoEquipamiento
{
    Armadura ,
    Arma,
}
