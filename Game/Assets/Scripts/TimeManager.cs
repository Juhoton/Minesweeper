using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI timerText;
    float elapsedTime = 0f;
    bool measuringTime = false;

    public void StartTimer()
    {
        elapsedTime = 0f;
        measuringTime = true;
    }

    public void StopTimer()
    {
        measuringTime = false;
        Debug.Log("Elapsed Time: " + elapsedTime + " seconds");
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        Debug.Log("Timer Reset");
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!measuringTime)
            return;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        elapsedTime += Time.deltaTime;
        //timerText.text = $"Time: {elapsedTime:F2}s";
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
