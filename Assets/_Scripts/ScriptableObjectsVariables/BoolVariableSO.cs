using UnityEngine;

[CreateAssetMenu( fileName ="BoolVariableSO", menuName="ScriptableObjects/Variables/BoolVariable")]
public class BoolVariableSO : ScriptableObject
{
#region Fields
    public bool value;
#endregion

#region Editor Only
#if UNITY_EDITOR
    [ TextArea ]
    public string Description = "";
#endif
#endregion
}
