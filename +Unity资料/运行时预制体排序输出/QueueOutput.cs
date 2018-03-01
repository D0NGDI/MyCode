using UnityEngine;
using System.Collections;
//TODO 游戏运行时按队形输出预制体
public class QueueOutput :MonoBehaviour{
    public GameObject mainCamera;
    public GameObject prefab;//队列输出的预制体
    
   
    void Start()
    {
       //开启协同，参数是协同方法
        StartCoroutine(Generate());
    }
     float positionz = 0;//新出预制体在Z轴上的偏移量
     //float positionx = 0;//新出预制体在X轴上的偏移量 
     int end = 0; //终止协同的标志位   
     void Update()
    {
        if (end == 1)
        {
            //终止协同
            StopCoroutine(Generate());  
        }
       
    }
    IEnumerator Generate()
    {
        
        
            for ( j = 0; j < Random.Range(1f,9f); j++)
            {
                for ( i = 0; i <= Random.Range(3f,8f); i++)
                {
                        Instantiate(prefab, new Vector3(transform.position.x + i * 15f, 4f,transform.position.z + positionz), Quaternion.identity);
                }
                positionz += 15f;
                //positionx -= 2.0f;
            }
        end++;
        Debug.Log(end);
            yield return new WaitForSeconds(3f);
            //yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));
       
    }

    IEnumerator GreatWorld()
    {


        while (true)
        {

            GameObject item = Instantiate(prefab, new Vector3(0, 0, prefab.transform.position.z + i), Quaternion.identity) as GameObject;
            yield return new WaitForSeconds(second);
            i += 100;
            Destroy(item.gameObject, 10f);

        }
    }
}