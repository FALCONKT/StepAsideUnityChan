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

    //★Game終了　判定 変数
    private bool isEnd = false;

    //★UnityちゃんのObject　変数  Goal時用
    private GameObject unitychanObjForItemD;
    //★Goal Object　変数   Goal時用
    private GameObject goal;


    // Use this for initialization
    void Start()
    {

        //★Camera  Objetを取得
        this.mainCamera = GameObject.Find("Main Camera");

        //★UnityちゃんのObject　を取得  Goal時用
        this.unitychanObjForItemD = GameObject.Find("unitychan");
        //★GilaのObject　を取得  Goal時用
        this.goal = GameObject.Find("Goal");

    }

    // Update is called once per frame
    void Update()
    {

        //★Cameraの手前奥の距離　取得

        this.difference = this.mainCamera.transform.position.z;

        //★参考　CameraとItemの位置（z座標）の差を求める
        //this.difference =
        //    mainCamera.transform.position.z - this.transform.position.z;


        //★　もしCameraのZ座標　が　Item自身のZ座標よりも大きければ～　自分自身を削除する

        if (this.difference > this.transform.position.z)
        {
            //削除命令　自分自身
            Destroy(this.gameObject);
        }

        //★Game終了なら　Item自身を削除する
        //★Goal地点に到達した場合 は　背後のItem全消去
        if (unitychanObjForItemD.transform.position.z > goal.transform.position.z)
        {
            this.isEnd = true;

            //stateTextに CLEAR を表示（追加）
            Destroy(this.gameObject);
        }


    }
    //void Update() END


}
//Class　END