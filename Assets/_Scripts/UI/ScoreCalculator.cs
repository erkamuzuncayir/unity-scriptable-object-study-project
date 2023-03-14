using TMPro;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
#region Fields
    public TextMeshProUGUI  ui_text_score;
    public IntVariableSO    total_score_SO;
#endregion

#region Unity API
    void Start()
    {
        total_score_SO.value = 0;
        ui_text_score.text = $"Score: { total_score_SO.value }";
    }
#endregion

#region Implementation
    public void SetScoreText( int score )
    {
        total_score_SO.value += score;
        ui_text_score.text = $"Score: { total_score_SO.value }";
    }
#endregion
}