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
    Transform playerTransform;//キャラのTransformのインスタンス
    Transform planeTransform;//正面ベクトル算出用のTransform;
    //Vector3 playerPos;/*= new Vector3();*///キャラの座標
    GravityController gravityController = new GravityController();//GraivityControllerクラスのインスタンス生成
    Vector3 normalVector;//法線ベクトルのインスタンス
    Vector3 planeVector;//正面方向のベクトルのインスタンス

    //[SerializeField]
    //float power;//キャラに加える力

	// Use this for initialization
	void Start () {
        playerRigidbody = player.GetComponent<Rigidbody>();//インスタンス格納
        playerTransform = player.transform;//〃
        planeTransform = plane.GetComponent<Transform>();
        gravityController = planet.GetComponent<GravityController>();
	}
	
	// Update is called once per frame
	void Update () {
        normalVector = gravityController.normalVector;
        planeVector = PlayerPlaneVector(planeTransform,playerTransform);
        //CharacterMove(planeVector);
        CharacterStandingManager(planeVector,normalVector,playerTransform);
        //Debug.Log(planeTransform.position);
	}

    public Vector3 PlayerPlaneVector(Transform planeTransform,Transform playerTranform)//キャラクターの正面ベクトルを求める
    {
        planeVector = planeTransform.position - playerTransform.position;
        return planeVector;
    }

    private void CharacterMove(Vector3 planeVector)//キャラ移動（仮置き）
    {
        //playerRigidbody.AddForce(planeVector * power);
        //return playerTransform.position;
    }

    private void CharacterStandingManager(Vector3 planeVector,Vector3 normalVector,Transform playerTransform)//姿勢制御
    {
        playerTransform.rotation = Quaternion.LookRotation(planeVector,normalVector);
        Debug.Log("planeVectorは" + planeVector + "，normalVectorは" + this.normalVector);
        //return Quaternion.LookRotation(planeVector, normalVector);
    }
}
