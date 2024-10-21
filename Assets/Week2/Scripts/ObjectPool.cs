using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum PoolTag
{
    Skeleton,
    Arrow
}

public class ObjectPool : MonoBehaviour
{
    //public class Pool
    //{
    //    public GameObject Prefab;
    //    public int size;        //Inspector창에서 300으로 시작
    //    public PoolTag tag;
    //}


    //public List<Pool> Pools;
    //public Dictionary<PoolTag, List<Pool>> PoolDictionary = new Dictionary<PoolTag, List<Pool>>();

    //private void Awake()
    //{
    //    foreach (var pool in Pools)
    //    {
    //        for (int i = 0; i < pool.size; i++)
    //        {
    //            GameObject go = Instantiate(prefab);

    //            Pools.Add();
    //        }
    //        PoolDictionary.Add(pool.tag, Pools);
    //    }
    //}

    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    public int poolSize = 300;

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject go = Instantiate(prefab);
            go.SetActive(false);
            pool.Add(go);
        }
    }

    public GameObject Get()
    {
        GameObject monster = pool.First(x => x.activeSelf == false);
        if(monster != null)
        {
            return monster;
        }
        else
        {
            GameObject newMonster = Instantiate(prefab);
            newMonster.SetActive(true);
            pool.Add(newMonster);
            return newMonster;
        }
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
    }
}