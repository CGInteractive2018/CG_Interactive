using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {

    [SerializeField]
    private GameObject firstPersonCamera;   // インスペクターで主観カメラを紐づける
    [SerializeField]
    private GameObject thirdPersonCamera;   // インスペクターで第三者視点カメラを紐づける

    void Start() {
        thirdPersonCamera.SetActive(!thirdPersonCamera.activeInHierarchy);
    }

    void Update()
    {
        // スペースキーでカメラを切り替える
        if (Input.GetKeyDown("joystick button 5"))
        {
            // ↓現在のactive状態から反転 
            firstPersonCamera.SetActive(firstPersonCamera.activeInHierarchy);
            thirdPersonCamera.SetActive(!thirdPersonCamera.activeInHierarchy);
        }
    }
}
