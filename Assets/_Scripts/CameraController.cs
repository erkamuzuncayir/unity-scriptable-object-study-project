using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
#region Fields
    public GameObject        player;
    public Vector3VariableSO offset;
#endregion

#region Unity API
    void Start()
    {
        offset.value = transform.position - player.transform.position;
    }

    void LateUpdate()
    { 
        transform.position = player.transform.position + offset.value;
    }
#endregion
}
