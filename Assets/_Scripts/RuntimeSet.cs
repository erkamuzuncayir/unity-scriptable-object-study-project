using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet< T > : ScriptableObject
{
#region Fields
    public List< T > items = new();
#endregion

#region Implementations
    public void Initalize()
    {
        items.Clear();
    }

    public T GetItemIndex( int index )
    {
        return items[ index ];
    }

    public void AddToList( T thingToAdd )
    {
        if( !items.Contains( thingToAdd ) )
            items.Add( thingToAdd );
    }

    public void RemoveFromList( T thingToRemove )
    {
        if ( !items.Contains( thingToRemove ) )
            items.Remove( thingToRemove );
    }
#endregion
}
