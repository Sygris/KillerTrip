using UnityEngine;

public class Minimap : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        // Position 
        transform.position = _player.position + _offset;

        // Rotation
        Vector3 rotation = new Vector3(90, _player.eulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(rotation);
    }
}
