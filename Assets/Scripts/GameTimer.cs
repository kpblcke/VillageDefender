using System;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] float levelTime = 10;

    private Slider _slider;
    private bool timerFinished;
    
    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    void Update () {
        if (timerFinished) {return;}
        
        _slider.value = Time.timeSinceLevelLoad / levelTime;
        timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
        }
    }
}
