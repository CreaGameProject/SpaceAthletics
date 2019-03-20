using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject planet;

    [SerializeField]
    float cameraMaxDistance;
    [SerializeField]
    float cameraMinDistance;
    [SerializeField]
    float cameraMajorDistance;
    Vector3 normalVector;//プレイヤーに働く法線ベクトル
    Vector3 planeVector;//プレイヤーの平面ベクトル

    // Use this for initialization
    void Start() {
        normalVector = planet.GetComponent<GravityController>().normalVector;
        planeVector = player.GetComponent<CharacterForce>().planeVector;

        //cameraDistance = 
    }

    // Update is called once per frame
    void Update() {

    }

    private void CameraMoveRange()
    {
        
    }

    private void CameraStanding(Vector3 planeVector ,Vector3 normalVector)//カメラをキャラと同じ法線上に合わせる
    {

    }
}
