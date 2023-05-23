using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _aimVirtualCamera;
    [SerializeField] private float _normalSensivity;
    [SerializeField] private float _aimSensitivity;
    [SerializeField] private LayerMask _aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform _debugTransform;

    private ThirdPersonController _thirdPersonController;
    private StarterAssetsInputs _starterAssetsInputs;

    private Vector3 m_mouseWorldPosition = Vector3.zero;

    private void Awake()
    {
        _thirdPersonController = GetComponent<ThirdPersonController>();
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        m_mouseWorldPosition = Vector3.zero;

        RaycastToScreenCenterPoint();
        ToggleAim(_starterAssetsInputs.Aim);
    }

    private void RaycastToScreenCenterPoint()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, _aimColliderLayerMask))
        {
            _debugTransform.position = raycastHit.point;
            m_mouseWorldPosition = raycastHit.point;
        }
        else
        {
            _debugTransform.position = Camera.main.transform.position + Camera.main.transform.forward * 200f;
            m_mouseWorldPosition = Camera.main.transform.position + Camera.main.transform.forward * 200f;
        }
    }

    private void ToggleAim(bool isAiming)
    {
        if(isAiming)
        {
            _aimVirtualCamera.gameObject.SetActive(true);
            _thirdPersonController.SetSensivity(_aimSensitivity);
            _thirdPersonController.SetRotateOnMove(false);

            Vector3 worldAimTarget = m_mouseWorldPosition;
            // Locks vertical rotation (up/down).
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            _aimVirtualCamera.gameObject.SetActive(false);
            _thirdPersonController.SetSensivity(_normalSensivity);
            _thirdPersonController.SetRotateOnMove(true);
        }
    }
}
