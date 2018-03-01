using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    Timer timer;

    void Start()
    {
        
            timer = new Timer(90);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            timer.OnUpdate += SetScale;
            timer.OnEnd += Hide;
            timer.Start();
        }
            int a = (int)timer.CurTime;
            print(a);
    }

    //缩放动画
    void SetScale()
    {
        float scale = 1 - timer.Ratio;
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}
