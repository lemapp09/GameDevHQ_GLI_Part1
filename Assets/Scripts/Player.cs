using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    void Update()
    {
        // requires user input
        // use mouse left
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            // Fire Raycast from Main Camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)){
                // change color
                if (hit.collider.CompareTag("Cube"))
                {
                    hit.collider.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
                }
            }
        }

    }
}
