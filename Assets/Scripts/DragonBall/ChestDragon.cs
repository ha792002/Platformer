using UnityEngine;

public class ChestDragon : MonoBehaviour
{
    public GameObject dragonBallPrefab;
    private Animator animator;
    private bool hasSpawnedDragonBall = false;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Hide dragon ball at start
        if (dragonBallPrefab != null)
        {
            dragonBallPrefab.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Open", true);

            // Spawn and show dragon ball
            if (!hasSpawnedDragonBall && dragonBallPrefab != null)
            {
                dragonBallPrefab.SetActive(true);
                hasSpawnedDragonBall = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Open", false);
        }
    }
}