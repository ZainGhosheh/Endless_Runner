using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void Start(){
        GameManager.Instance.onPlay.AddListener(ActivatePlayer);
    }

    private void ActivatePlayer()
    {
        gameObject.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            GameManager.Instance.gameOver();
        }

    }
}
