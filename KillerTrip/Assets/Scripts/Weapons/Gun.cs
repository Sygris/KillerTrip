using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GunData GunData;
    [SerializeField] private Transform Camera;

    float _timeSinceLastShot;

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(Camera.position, Camera.forward, Color.red);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            Shoot();

        if (Keyboard.current.rKey.wasPressedThisFrame)
            StartReload();
    }

    #region Shooting
    private bool CanShoot() => !GunData.IsReloading && _timeSinceLastShot > 1f / (GunData.FireRate / 60f);

    public void Shoot()
    {
        if (GunData.CurrentAmmo <= 0)
        {
            StartReload();
            return;
        }

        if (CanShoot())
        {
            if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hitInfo, GunData.MaxDistance))
            {
                IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                damageable?.TakeDamage(GunData.Damage);
            }

            GunData.CurrentAmmo--;
            _timeSinceLastShot = 0;
            OnGunShot();
        }
    }
    private void OnGunShot()
    {
        // Effects and shit
    }
    #endregion

    #region Reloading
    public void StartReload()
    {
        if (!GunData.IsReloading)
            StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        GunData.IsReloading = true;

        yield return new WaitForSeconds(GunData.ReloadTime);

        GunData.CurrentAmmo = GunData.MagSize;

        GunData.IsReloading = false;
    }
    #endregion
}
