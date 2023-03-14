using UnityEngine;
using TMPro;

public class CollectableCounter : MonoBehaviour
{
#region Fields
    public TextMeshProUGUI  ui_text_count;
    public IntVariableSO    collectable_total_count;
#endregion

#region Unity API
    void Start()
    {
        ui_text_count.text = $"Collectable Left: { collectable_total_count.value }";
    }
    #endregion

    #region Implementation
    public void SetCountText()
    {
        /*
         * Why : We decrease collectable count in here. Because if we do in PlayerInteractionController,
         * we have to listen one more event. I thought this is better use, instead of listening to one more event. */
        collectable_total_count.value--;
        ui_text_count.text = $"Collectable Left: { collectable_total_count.value }";
    }
#endregion
}
