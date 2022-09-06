using UnityEngine;

public class FallDetect : MonoBehaviour
{
    [SerializeField] private Rigidbody character;
    private void Update()
    {
        if (character.position.y < -10f)
        {
            FindObjectOfType<GameManager>().FreezeChar();
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
