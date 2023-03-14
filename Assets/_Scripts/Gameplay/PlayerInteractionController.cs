using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
#region Fields
    public GameEventSO      event_collectable_pickUp;
    public GameEventSO      event_game_finished;
    public GameEventSO      event_game_finished_end_state; // Info: for determine win or lose state
    public IntVariableSO    collectable_total_count;
#endregion

#region Unity API
    void OnTriggerEnter( Collider other )
    {
        event_collectable_pickUp.Raise();

        other.gameObject.SetActive( false );

        var isCollectableFoe = other.gameObject.
                                GetComponent< CollectableSettings >().isCollectableFoe.Value;
        if ( isCollectableFoe )
        {
            FinishGame( false ); // Info: false for lose state
            /* 
             * Why: If we don't use return, we must set value for "foe collectables". 
             * Otherwise we'll confront nullReferenceException. Therefore, we use. */
            return;
        }

        var collectablePoint = other.gameObject.
                                GetComponent< CollectableSettings >().collectablePoint.Value;
        CollectObject( collectablePoint );
        
        if ( collectable_total_count.value < 1 ) // Why: This is a win situation
            FinishGame( true ); // Info: true for win state
    }
#endregion

#region Implementations
    void CollectObject( int point )
    {
        event_collectable_pickUp.Raise( point );
    }

    void FinishGame( bool isPlayerWin )
    {
        event_game_finished_end_state.Raise( isPlayerWin ); // Info: true for win state
        event_game_finished.Raise();
    }
#endregion
}