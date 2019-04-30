using UnityEngine;
using System.Collections;

public class SystemTimeControl : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MyGameControllor.IsStopGame = !MyGameControllor.IsStopGame;
        }

    }

}
