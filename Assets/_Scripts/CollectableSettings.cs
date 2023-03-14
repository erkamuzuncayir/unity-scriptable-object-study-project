using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSettings : MonoBehaviour
{
    #region Fields
    [ Header ( "Pick for foe, don't pick for friend" ) ]
    public BoolReference    isCollectableFoe;
    public IntReference     collectablePoint;
#endregion
}
