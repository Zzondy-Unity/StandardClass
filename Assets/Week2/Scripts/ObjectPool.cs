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
    public class Pool
    {
        public GameObject Prefab;
        public int size;        //Inspector창에서 300으로 시작
        public PoolTag tag;
    }

    public List<Pool> Pools;
    public Dictionary<PoolTag, List<GameObject>> PoolDictionary;

    private void Start()
    {
        PoolDictionary = new Dictionary<PoolTag, List<GameObject>>();

        foreach (Pool pool in Pools)
        {
            List<GameObject> objectPool = new List<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject go = Instantiate(pool.Prefab, this.transform);

                objectPool.Add(go);
            }
            PoolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject GetFromPool(PoolTag tag)
    {
        //모두 활성화되어있을때
        if (PoolDictionary[tag].All(x => x.activeSelf == true))
        {
            //새로 만들어서 돌려준다.
            Pool pool = Pools.Find(prefab => prefab.tag == tag);
            GameObject go = Instantiate(pool.Prefab);
            PoolDictionary[tag].Add(go);
            return go;
        }
        //비활성화된것이 존재할때
        else
        {
            //활성화시켜서 건내준다.
            GameObject go = PoolDictionary[tag].Find(x => x.activeSelf == false);
            go.SetActive(true);
            return go;
        }
    }


    public void Release(GameObject obj)
    {
        obj.SetActive(false);
    }


    //public GameObject prefab;
    //private List<GameObject> pool = new List<GameObject>();
    //public int poolSize = 300;

    //private void Start()
    //{
    //    for (int i = 0; i < poolSize; i++)
    //    {
    //        GameObject go = Instantiate(prefab);
    //        go.SetActive(false);
    //        pool.Add(go);
    //    }
    //}

    //public GameObject Get()
    //{
    //    GameObject monster = pool.First(x => x.activeSelf == false);
    //    if(monster != null)
    //    {
    //        return monster;
    //    }
    //    else
    //    {
    //        GameObject newMonster = Instantiate(prefab);
    //        newMonster.SetActive(true);
    //        pool.Add(newMonster);
    //        return newMonster;
    //    }
    //}

}