using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManage : MonoBehaviour
{
    static PoolManage _instance;
    public static PoolManage Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance)
            Destroy(this.gameObject);
        else
            _instance = this;
    }
    Dictionary<string, FirePool> dic = new Dictionary<string, FirePool>();
   public void CreatePool(string poolName,GameObject prefab)
    {
        if (!dic.ContainsKey(poolName))
        {
            FirePool pool = new FirePool(prefab);
            dic.Add(poolName, pool);
        }
    }
    public GameObject Get(string poolName)
    {
        FirePool pool;
        if (dic.TryGetValue(poolName,out pool))
        {
            return pool.Get();
        }
        return null;
    }
    public void Recover(string poolName,GameObject go)
    {
        FirePool pool;
        if (dic.TryGetValue(poolName,out pool))
        {
            pool.Recover(go);
        }
    }
}
