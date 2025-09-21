using UnityEngine;

public class RoadPool : Pool
{
    [SerializeField] private GameObject roadPrefab;
    protected override GameObject Prefab => roadPrefab;
}