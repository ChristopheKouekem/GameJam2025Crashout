using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private bool isBlocked = false;

    private PlayerController player;
    private ScoreManager scoreManager;

    [System.Obsolete]
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if (isBlocked) return;

        // Richtung Spieler
        // transform.position = Vector3.MoveTowards(
        //     transform.position,
        //     player.transform.position,
        //     speed * Time.deltaTime
        // );

        // Wenn nah genug -> Player stirbt
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 0.5f)
        {
            Destroy(gameObject);
        }
    }


    public void NudgeDown(float amount = 0.5f)
    {
        transform.position += Vector3.down * amount;
    }


    public void Blocked()
    {
        isBlocked = true;
        scoreManager.AddScore(3);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.CompareTag("Bitte klapp"))
        {
            Debug.Log("Test");
            GameManager.Instance.GameOver();
        }
    }

}
