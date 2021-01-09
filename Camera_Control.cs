using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    //生产变量，将object拖进去
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x, 0, -10f);//摄像机跟随人动
    }
}
