using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanvasCamera : MonoBehaviour
{
    Camera _camera;
    void Start()
    {
        _camera = FindAnyObjectByType<Camera>();
    }


}
