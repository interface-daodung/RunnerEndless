using UnityEngine;
using UnityEngine.Pool;

public class CoinPool : Pool
{
    [SerializeField] private GameObject coinPrefab;
    protected override GameObject Prefab => coinPrefab;

    // Có thể override capacity nếu muốn
    protected override int DefaultCapacity => 60;
    protected override int MaxSize => 120;
}