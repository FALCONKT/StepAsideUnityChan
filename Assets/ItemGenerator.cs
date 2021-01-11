using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    //★Objects取得　3変数
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;


    //Start地点取得　変数
    private int startPos = -160;

    //Goal地点取得　変数
    private int goalPos = 120;
    
    //Itemを出すx方向の範囲　変数
    private float posRange = 3.4f;

   // //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝　発展

   ////UnityちゃんのObject 変数
   // private GameObject unitychanObj;

   // private float unitychanPoint;

   // private float unitychanPointTo40;


   // //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝



    // Use this for initialization
    void Start () {
        //開始時

        ////＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝　発展

        ////Unityちゃん  Objetを取得
        //this.unitychanObj = GameObject.Find("unitychan");


        ////＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝




        //z方向（画面奥方向）に15mずつあけてItemを生成
        for (int i = startPos; i < goalPos; i += 15)
        {

            //どのItemを出すのか乱数配置
            int num = Random.Range(1, 11);

            if (num <= 2)
            {

                for (float j = -1; j <= 1; j += 0.4f)
                {
                    //「Instantiate() as GameObject」は、()内に指定したPrefabのインスタンスをGameObject型として生成
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);

                }


            }
            else
            {
                //RaneごとにItemを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);

                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }


        }
        ////for文　END


    }
    //Start()　END




    // Update is called once per frame
    void Update () {

        ////＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝  発展

        ////Unityちゃん  ObjectのZ座標　動的に変化する　！！！！！
        //this.unitychanPoint = unitychanObj.transform.position.z;

        ////Unityちゃん  ObjectののZ座標の先40ｍ指定　動的に変化する　！！！！！
        //this.unitychanPointTo40 = unitychanPoint + 40;


        ////40ｍ(50ｍに変更も可能)にItem生成

        ////z方向（画面奥方向）に40ｍ内にItemを生成　40ｍごとに
        ////for (float i = startPos; i < goalPos; i += unitychanPointTo40)
        //for (float i = unitychanPoint; i < unitychanPointTo40; i += 40){

        //    //どのItemを出すのか乱数配置
        //    int num = Random.Range(1, 11);

        //    if (num <= 2)
        //    {

        //        //アイテムを置くZ座標のオフセットをランダムに設定 
        //        //!!!!!!!!!!!!!!!!!!!!!!!
        //        int offsetZ = Random.Range(10, 40);

        //        for (float j = -1; j <= 1; j += 10f)
        //        {
        //            //「Instantiate() as GameObject」は、()内に指定したPrefabのインスタンスをGameObject型として生成
        //            GameObject cone = Instantiate(conePrefab) as GameObject;
        //            cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i+offsetZ);

        //        }


        //    }
        //    else
        //    {
        //        //RaneごとにItemを生成
        //        for (int j = -1; j <= 1; j ++)
        //        {
        //            //アイテムの種類を決める
        //            int item = Random.Range(1, 11);

        //            //アイテムを置くZ座標のオフセットをランダムに設定 
        //            //!!!!!!!!!!!!!!!!!!!!!!!
        //            int offsetZ = Random.Range(10,40);


        //            //20%コイン配置:20%車配置:60%何もなし
        //            if (1 <= item && item <= 2)
        //            {
        //                //コインを生成
        //                GameObject coin = Instantiate(coinPrefab) as GameObject;
        //                //その3座標
        //                coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
        //            }
        //            else if (3 <= item && item <= 4)
        //            {
        //                //車を生成
        //                GameObject car = Instantiate(carPrefab) as GameObject;
        //                //その3座標
        //                car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
        //            }
        //        }
        //    }


        //}
        //for文　END
        //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝


    }
}
