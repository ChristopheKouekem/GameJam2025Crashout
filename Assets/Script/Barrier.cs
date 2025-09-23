using UnityEngine;

public class Barrier : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Überprüfen, ob das Objekt ein "FallingText"-Tag hat
        if (collision.gameObject.CompareTag("FallingText"))
        {
            Destroy(collision.gameObject);
        }
    }
}
