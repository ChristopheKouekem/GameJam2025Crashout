using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(SpriteRenderer))]
public class FallingText : MonoBehaviour
{
    public float fallSpeed;

    void Update()
    {
        // Text nach unten bewegen
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Prüfen, ob das getroffene Objekt die Barrier ist
        if (collision.gameObject.CompareTag("Barrier"))
        {

            // Punkte hinzufügen
            ScoreManager.Instance.AddScore(1); // z.B. 10 Punkte pro Text

            Destroy(gameObject); // Text zerstören
        }



        // FallingText.cs (im Player-Collision-Block)
        if (collision.gameObject.CompareTag("Player"))
        {

            var playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {

                // Nur Gegner in derselben Lane verschieben
                Enemy[] enemies = FindObjectsOfType<Enemy>();
                float playerLaneX = playerController.transform.position.x;

                foreach (Enemy enemy in enemies)
                {
                    if (Mathf.Abs(enemy.transform.position.x - playerLaneX) < 0.2f)
                    {
                        enemy.NudgeDown(2f);
                    }
                }
            }

            Destroy(gameObject); // Text zerstören
        }

    }

}




// Alternativ Trigger, wenn Barrier IsTrigger hat:
/*
private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Barrier"))
    {
        Destroy(gameObject);
    }
}
*/

