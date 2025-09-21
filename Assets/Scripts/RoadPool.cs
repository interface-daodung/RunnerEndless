using UnityEngine;
using UnityEngine.Pool;


public class RoadPool : MonoBehaviour
{
    public GameObject roadPrefab;

    // ObjectPool<GameObject>
    private ObjectPool<GameObject> pool;

    void Awake()
    {
        pool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(roadPrefab), // tạo mới khi pool rỗng
            actionOnGet: obj => obj.SetActive(true),     // khi lấy từ pool
            actionOnRelease: obj => obj.SetActive(false),// khi trả về pool
            actionOnDestroy: obj => Destroy(obj),        // khi pool hủy
            collectionCheck: true,                       // bật kiểm tra trùng lặp
            defaultCapacity: 20,                         // kích thước mặc định
            maxSize: 50                                  // tối đa object
        );
    }

    public GameObject GetRoad()
    {
        return pool.Get();
    }

    public void ReleaseRoad(GameObject road)
    {
        pool.Release(road);
    }
}
