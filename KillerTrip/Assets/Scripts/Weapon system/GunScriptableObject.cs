using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Weapon", order = 0)]
public class GunScriptableObject : ScriptableObject
{
    public GunType Type;
    public string Name;
    public GameObject ModelPrefab;
    public Vector3 SpawnPoint;
    public Vector3 SpawnRotation;

    public ShootConfigurationScriptableObject Shootconfiguration;
    public TrailConfigurationScriptableObject Trailconfiguration;

    private MonoBehaviour _activeMonoBehaviour;
    private GameObject _model;
    private float _lastShootTime;
    private ParticleSystem _particleShootSystem;
    private ObjectPool<TrailRenderer> _trailRendererPool;

    public void Spawn(Transform parent, MonoBehaviour activeMonoBehaviour)
    {
        _activeMonoBehaviour = activeMonoBehaviour;
        _lastShootTime = 0;
        _trailRendererPool = new ObjectPool<TrailRenderer>(CreateTrail);

        _model = Instantiate(ModelPrefab);
        _model.transform.SetParent(parent, false);
        _model.transform.localPosition = SpawnPoint;
        _model.transform.localRotation = Quaternion.Euler(SpawnRotation);

        _particleShootSystem = _model.GetComponent<ParticleSystem>();
    }

    public void Shoot()
    {
        if (Time.time > Shootconfiguration.FireRate + _lastShootTime)
        {
            _lastShootTime = Time.time;
            _particleShootSystem.Play();
        }
    }

    private TrailRenderer CreateTrail()
    {
        GameObject instance = new GameObject("Bullet Trail");
        TrailRenderer trailRenderer = instance.AddComponent<TrailRenderer>();
        trailRenderer.colorGradient = Trailconfiguration.Color;
        trailRenderer.material = Trailconfiguration.Material;
        trailRenderer.widthCurve = Trailconfiguration.WidthCurve;
        trailRenderer.time = Trailconfiguration.Duration;
        trailRenderer.minVertexDistance = Trailconfiguration.MinVertexDistance;

        trailRenderer.emitting = false;
        trailRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        return trailRenderer;
    }
}
