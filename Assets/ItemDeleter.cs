using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//各Item　PrefubにAtatchする
public class ItemDeleter : MonoBehaviour
{
    //★　CameraのObject　変数
    private GameObject mainCamera;

    //★Cameraのz座標距離指定　変数
    private float difference;


    // Use this for initialization
    void Start()
    {

        //★Camera  Objetを取得
        this.mainCamera = GameObject.Find("Main Camera");

     }

    // Update is called once per frame
    void Update()
    {
        //★Cameraの手前奥の距離　取得
        this.difference = this.mainCamera.transform.position.z;

        //★参考　CameraとItemの位置（z座標）の差を求める
        //this.difference =
        //    mainCamera.transform.position.z - this.transform.position.z;


        //★　もしCameraのZ座標　が　自分自身のZ座標よりも小さければ～　自分自身を削除する
        if (this.difference > this.transform.position.z)
        {
             //削除命令　自分自身
            Destroy(this.gameObject);
        }


    }
    //void Update() END


}
//Class　END