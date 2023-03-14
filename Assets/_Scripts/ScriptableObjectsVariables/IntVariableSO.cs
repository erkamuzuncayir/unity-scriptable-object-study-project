using UnityEngine;

[CreateAssetMenu(fileName = "IntVariableSO", menuName = "ScriptableObjects/Variables/IntVariable")]
public class IntVariableSO : ScriptableObject
{
#region Fields
    public int value;
#endregion

#region Editor Only
#if UNITY_EDITOR
    [ TextArea ]
    public string Description = "";
#endif
#endregion
}
