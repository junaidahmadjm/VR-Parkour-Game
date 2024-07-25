using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._3DUI_SS24.VRParkourGame
{
    public class RaceCountDownTimer : MonoBehaviour
    {
        public float timeDuration;
        public float timeRemaining;
        public UnityEvent OnTimeExpiredEvent;
        [System.Serializable] public class OnTimeUpdatedEvent : UnityEvent<float> { }
        public OnTimeUpdatedEvent onTimeUpdated;
        [System.Serializable] public class OnTimeStoppeddEvent : UnityEvent<float> { }
        public OnTimeStoppeddEvent onTimeStoppeddEvent;

        private float timeStarted;
        private Boolean isRunning = false;
        private float timeElapsed;

        public GameObject GameOverPanel;

        public void Begin(float countDownTimeDuration)
        {
            timeDuration = countDownTimeDuration;
            timeStarted = Time.time;
            isRunning = true;
        }
        public void End()
        {
            isRunning = false;
            onTimeStoppeddEvent?.Invoke(timeRemaining);
        }
      
        void Update()
        {
            if (isRunning)
            {
                timeElapsed = Time.time - timeStarted;
                timeRemaining = Math.Max(timeDuration - timeElapsed, 0.0f);
                onTimeUpdated?.Invoke(timeRemaining);
                if (timeRemaining <= 0.0f)
                {
                    Debug.Log("Time Expired");

                    if (GameOverPanel)
                        GameOverPanel.SetActive(true);

                    if(OnTimeExpiredEvent!=null)
                        OnTimeExpiredEvent?.Invoke();
                    isRunning = false;
                }
            }
        }
    }
}