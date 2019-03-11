using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterForce : MonoBehaviour {

    [SerializeField]
    GameObject player;//キャラのインスタンス
    Rigidbody playerRigidbody;//キャラのRigidbodyのインスタンス
    Transform playerTransform;//Transformのインスタンス
    Vector3 playerPos;/*= new Vector3();*///キャラの座標
    [SerializeField]
    float g;//キャラに加える力

	// Use this for initialization
	void Start () {
        playerRigidbody = player.GetComponent<Rigidbody>();//インスタンス格納
        playerTransform = player.transform;//〃
	}
	
	// Update is called once per frame
	void Update () {
        playerPos = CharacterMove();
        CharacterStandingManager(playerPos);
	}

    private Vector3 CharacterMove()//キャラ移動（仮置き）
    {
        Vector3 Movement = new Vector3(0,0,1);
        playerRigidbody.AddForce(Movement * g);

        return playerTransform.position;
    }

    private void CharacterStandingManager(Vector3 playerPos)//姿勢制御
    {

    }

}
