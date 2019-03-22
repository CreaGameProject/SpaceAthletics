using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject player;
    [SerializeField]
    GameObject planet;

    [SerializeField]
    float cameraMaxDistance;//最大距離
    [SerializeField]
    float cameraMinDistance;//最小距離
    float cameraDistance;//カメラの距離
    float cameraAngle;//カメラの角度
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    float zoomSpeed;

    public float inputHorizontal;
    float inputVertical;

    float inputHorizontal2;
    float inputVertical2;

    Vector3 normalVector;//プレイヤーに働く法線ベクトル
    Vector3 planeVector;//プレイヤーの平面ベクトル
    Vector3 cameraPlaneVector;//カメラからキャラクターに伸ばしたベクトル

    // Use this for initialization
    void Start() {
        //cameraDistance = 3;
        normalVector = planet.GetComponent<GravityController>().normalVector;
        planeVector = player.GetComponent<CharacterForce>().planeVector;
        
   
    }

    // Update is called once per frame
    void Update() {
        cameraDistance = CharacterCameraDistance();
        ControllerManager();
        CameraMoving();

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
        if (inputHorizontal != 0)//横方向の入力有
        {
            cameraAngle += rotateSpeed;
        }

        if (inputVertical != 0)//縦方向の入力有
        {
            cameraDistance -= zoomSpeed;
        }

        if (cameraDistance > cameraMaxDistance)
        {
            cameraDistance = cameraMaxDistance;
        }
        else if (cameraDistance < cameraMinDistance)
        {
            cameraDistance = cameraMinDistance;
        }

        transform.localPosition = new Vector3(Mathf.Sin(cameraAngle) * cameraDistance, Mathf.Sin(cameraAngle / 180 * Mathf.PI) * cameraDistance, Mathf.Cos(cameraAngle) * -cameraDistance);
        transform.LookAt(transform.parent);
    }
}