using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //回転を開始する角度を設定
        //★Y座標部が開始時のみ乱数的角度を導き適用
        this.transform.Rotate(0, Random.Range(0, 360), 0);
		
	}
	
	// Update is called once per frame
	void Update () {

        //回転
        //★Y座標部が3ずつ回転し続けている
        this.transform.Rotate(0, 3, 0);

    }
}
