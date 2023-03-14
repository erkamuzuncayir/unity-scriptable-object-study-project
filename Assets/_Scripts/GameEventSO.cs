using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEventSO", menuName = "ScriptableObjects/GameEvent")]
public class GameEventSO : ScriptableObject
{
#region Fields
    List< GameEventListener > event_listener_list = new();
#endregion

#region Implementations
    public void Raise()
    {
        for ( int i = event_listener_list.Count - 1; i >= 0; i-- )
            event_listener_list[ i ].OnEventRaised();
    }
    public void Raise(int point)
    {
        for ( int i = event_listener_list.Count - 1; i >= 0; i-- )
            event_listener_list[ i ].OnEventRaised( point );
    }    
    public void Raise(string text)
    {
        for ( int i = event_listener_list.Count - 1; i >= 0; i-- )
            event_listener_list[ i ].OnEventRaised( text );
    }    
    public void Raise(bool trueOrNot)
    {
        for ( int i = event_listener_list.Count - 1; i >= 0; i-- )
            event_listener_list[ i ].OnEventRaised( trueOrNot );
    }

    public void RegisterListener( GameEventListener listener )
    { 
        event_listener_list.Add( listener ); 
    }

    public void UnregisterListener( GameEventListener listener )
    { 
        event_listener_list.Remove( listener ); 
    }
    #endregion

#region Editor Only
#if UNITY_EDITOR
    [ TextArea ]
    public string Description = "";
#endif
#endregion
}