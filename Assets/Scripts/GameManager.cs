using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Rigidbody charBody;
    [SerializeField] private GameObject failPopUp;
    [SerializeField] private GameObject endGamePopUp;
    [SerializeField] private Text scoreText;
    private bool fail;
    
    public void FreezeChar()
    {
        charBody.constraints = RigidbodyConstraints.FreezeAll;
    }   
    public void GameOver()
    {
        if (fail) return;
        fail = true;
        failPopUp.SetActive(true);
    }
    public void RestartGame()
    {
        fail = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        scoreText.text = "Score " + FindObjectOfType<Counter>().currentScore.ToString("0");
        endGamePopUp.SetActive(true);
    }

}
