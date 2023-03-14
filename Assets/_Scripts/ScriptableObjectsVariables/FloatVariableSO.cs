using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariableSO", menuName = "ScriptableObjects/Variables/FloatVariable")]
public class FloatVariableSO : ScriptableObject
{
#region Fields
    public float value;
#endregion

#region Editor Only
#if UNITY_EDITOR
    [ TextArea ]
    public string Description = "";
#endif
#endregion
}
