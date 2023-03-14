using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreHolder : MonoBehaviour
{
#region Field
    public TextMeshProUGUI  highScore_text;
    public IntVariableSO    highScore;
    public IntVariableSO    total_score_SO;
#endregion

#region Unity API
    void Start()
    {
        highScore_text.text = $"High Score: { highScore.value }";
    }
#endregion
    
#region Implementation
    public void SetHighScore()
    {
        if( highScore.value < total_score_SO.value )
            highScore.value = total_score_SO.value;

        highScore_text.text = $"High Score: { highScore.value }";
    }
#endregion
}
