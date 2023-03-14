using System;

[Serializable]
public class FloatReference
{
#region Fields
    public bool use_constant;
    public float constant_value;
    public FloatVariableSO variable;
#endregion

#region Implementations
    public float Value
    {
        get { return use_constant ? constant_value : 
                                    variable.value; }
    }
#endregion
}
