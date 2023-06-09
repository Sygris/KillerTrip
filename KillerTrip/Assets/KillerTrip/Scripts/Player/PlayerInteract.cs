using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float _interactionRange;
    [SerializeField] private TextMeshProUGUI _interactableTextObject;
    [SerializeField] private string _interactText;
    [SerializeField] private LayerMask _interactableLayer;

    void Update()
    {
        Vector3 direction = Vector3.forward;

        Ray ray = new Ray(transform.position, transform.TransformDirection(direction * _interactionRange));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * _interactionRange));

        _interactableTextObject.text = "";

        if (Physics.Raycast(ray, out RaycastHit hit, _interactionRange))
        {
            if (hit.collider.gameObject.layer == 6)
            {
                Debug.Log("Layer Detection");
                _interactableTextObject.text = _interactText + hit.transform.name;
            }

            if (hit.collider.tag == "Interactable")
            {
                Debug.Log("Tag Detection");
                _interactableTextObject.text = _interactText + hit.transform.name;
            }

        }
    }
}
