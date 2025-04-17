using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayCoin();
            GameManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
