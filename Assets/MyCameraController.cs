﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour {


    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    //UnityちゃんとCameraの距離
    private float difference;


    // Use this for initialization
    void Start () {

        //Unityちゃん  Objetを取得
        this.unitychan = GameObject.Find("unitychan");

        //UnityちゃんとCameraの位置（z座標）の差を求める
        this.difference = 
            unitychan.transform.position.z - this.transform.position.z;

    }
	
	// Update is called once per frame
	void Update () {

        ////Unityちゃんの位置に合わせてCameraの位置を移動
        this.transform.position =
            new Vector3(
                0,
                this.transform.position.y,
                this.unitychan.transform.position.z - difference);
                //常にUnitiyちゃんとCameraの距離は一定ということ
		
	}


}
