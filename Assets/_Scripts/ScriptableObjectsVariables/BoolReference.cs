using System;

[Serializable]
public class BoolReference
{
#region Fields
    public bool use_constant;
    public bool constant_value;
    public BoolVariableSO variable;
#endregion

#region Implementations
    public bool Value
    {
        get { return use_constant ? constant_value : 
                                    variable.value; }
    }
#endregion
}
