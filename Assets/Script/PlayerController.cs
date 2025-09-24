using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float laneWidth = 2f;   // Abstand zwischen den Lanes
    public int laneCount = 5;      // Anzahl der Lanes
    public float moveSpeed = 5f;   // Geschwindigkeit beim Verschieben
    public float blockRange = 1.5f; // Reichweite zum Blocken
    private int currentLane = 2;   // Start in der Mitte (0-4)
    private Vector3 targetPosition;
    public bool canmove = true;
    private int hitCount = 0;
    public int maxHits = 5;


    void Start()
    {
        // Spieler startet in der mittleren Lane
        targetPosition = transform.position;
        targetPosition.x = (currentLane - (laneCount / 2)) * laneWidth;
        transform.position = targetPosition;
    }

    [System.Obsolete]
    void Update()
    {
        if (!GameManager.Instance.IsRunning) return;

        HandleInput();

        // Smooth Movement zur Zielposition
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        // Blocken mit Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Block();
        }
    }



    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < laneCount - 1 && canmove == true)
        {
            currentLane++;
            SetTargetPosition();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0 && canmove == true)
        {
            currentLane--;
            SetTargetPosition();
        }
    }

    public void test()
    {
        StartCoroutine(DisablePlayerMovement());
    }
    public IEnumerator DisablePlayerMovement()
    {
        canmove = false;
        yield return new WaitForSeconds(0.5f); // waits for customizable duration
        Debug.Log("Test");
        canmove = true;

    }



    void SetTargetPosition()
    {
        targetPosition = transform.position;
        targetPosition.x = (currentLane - (laneCount / 2)) * laneWidth;
    }

    [System.Obsolete]
    void Block()
    {
        // Alle Gegner in Szene finden
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            // Check: gleiche Lane?
            float laneX = (currentLane - (laneCount / 2)) * laneWidth;
            if (Mathf.Abs(enemy.transform.position.x - laneX) < 0.1f)
            {
                // Check: Gegner nah genug?
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance <= blockRange)
                {
                    enemy.Blocked();
                    Debug.Log("Enemy geblockt!");
                    return; // Nur einen Gegner blocken
                }
            }
        }

        Debug.Log("Block ausgeführt, aber kein Gegner getroffen.");
    }

}
