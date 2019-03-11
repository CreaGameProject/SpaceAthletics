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
    Transform playerTransform;//プレイヤーのTransformのインスタンス
    Transform planeTransform;//正面ベクトル算出用のTransform;
    Vector3 playerPos;/*= new Vector3();*///キャラの座標
    Vector3 normalVector;//法線ベクトルのインスタンス
    Vector3 planeVector;//正面方向のベクトルのインスタンス
    [SerializeField]
    float power;//キャラに加える力

	// Use this for initialization
	void Start () {
        playerRigidbody = player.GetComponent<Rigidbody>();//インスタンス格納
        playerTransform = player.transform;//〃
        normalVector = planet.GetComponent<GravityController>().normalVector;
        planeTransform = plane.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        //playerPos = CharacterMove();
        CharacterStandingManager(normalVector);
	}

    public Vector3 PlayerPlaneVector()//キャラクターの正面ベクトルを求める
    {
        Vector3 planeObjectoVector = planeTransform.position;

        return planeVector;
    }

    private Vector3 CharacterMove()//キャラ移動（仮置き）
    {
        Vector3 Movement = new Vector3(0,0,1);
        playerRigidbody.AddForce(Movement * power);

        return playerTransform.position;
    }

    private void CharacterStandingManager(Vector3 normalVector)//姿勢制御
    {
        


    }

}
