using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    private float timerDuration = 3f * 60f;

    private float mTime = 0;
    private string mTimeString;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    void ResetTimer()
    {
        mTime = timerDuration;
        UpdateTimerDisplay(mTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (mTime > 0)
        {
            mTime -= Time.deltaTime;
            UpdateTimerDisplay(mTime);
        }
        else
        {
            mTime = 0;
            UpdateTimerDisplay(mTime);
            Prospector.Instance.GameOver(false);
        }
    }

    void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}:{1:00}", minutes, seconds);
        GetComponent<Text>().text =  currentTime;
    }
}
