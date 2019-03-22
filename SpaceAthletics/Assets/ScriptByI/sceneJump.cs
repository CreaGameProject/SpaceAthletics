using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneJump : MonoBehaviour {

    [SerializeField] int nowScene;

    public enum sceneNum {StartScene =0 ,MainScene =1, ScoreScene = 2, EndScene = 3, PoseScene = 4};
    string sceneName;

    // Use this for initialization
    void Start() {

        Debug.Log((sceneNum)Enum.ToObject(typeof(sceneNum), nowScene));

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.RightShift) && nowScene !=4)
        {
            SceneJamp();
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) &&  nowScene ==2)
        {
            PoseJump();
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && nowScene == 4)
        {
            nowScene = 2;
            SceneManager.UnloadScene("PoseScene");
        }

    }

    public void SceneJamp()
    {
        var scene = (sceneNum)Enum.ToObject(typeof(sceneNum), nowScene);
        sceneName = scene.ToString();

        SceneManager.LoadSceneAsync(sceneName);
    }

    public void PoseJump()
    {
        nowScene = 4;

        var scene = (sceneNum)Enum.ToObject(typeof(sceneNum), 4);
        sceneName = scene.ToString();

        SceneManager.LoadSceneAsync(sceneName , LoadSceneMode.Additive);
    }

}
