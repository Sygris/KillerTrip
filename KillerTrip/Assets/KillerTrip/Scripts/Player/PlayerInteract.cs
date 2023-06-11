using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float _interactionRange;
    [SerializeField] private TextMeshProUGUI _interactableTextObject;
    [SerializeField] private string _interactText;
    [SerializeField] private string _interactableTag;

    private Vector3 _direction = Vector3.forward;
    private Ray _ray;

    void FixedUpdate()
    {
        _ray = new Ray(transform.position, transform.TransformDirection(_direction * _interactionRange));

        //Debug.DrawRay(transform.position, transform.TransformDirection(_direction * _interactionRange));

        if (Physics.Raycast(_ray, out RaycastHit hit, _interactionRange))
        {
            if (hit.collider.tag == _interactableTag)
                _interactableTextObject.text = _interactText + hit.transform.name;
        }
        else
            _interactableTextObject.text = "";
    }
}
