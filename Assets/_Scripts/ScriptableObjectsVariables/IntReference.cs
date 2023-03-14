using System;

[Serializable]
public class IntReference
{
#region Fields
    public bool use_constant;
    public int constant_value;
    public IntVariableSO variable;
#endregion

#region Implementations
    public int Value
    {
        get { return use_constant ? constant_value : 
                                    variable.value; }
    }
#endregion
}
