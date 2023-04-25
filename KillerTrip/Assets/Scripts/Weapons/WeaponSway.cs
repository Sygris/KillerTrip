using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSway : MonoBehaviour
{
    [Header("Sway Settings")]
    [SerializeField] private float Smooth;
    [SerializeField] private float SwayMultiplier;

    void Update()
    {
        //// Get Mouse Input
        //float mouseX = Mouse.current.position.x * SwayMultiplier;
        //float mouseY = Input.mousePosition.y * SwayMultiplier;

        //// Calculate Target Rotation
        //Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        //Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        //Quaternion targetRotation = rotationX * rotationY;

        //// Rotate
        //transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Smooth * Time.deltaTime);
    }
}
