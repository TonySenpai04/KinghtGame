using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Start is called before the first frame update
    [System.Serializable]
public class Preallocation
{
    public GameObject gameObject;
    public int count;
    public bool expandable;
}

public class ObjectPool :/* MonoBehaviour
{
    */MonoSingleton<ObjectPool> {  
    public static ObjectPool instance;
    
    public List<Preallocation> preAllocations;

    [SerializeField]
    List<GameObject> pooledGobjects;

    protected override void Awake()
    {
        instance = this; 
        base.Awake();
        pooledGobjects = new List<GameObject>();

        foreach (Preallocation item in preAllocations)
        {
            for (int i = 0; i < item.count; ++i)
                pooledGobjects.Add(CreateGobject(item.gameObject));
        }
    }

    public GameObject Spawn(string tag)
    {
        for (int i = 0; i < pooledGobjects.Count; ++i)
        {
            if (!pooledGobjects[i].activeSelf && pooledGobjects[i].tag == tag)
            {
                pooledGobjects[i].SetActive(true);
                return pooledGobjects[i];
            }
        }

        for (int i = 0; i < preAllocations.Count; ++i)
        {
            if (preAllocations[i].gameObject.tag == tag)
                if (preAllocations[i].expandable)
                {
                    GameObject obj = CreateGobject(preAllocations[i].gameObject);
                    pooledGobjects.Add(obj);
                    obj.SetActive(true);
                    return obj;
                }
        }
        return null;
    }

   public GameObject CreateGobject(GameObject item)
    {
        GameObject gobject = Instantiate(item, transform);
        gobject.SetActive(false);
        return gobject;
    }
    //public static ObjectPool SharedInstance;
    //public List<GameObject> pooledObjects;
    //public GameObject objectToPool;
    //public int amountToPool;

    //private void  Awake()
    //{
    //    SharedInstance = this;
    //}

    //private void Start()
    //{
    //    pooledObjects = new List<GameObject>();
    //    GameObject newObject;

    //    for (int i = 0; i < amountToPool; i++)
    //    {
    //        newObject = Instantiate(objectToPool);
    //        newObject.SetActive(false);
    //        pooledObjects.Add(newObject);
    //    }
    //}

    //public GameObject GetPooledObject()
    //{
    //    for (int i = 0; i < amountToPool; i++)
    //    {
    //        if (!pooledObjects[i].activeInHierarchy)
    //        {
    //            return pooledObjects[i];
    //        }
    //    }

    //    return null;
    //}
}

