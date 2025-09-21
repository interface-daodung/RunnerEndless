using UnityEngine;

public class FencePool : Pool
{
    [SerializeField] private GameObject fencePrefab;
    protected override GameObject Prefab => fencePrefab;

    // Có thể override capacity nếu muốn
    protected override int DefaultCapacity => 40;
    protected override int MaxSize => 80;
}