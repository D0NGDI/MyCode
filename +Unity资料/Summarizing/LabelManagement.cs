using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LabelManagement : MonoBehaviour {

    public Transform go;
    void Start()
    {
        go = this.gameObject.transform;
    }

    void Update()
    {
        GameObject instance = Instantiate(Resources.Load("enemy", typeof(GameObject))) as GameObject;
        instance.GetComponent<PlayerMove>().Camp = "Enemys";
        foreach (Transform getChild in go)
        {
            getChild.GetComponent<PlayerMove>().Camp = "123";
            getChild.gameObject.SetActive(true);
            print(getChild.gameObject.name);
        }
    }

    //private Transform GetChild(Transform tr, int index)
    //{
    //    return tr.GetChild(index);
    //}
}
