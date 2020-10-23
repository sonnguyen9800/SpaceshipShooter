using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveUI : MonoBehaviour
{
    [SerializeField]
    private WaveManager waveManager;
    [SerializeField]
    private TextMeshProUGUI waveText;
    void Start()
    {
        waveManager.OnWaveChanged += UpdateWaveText;
        waveManager.OnFinished += UpdateWaveFinishedText;
        UpdateWaveText();
    }

    private void UpdateWaveText()
    {
        waveText.SetText(string.Format("Wave: {0}/{1}", waveManager.CurrentWaveIndex + 1, waveManager.WaveCount));
    }
    private void UpdateWaveFinishedText()
    {
        waveText.SetText("Victory");
    }
}
