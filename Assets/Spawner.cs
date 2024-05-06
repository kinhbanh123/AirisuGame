using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    [SerializeField] protected GameObject holder;
    [SerializeField] protected List<GameObject> prefabs;
    [SerializeField] protected List<GameObject> poolObjs;

    protected void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }
    protected void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder").gameObject;
    }
    protected void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab.gameObject);
        }
        this.HidePrefabs();
    }
    protected void HidePrefabs()
    {
        foreach (GameObject prefab in this.prefabs)
        {
            prefab.SetActive(false);
        }
    }
    public virtual GameObject Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        GameObject prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found " + prefabName);
            return null;
        }
        GameObject newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.transform.position = spawnPos;
        newPrefab.transform.rotation = rotation;
        newPrefab.transform.parent = this.holder.transform;
        return newPrefab;
    }
    protected virtual GameObject GetObjectFromPool(GameObject prefab)
    {
        foreach (GameObject poolObj in this.poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        GameObject newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public virtual void Despawn(GameObject obj)
    {
        this.poolObjs.Add(obj);
        obj.SetActive(false);
    }
    public virtual GameObject GetPrefabByName(string prefabName)
    {
        foreach (GameObject prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }


}
