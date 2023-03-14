using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    #region Fields
    public List< GameEvent > tracking_game_events = new();
    #endregion

    #region Unity API
    void OnEnable()
    {
        foreach( var e in tracking_game_events )
        {
            if( e.tracking_event != null )
                e.tracking_event.RegisterListener( this );
        }
    }

    void OnDisable()
    {
        foreach ( var e in tracking_game_events )
        {
            if (e.tracking_event != null)
                e.tracking_event.UnregisterListener( this );
        }
    }
    #endregion

    #region Implementations
    public void OnEventRaised()
    {
        foreach( var e in tracking_game_events )
        {
            if( e.response_nonParam != null )
                e.response_nonParam.Invoke();
        }
    }

    public void OnEventRaised( int number )
    {
        foreach( var e in tracking_game_events )
        {
            if( e.response_nonParam != null )
                e.response_intParam.Invoke( number );
        }
    }

    public void OnEventRaised( string text )
    {
        foreach( var e in tracking_game_events )
        {
            if( e.response_nonParam != null )
                e.response_stringParam.Invoke( text );
        }
    }

    public void OnEventRaised( bool trueOrNot )
    {
        foreach( var e in tracking_game_events )
        {
            if( e.response_nonParam != null )
                e.response_boolParam.Invoke( trueOrNot );
        }
    }
}

// Info : This class provides us parameter passable responses for game events.
[System.Serializable]
public class GameEvent
{
    public GameEventSO          tracking_event;
    public UnityEvent           response_nonParam;
    public UnityEvent<int>      response_intParam;
    public UnityEvent<string>   response_stringParam;
    public UnityEvent<bool>     response_boolParam;
}
#endregion