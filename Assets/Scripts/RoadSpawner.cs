using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public static RoadSpawner instance { get; private set; }//instance
    public int roadCount;
    public Vector3 nextSpawnPoint;
    public RoadPool roadPool;
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
        roadCount = 0;
        roadPool = FindAnyObjectByType<RoadPool>();
        for (int i = 0; i < 15; i++)
        {
            SpawnRoad();
        }
    }
    public void SpawnRoad()
    {
        roadCount++;
        GameObject temp = roadPool.GetRoad();
        temp.GetComponent<SpawnObstacle>().Spawn();
        temp.transform.position = nextSpawnPoint;
        nextSpawnPoint = temp.transform.Find("nextPos").transform.position;
    }

}
