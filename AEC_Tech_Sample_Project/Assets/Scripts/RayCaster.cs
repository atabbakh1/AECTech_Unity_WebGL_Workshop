using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayCaster : MonoBehaviour
{

    [SerializeField] private Material material;
    [SerializeField] private bool randomColor = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse is not over a UI element
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                // Create a ray from the camera pointing to where the mouse cursor is
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Perform the raycast and check if it hits something
                if (Physics.Raycast(ray, out hit))
                {
                    // get the material of the hit object
                    Material hitObjectMateril = hit.collider.gameObject.GetComponent<Renderer>().material;
                    if (hitObjectMateril != null)
                    {
                        if (randomColor)
                        {
                            // assign a random color value to the material
                            hitObjectMateril.color = new Color(Random.value, Random.value, Random.value);
                        }
                        else
                        {
                            // copy the properties of the material to the hit object material
                            hitObjectMateril.CopyPropertiesFromMaterial(material);
                        }
                    }
                }
            }
            else
            {
                // Optionally handle UI logic
                Debug.Log("Pointer is over a UI element. Raycast not performed.");
            }
        }
    }
}
