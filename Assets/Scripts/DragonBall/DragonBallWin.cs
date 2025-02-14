using UnityEngine;
using UnityEngine.UI;

public class DragonBallWin : MonoBehaviour
{
    // Reference to the UI Canvas that contains the win screen
    public GameObject winCanvas;

    // Optional: Reference to win sound effect
    public AudioSource winSound;

    // Optional: Reference to player movement script
    public MonoBehaviour playerMovement;

    // Make sure canvas is hidden at start
    void Start()
    {
        if (winCanvas != null)
        {
            winCanvas.SetActive(false);
        }
    }

    // Detect collision with player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowWinScreen();
        }
    }

    // Show win screen and handle game state
    void ShowWinScreen()
    {
        // Show the win canvas
        if (winCanvas != null)
        {
            winCanvas.SetActive(true);
        }

        // Play win sound if assigned
        if (winSound != null)
        {
            winSound.Play();
        }

        // Optional: Disable player movement when game is won
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        // Optional: Pause game time
        Time.timeScale = 0f;
    }

    // Optional: Method to restart game
    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
}