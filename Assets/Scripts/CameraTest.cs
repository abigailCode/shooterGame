using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour {

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Z)) { CameraShake.Shake(0.5f, 0.15f); }
        
    }
}
