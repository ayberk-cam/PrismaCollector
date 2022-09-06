using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float currentTime;
    [SerializeField] private float startingTime = 60f;
    [SerializeField] private Text timeText;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        TimeSetter();
        if (currentTime <= 0)
        {
            currentTime = 0;
            FindObjectOfType<GameManager>().FreezeChar();
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void TimeSetter()
    {
        currentTime -= 1 * Time.deltaTime;
        timeText.text = "Time " +  currentTime.ToString("0");
    }
}
