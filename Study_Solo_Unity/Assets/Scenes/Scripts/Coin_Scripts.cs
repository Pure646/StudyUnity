using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using static UnityEditorInternal.ReorderableList;

public class Coin_Scripts : MonoBehaviour
{
    private void OnDestroy()
    {
        Debug.Log("Coin Dead");
    }
}
