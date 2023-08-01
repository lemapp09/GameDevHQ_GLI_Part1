using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] 
    private ColorChangingRayCast _colorChangingCast;

    [SerializeField] 
    private InstantiateSpheres _instantiateSpheres;

    public void ColorChange() {
       _colorChangingCast.SetActive();
       _instantiateSpheres.SetInactive();
    }

    public void InstantiateSpheres() {
        _colorChangingCast.SetInactive();
        _instantiateSpheres.SetActive();
    }

    public void RemoveSpheres()
    {
        _instantiateSpheres.RemoveSpheres();
    }
}
