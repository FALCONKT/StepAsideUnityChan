using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//(追加)

public class UnityChanController : MonoBehaviour {

    //Animation Component 　変数
    private Animator myAnimator;

    //Unityちゃんを移動させるComponent　変数（追加）
    private Rigidbody myRigidbody;

    //前進させる力　変数（追加）
    private float forwardForce = 800.0f;

    //左右に移動するための力 変数（追加）
    private float turnForce = 500.0f;

    //Jampするための力（追加）
    private float upForce = 500.0f;

    //左右の移動できる範囲　変数（追加）
    //★x座標の　幅
    private float movableRange = 3.4f;

    //動きを減速させる　変数　(追加)
    private float coefficient = 0.95f;

    //Game終了　判定 変数　(追加)
    private bool isEnd = false;

    //Game終了時のText 変数　(追加)
    private GameObject stateText;


    //得点のText 変数　(追加)
    private GameObject scoreText;

    //得点 変数　初期化　(追加)
    private int score = 0;

    //左ボタン押下の判定（追加）
    //★Buttonが押されているか否かを判断するために　2値　で指定している
    private bool isLButtonDown = false;

    //右ボタン押下の判定（追加）
    //★Buttonが押されているか否かを判断するために　2値　で指定している
    private bool isRButtonDown = false;



    // Use this for initialization
    void Start () {



        //Animater のCommponent取得
        this.myAnimator = GetComponent<Animator>();
        //走るAnimation　開始
        this.myAnimator.SetFloat("Speed",1);

        //Rigidbodyの Commponentを取得（追加）
        this.myRigidbody = GetComponent<Rigidbody>();

        //Scene中の stateTextObjectを取得 (追加)
        this.stateText = GameObject.Find("GameResultText");

        //Scene中の scoreTextObjectを取得 (追加)
        this.scoreText = GameObject.Find("ScoreText");

    }
	
	// Update is called once per frame
	void Update () {


        //Game終了ならUnityちゃんの動きを減速する(追加)
        if (this.isEnd) {
            this.forwardForce *= this.coefficient;
            this.turnForce *= this.coefficient;
            this.upForce *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
         }


        //Unityちゃんに前方向の力を加える（追加）
        this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);


        //Unityちゃんを矢印KeyまたはButtonに応じて左右に移動させる（追加）

        //★←なのでX座標　‐
        //★　！！！！！！！！！！！！！！！！！！！！！！SP用の　UIButtonをClickしたとき || this.isLButtonDown　を追加
        if ( (Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown)  &&  -this.movableRange < this.transform.position.x){

            //左に移動　（追加）
            this.myRigidbody.AddForce(-this.turnForce, 0, 0);

        }
        //★→なのでX座標　＋
        //★　！！！！！！！！！！！！！！！！！！！！！！SP用の　UIButtonをClickしたとき || this.isRButtonDown　を追加
        else if ( (Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown)  &&  this.transform.position.x < this.movableRange) {

            //右に移動　（追加）
            this.myRigidbody.AddForce(this.turnForce, 0, 0);

        }

        //JumpStateの場合　は　Jump　に　False　を設定
        //★Animation　Object が　Jamp　という名前の場合　　いつもは　Jamp が　true  のため　false　にし、Jamp　していない
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }


        //Jampしていない時にSpaceが押されたらJamp
        //★Jampなのでy座標 　0.5fは地面付近にいるときのみという設定　いつでもOKだと多段Jampになってしまう
        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f) {
            
            //JampAnimation再生
            this.myAnimator.SetBool("Jump", true);

            //Unitiyちゃんに上方向の力を加える
            //★this.transform.up　で　通常移動　の緑方向の上　移動をしたことと同様になる　上方向
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }

 
    }
    //Update() END

    //Method 定義　Collider　はClass型　other は自由な変数名　衝突した　対象相手　自動認識！！！！！！！
    //この関数が呼ばれるためには少なくともどちらか一方の Object がInspecter での　Trigger Mode　である必要がある
    void OnTriggerEnter(Collider other){

        //障害物に衝突した場合　Game終了
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag") {
            this.isEnd = true;

            //stateTextにGAME OVERを表示（追加）
            this.stateText.GetComponent<Text>().text = "GAME OVER";
        }

        //Goal地点に到達した場合
        if (other.gameObject.tag == "GoalTag") {
            this.isEnd = true;

            //stateTextに CLEAR を表示（追加）
            this.stateText.GetComponent<Text>().text = "CLEAR!";


        }

        //Coinに衝突した場合
        if (other.gameObject.tag == "CoinTag") {


            //Score加算(追加)
            this.score += 10;

            //ScoreTextに獲得点数を表示(追加)
            this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";



            //Perticleを再生(追加)
            GetComponent<ParticleSystem> ().Play();


            //接触したCoinObjectを破棄
            Destroy(other.gameObject);

        }


    }
    //OnTriggerEnter() END


    //JampButtonを押したときの　関数 (追加)
    public void GetMyJumpButtonDown(){

        //★y軸が0.5までの範囲で　という意味
        if (this.transform.position.y < 0.5f) {
            this.myAnimator.SetBool("Jamp", true);
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }
     //★　！！！！！PC用の　KeyをClickしたとき の条件分岐部も修正する  && の左側　()　閉じも重要

    //左Buttonを押し続けた場合の関数
    public void GetMyLeftButtonDown(){
        this.isLButtonDown = true;
    }

    //左Buttonを離した場合の関数
    public void GetMyLeftButtonUp(){
        this.isLButtonDown = false;
    }
    //★　！！！！！PC用の　KeyをClickしたとき の条件分岐部も修正する  && の左側　()　閉じも重要


    //右Buttonを押し続けた場合の関数
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }

    //右Buttonを離した場合の関数
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
    //★　！！！！！PC用の　KeyをClickしたとき の条件分岐部も修正する  && の左側　()　閉じも重要




}
//class END
