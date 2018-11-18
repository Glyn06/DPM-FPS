using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {

    public GameObject gameObjectPrefab;
    public int cantObjects = 10;
    public Vector3 instantiatePos = Vector3.zero;

    List<GameObject> objects = new List<GameObject>();
    int objIndex = 0;

    private void Awake()
    {
        for (int i = 0; i < cantObjects; i++)
        {
            GameObject go;
            go = InstantiateAtPoint(gameObjectPrefab, instantiatePos);
            go.SetActive(false);
            PoolObject po = go.AddComponent<PoolObject>();
            po.SetPool(this);
            objects.Add(go);
        }
    }

    public void AddToList(GameObject obj) {
        objIndex--;
        objects[objIndex] = obj;
        obj.SetActive(false);
    }

    public GameObject UseObj(Vector3 pos) {
        GameObject returnObj = objects[objIndex];
        returnObj.transform.position = pos;
        returnObj.transform.rotation = Quaternion.identity;
        returnObj.SetActive(true);
        objIndex++;

        return returnObj;
    }

    public GameObject UseObj()
    {
        GameObject returnObj = UseObj(Vector3.zero);

        return returnObj;
    }

    public GameObject InstantiateAtPoint(GameObject gameobj ,Vector3 pos) {

        return Instantiate(gameobj, pos, Quaternion.identity, null);
    }
}
