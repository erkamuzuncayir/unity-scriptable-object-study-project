using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Vector3VariableSO", menuName ="ScriptableObjects/Variables/Vector3 Variable")]
public class Vector3VariableSO : ScriptableObject
{
#region Fields
    public Vector3 value;
#endregion

#region Editor Only
#if UNITY_EDITOR
    [ TextArea ]
    public string Description = "";
#endif
#endregion
}
