using System.Collections.Generic;
using UnityEngine;

public class EntityPooler : MonoBehaviour
{

    [System.Serializable]
    public class EntityPool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    
    public static EntityPooler Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<EntityPool> entities;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    private void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (EntityPool pool in entities)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                LevelManager.Instance.totalEntities++;
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            
            PoolDictionary.Add(pool.tag, objectPool);
        }
        
        LevelManager.Instance.entitiesRemaining = LevelManager.Instance.totalEntities;
        UIController.Instance.waveInfoText.text = LevelManager.Instance.totalEntities.ToString();
        
    }
    
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!PoolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " does not exist");
            return null;
        }

        GameObject objectToSpawn = PoolDictionary[tag].Dequeue();
        
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        
        PoolDictionary[tag].Enqueue(objectToSpawn);
        
        return objectToSpawn;
        
    }
}
