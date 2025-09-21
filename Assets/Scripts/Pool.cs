using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    // Cho phép class con override nếu muốn
    protected virtual GameObject Prefab => prefab;

    private ObjectPool<GameObject> pool;

    protected virtual int DefaultCapacity => 20;
    protected virtual int MaxSize => 40;

    void Awake()
    {
        pool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(Prefab),            // tạo mới khi pool rỗng
            actionOnGet: obj => obj.SetActive(true),          // khi lấy từ pool
            actionOnRelease: obj => obj.SetActive(false),     // khi trả về pool
            actionOnDestroy: obj => Destroy(obj),             // khi pool hủy
            collectionCheck: false,
            defaultCapacity: DefaultCapacity,
            maxSize: MaxSize
        );
    }

    public GameObject Get()
    {
        return pool.Get();
    }

    public void Release(GameObject obj)
    {
        pool.Release(obj);
    }
}
