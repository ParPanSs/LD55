using System.Collections.Generic;
using UnityEngine;

// TODO: remove this example from project

public interface IObjectPoolItem
    {
        string PoolObjectType { get; }
        void GetFromPool();
        void ReturnToPool();
    }

public class ObjectPoolModule : MonoBehaviour
{
    Dictionary<string, Queue<IObjectPoolItem>> appObjectPool;

    private void OnEnable()
    {
        appObjectPool = new Dictionary<string, Queue<IObjectPoolItem>>();
    }

    public IObjectPoolItem GetObjectFromPool(string objectType, GameObject objectToInstantiate, Vector3 pos, Transform parent = null)
    {
        IObjectPoolItem result = null;
        if (appObjectPool.ContainsKey(objectType))
        {
            if (appObjectPool[objectType].Count > 0)
            {
                bool endQueue = false;
                bool found = false;
                while (endQueue == false && found == false)
                {
                    if (appObjectPool[objectType].Count > 0)
                    {
                        IObjectPoolItem item = appObjectPool[objectType].Peek();
                        MonoBehaviour script = item as MonoBehaviour;
                        if ((item != null && script != null && script.gameObject != null) == false)
                        {
                            item = appObjectPool[objectType].Dequeue();
                        }
                        else
                        {
                            found = true;
                        }
                    }
                    else
                    {
                        endQueue = true;
                    }
                }
                if (endQueue || found == false)
                {
                    result = CreateObject(objectToInstantiate, pos, parent);
                }
                else
                {
                    result = appObjectPool[objectType].Dequeue();
                }
            }
            else
            {
                result = CreateObject(objectToInstantiate, pos, parent);
            }
        }
        else
        {
            Queue<IObjectPoolItem> newObjectsQueue = new Queue<IObjectPoolItem>();
            appObjectPool.Add(objectType, newObjectsQueue);
            result = CreateObject(objectToInstantiate, pos, parent);
        }
        result.GetFromPool();
        return result;
    }

    private IObjectPoolItem CreateObject(GameObject objectToInstantiate, Vector3 pos, Transform parent = null)
    {
        GameObject createdObject;
        if (parent == null)
        {
            createdObject = Instantiate(objectToInstantiate, pos, Quaternion.identity);
        }
        else
        {
            createdObject = Instantiate(objectToInstantiate, parent, false);
        }

        IObjectPoolItem poolableData = createdObject.GetComponent<IObjectPoolItem>();
        if (poolableData == null)
        {
            Debug.LogError("Invalid cast to interface IObjectPoolItem");
        }

        return poolableData;
    }

    public void ReturnToPool(IObjectPoolItem objectReturnedToPool)
    {
        if (appObjectPool != null)
        {
            if (appObjectPool.ContainsKey(objectReturnedToPool.PoolObjectType))
            {
                appObjectPool[objectReturnedToPool.PoolObjectType].Enqueue(objectReturnedToPool);
            }
            else
            {
                Queue<IObjectPoolItem> newObjectsQueue = new Queue<IObjectPoolItem>();
                newObjectsQueue.Enqueue(objectReturnedToPool);
                appObjectPool.Add(objectReturnedToPool.PoolObjectType, newObjectsQueue);
            }
        }
        objectReturnedToPool.ReturnToPool();
    }
}
