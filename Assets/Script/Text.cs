using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FallingText : MonoBehaviour
{
    public float fallSpeed = 2.0f;

    void Update()
    {
        // Text nach unten bewegen
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Prüfen, ob das getroffene Objekt die Barrier ist
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject); // sich selbst zerstören
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            // Change the sorting order to bring the sprite in front (example value)
            Destroy(gameObject); // sich selbst zerstören

            // Beispiel: Zugriff auf das andere Skript und canMove ändern
            var playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController.canmove != false)
                collision.gameObject.GetComponent<PlayerController>().test();


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

