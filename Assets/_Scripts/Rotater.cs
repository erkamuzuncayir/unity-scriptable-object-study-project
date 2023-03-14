using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
#region Fields
    public FloatReference axis_x , axis_y, axis_z;
#endregion

#region Unity API
    void Update()
    {
        transform.Rotate( new Vector3( axis_x.Value, axis_y.Value, axis_z.Value ) * Time.deltaTime );
    }
#endregion
}
