using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public static RoadSpawner instance { get; private set; }//instance
    public int roadCount = 0;
    public Vector3 nextSpawnPoint;
    public RoadPool roadPool;
    public CoinPool coinPool;
    public PylonPool pylonPool;
    public FencePool fencePool;
    void Awake()
    {
        // if (instance != null && instance != this)
        // {
        //     Destroy(gameObject);
        // }
        // else
        // {
        //     instance = this;
        //     DontDestroyOnLoad(gameObject);
        // }
        instance = this;
    }
    void Start()
    {
        coinPool = FindAnyObjectByType<CoinPool>();
        roadPool = FindAnyObjectByType<RoadPool>();
        pylonPool = FindAnyObjectByType<PylonPool>();
        fencePool = FindAnyObjectByType<FencePool>();
        for (int i = 0; i < 15; i++)
        {
            SpawnRoad();
        }
    }
    public void SpawnRoad()
    {
        roadCount++;
        GameObject temp = roadPool.Get();
        temp.GetComponent<SpawnObstacle>().Spawn();
        temp.transform.position = nextSpawnPoint;
        nextSpawnPoint = temp.transform.Find("nextPos").transform.position;
    }

}
