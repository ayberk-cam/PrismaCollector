using UnityEngine;
using UnityEngine.UI;
public class Counter : MonoBehaviour
{
    public int currentScore;
    [SerializeField] private int startingScore;
    [SerializeField] private Text scoreText;

    private void Start()
    {
        currentScore = startingScore;
    }

    private void Update()
    {
        ScoreSetter();
    }

    private void ScoreSetter()
    {
        scoreText.text = "Score " +  currentScore.ToString("0");
    }
    
    public void Incrementer()
    {
        currentScore += 1;
    }
}
