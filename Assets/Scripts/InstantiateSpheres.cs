using UnityEngine;
using UnityEngine.InputSystem;
public class InstantiateSpheres : MonoBehaviour
{
    [SerializeField]
    private GameObject _spherePrefab;
    private bool _isActive = false;

    public void Update() {
        if (Mouse.current.leftButton.wasPressedThisFrame && _isActive) {
            SpawnSphere();
        }
    }

    private void SpawnSphere() {
        if (Camera.main != null) {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.CompareTag("Floor")) {
                    GameObject obj = Instantiate(_spherePrefab, hit.point, Quaternion.identity);
                    obj.transform.position += new Vector3(0, 0.5f, 0);
                    obj.transform.parent = transform;
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

    public void RemoveSpheres() {
        // delete all of the child objects
        foreach (Transform child in transform) {
                Destroy(child.gameObject);
        }
    }
    
}
