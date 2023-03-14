using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
#region Fields
    public GameEventSO      event_game_finished;
    public GameEventSO      event_game_finished_end_state;
    public IntVariableSO    collectable_total_count;
    public TextMeshProUGUI  ui_text_time;
    public FloatReference   time_maximum;
    float                   time_remaining;
    public IntReference     time_interval;
#endregion

#region Unity API
    void Start()
    {
        ui_text_time.text = time_maximum.Value.ToString();
        time_remaining = time_maximum.Value;
        StartCoroutine( RunTheTimer() );
    }
#endregion

#region Implementation
    IEnumerator RunTheTimer()
    {
        while ( gameObject.activeInHierarchy && time_remaining > 0 )
        {
            yield return new WaitForSeconds( time_interval.Value );
            time_remaining--;
            ui_text_time.text = time_remaining.ToString();
        }
        if( collectable_total_count.value > 0 )
            event_game_finished_end_state.Raise( false ); // Why : This is for determine end state.

            event_game_finished.Raise(); // Why : This is for non-parameter methods.
    }
#endregion
}
