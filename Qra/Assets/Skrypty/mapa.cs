using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapa : MonoBehaviour {

    public float step=32;

    List<GameObject> prefabList = new List<GameObject>();

    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;
    public GameObject Prefab4;
    public GameObject Prefab5;
    public GameObject Prefab6;
    public GameObject Prefab7;
    public GameObject Prefab8;

    void Start ()
    {
        prefabList.Add(Prefab1);
        prefabList.Add(Prefab2);
        prefabList.Add(Prefab3);
        prefabList.Add(Prefab4);
        prefabList.Add(Prefab5);
        prefabList.Add(Prefab6);
        prefabList.Add(Prefab7);
        prefabList.Add(Prefab8);
    }
	
	
	void FixedUpdate () {

         int prefabIndex = UnityEngine.Random.Range(0, 8);
         int strona = UnityEngine.Random.Range(0, 2);
         if (step<2000)
        {
            GameObject a = Instantiate(prefabList[prefabIndex]) as GameObject;
            if (strona == 1)
            {
                a.transform.position = new Vector3(0, step, 0);
            }
            else
            {
                a.transform.position = new Vector3(16, step, 0);
                a.transform.Rotate(new Vector3(0, 180, 0));
            }
            step += 32;
        }
    }
}
