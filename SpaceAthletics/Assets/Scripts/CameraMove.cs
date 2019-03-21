using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject player;
    [SerializeField]
    GameObject planet;

    [SerializeField]
    float cameraMaxDistance;
    [SerializeField]
    float cameraMinDistance;
    [SerializeField]
    float cameraMajorDistance;
    float cameraDistance;
    [SerializeField]
    float rotateSpeed;

    float inputHorizontal;
    float inputVertical;

    Vector3 normalVector;//プレイヤーに働く法線ベクトル
    Vector3 planeVector;//プレイヤーの平面ベクトル
    Vector3 cameraPlaneVector;//カメラからキャラクターに伸ばしたベクトル

    // Use this for initialization
    void Start() {
        normalVector = planet.GetComponent<GravityController>().normalVector;
        planeVector = player.GetComponent<CharacterForce>().planeVector;

   
    }

    // Update is called once per frame
    void Update() {
        cameraDistance = CharacterCameraDistance();
        ControllerManager();
    }

    private float CharacterCameraDistance()//キャラクターとカメラの間の距離を算出
    {
        cameraPlaneVector = player.transform.position - transform.position;
        cameraDistance = cameraPlaneVector.magnitude;

        return cameraDistance;
    }

    private void ControllerManager()//コントローラーの入力を取る
    {
        inputHorizontal = Input.GetAxis("Horizontal2");
        inputVertical = Input.GetAxis("Vertical2");
    }

    private void CameraMoving()//カメラの移動，座標更新，向きの転換を実施
    {
        if (inputHorizontal != 0 && inputVertical != 0)//入力ナシ
        {




        }
    }
}
