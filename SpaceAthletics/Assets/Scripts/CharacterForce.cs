using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterForce : MonoBehaviour {

    [SerializeField]
    GameObject player;//キャラのインスタンス
    [SerializeField]
    GameObject plane;//正面ベクトル算出用のオブジェクト
    [SerializeField]
    GameObject planet;//惑星

    Rigidbody playerRigidbody;//キャラのRigidbodyのインスタンス
    GravityController gravityController = new GravityController();//GraivityControllerクラスのインスタンス生成
    public Vector3 normalVector;//法線ベクトルのインスタンス
    public Vector3 planeVector;//正面方向のベクトルのインスタンス

    [SerializeField]
    float runSpeed;//キャラに加える力
    [SerializeField]
    float lowSpeed;//通常移動
    [SerializeField]
    float highSpeed;//ダッシュ移動
    [SerializeField]
    float jumpPower;//ジャンプの高さ
    float inputVertical;//コントローラーの前後方向の入力
    float inputHorizontal;//コントローラーの左右方向の入力
    private Animator animator;
    bool goSign;//キャラを動かすかどうかの判定用
    bool jumpingFlag = true;//キャラのジャンプ判定

    // Use this for initialization
    void Start() {
        playerRigidbody = GetComponent<Rigidbody>();//インスタンス格納
        gravityController = planet.GetComponent<GravityController>();
        planeVector = plane.transform.position - transform.position;//正面ベクトルを仮代入
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        normalVector = gravityController.normalVector;//移動後の法線ベクトルを取得
        planeVector = CharacterStandingManager(planeVector, normalVector);//姿勢制御後の正面ベクトルを代入
        InputManager();//コントローラーの入力を取る
        planeVector = CharacterDirection();//キャラの向きを更新した後の正面ベクトルを代入
        CharacterMove(planeVector);//正面ベクトルの方向に力をかけてキャラを移動
    }

    private void FixedUpdate()
    {

    }

    private void InputManager()//コントローラーの入力を取る
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
    }

    private Vector3 CharacterDirection()//キャラの方向を決める
    {
        //カメラからプレイヤーに向かって作成した単位ベクトルをプレイヤーが立つ平面に投影させ，カメラ基準の「前方」成分を作成
        Vector3 controllerBase = Vector3.ProjectOnPlane((transform.position - Camera.main.transform.position).normalized, normalVector);
        //↑で求めた前方方向のベクトルと法線ベクトルとの外積から横移動のベクトルを作成
        Vector3 rightBase = Vector3.Cross(normalVector, controllerBase);

        //コントローラーの傾きに応じてそれぞれの成分にキャラの向きを変える
        if (inputVertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(controllerBase * inputVertical, normalVector);
            goSign = true;
        }
        if (inputHorizontal != 0)
        {
            transform.rotation = Quaternion.LookRotation(rightBase * inputHorizontal, normalVector);
            goSign = true;
        }
        //キャラが動いていないときはキャラの向きを変えない
        if (inputHorizontal == 0 && inputVertical == 0)
        {
            goSign = false;
        }

        planeVector = plane.transform.position - transform.position;//正面ベクトルを向きを変えた後に更新
        return planeVector;//更新した正面ベクトルを戻り値として返す
    }

    private Vector3 CharacterStandingManager(Vector3 planeVector,Vector3 normalVector)//姿勢制御
    {
        //移動前の正面ベクトルと移動後の法線ベクトルから移動後の正面ベクトルを生成
        planeVector = Vector3.ProjectOnPlane(planeVector,normalVector);
        //Quaternionで↑の正面ベクトルに合う姿勢にキャラを回転
        transform.rotation = Quaternion.LookRotation(planeVector,normalVector);
        return planeVector;//移動後の正面ベクトルを戻り値として返す
    }

    private void CharacterMove(Vector3 planeVector)//キャラ移動のメソッド
    {
        if (goSign == true)
        {
            playerRigidbody.AddForce(planeVector * runSpeed);//キャラの正面方向に力を加える
        }

        if (Input.GetKey(KeyCode.LeftShift))//シフトキーを押すとダッシュ
        {
            runSpeed = highSpeed;//ダッシュ
        }
        else
        {
            runSpeed = lowSpeed;//通常
        }
    }
}
