﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {

    public GameObject player;//プレイヤーのインスタンス
    public Rigidbody playerRigidbody;//プレイヤーのRigidbody
    Rigidbody planetRigidbody;//惑星のRigidbody
    public float g;
    Transform playerTransform;
    Transform planetTransform;
    public Vector3 normalVector;
    //Vector3 playerPos;//プレイヤーの座標
    //Vector3 basePos;//惑星の座標
    
    // Use this for initialization
	void Start ()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();//以下全てインスタンス格納
        planetRigidbody = GetComponent<Rigidbody>();
        playerTransform = player.GetComponent<Transform>();
        planetTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        normalVector = GravityVector(planetTransform, planetTransform);
	}

    private void FixedUpdate()
    {
        GravityManager(normalVector);
    }

    public Vector3 GravityVector(Transform playerTransform,Transform planetTransform)
    {
        Vector3 playerPos = playerTransform.position;//引数のTransformから座標を入手
        Vector3 basePos = planetTransform.position;//〃
        Vector3 normalVector = basePos - playerPos;//法線ベクトルを計算
        normalVector = normalVector.normalized;//算出した法線ベクトルを単位ベクトルに変換
   
        return normalVector;//戻り値として法線単位ベクトルを返す
    }


    private void GravityManager(Vector3 normalVector)
    {


        Vector3 gravityScaler = g * normalVector * (planetRigidbody.mass * playerRigidbody.mass) / (normalVector.sqrMagnitude);
        playerRigidbody.AddForce(gravityScaler);
    }
}
