using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO 客户端玩家控制移动脚本
public class PlayerGame : MonoBehaviour {
    public Transform control;

    void OnNetworkLoaded()
    {
        //实例化该目标对象
        Network.Instantiate(control,transform.position,transform.rotation,0);
    }
	
	void Update () {
				//如果正在玩家正在连接，才执行下面的移动脚本===
        if (Network.isClient)
        {
        		//赋值前后左右的轴值(X,Z)控制角色移动===
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            float speed = 5.0f;
           //标签为"Player"的角色按每秒多少米的速度开始移动 TODO
            GameObject.FindGameObjectWithTag("Player").transform.Translate(speed*direction*Time.deltaTime);
        }
	}
}
