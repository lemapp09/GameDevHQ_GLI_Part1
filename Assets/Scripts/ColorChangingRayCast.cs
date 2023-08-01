using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class ColorChangingRayCast : MonoBehaviour
{
    private PlayerInputAction _playerInputAction;
    private bool _isActive = true;

    private void OnEnable()
    {
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.RayCast1.Enable();
        _playerInputAction.Player.RayCast1.performed += RayCast;
    }

    void RayCast(InputAction.CallbackContext context)
    {
        // requires user input
        // use mouse left
        if (Camera.main != null && _isActive) {
                RaycastHit hitInfo;
                // Fire Raycast from Main Camera
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                if (Physics.Raycast(ray, out hitInfo)) {
                    var hitObject = hitInfo.collider.GetComponent<MeshRenderer>();
                    if (hitObject != null) {
                        switch (hitInfo.collider.tag)
                        {
                            case "Cube":
                                hitObject.material.color = Random.ColorHSV();
                                break;
                            case "Sphere":
                                break;
                            case "Capsule":
                                hitObject.material.color = Color.black;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
    }

    public void SetActive() {
        _isActive = true;
    }

    public void SetInactive() {
        _isActive = false;
    }

    private void OnDisable()
    {
        _playerInputAction.Player.RayCast1.Disable();
        _playerInputAction.Player.RayCast1.performed -= RayCast;
    }
}
