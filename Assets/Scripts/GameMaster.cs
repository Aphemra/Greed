using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static int GlobalFormatIndex = 0;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 50;
    }

    public void SetFormat(int formatIndex)
    {
        if (formatIndex >= 0 && formatIndex < 3)
            GlobalFormatIndex = formatIndex;
    }
}