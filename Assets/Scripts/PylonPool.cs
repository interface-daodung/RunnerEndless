using UnityEngine;

public class PylonPool : Pool
{
    [SerializeField] private GameObject pylonPrefab;
    protected override GameObject Prefab => pylonPrefab;

    // Có thể override capacity nếu muốn
    protected override int DefaultCapacity => 40;
    protected override int MaxSize => 80;
}