using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;
    

    private void Awake()
    {
        gameOverScreen.SetActive(false); //ẩn màn hình gameover khi bắt đầu trò chơi
    }

   
 

    #region Game Over Functions
    
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //bật màn hình kết thúc 
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //thoát trò chơi
    public void Quit()
    {
        Application.Quit(); 

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
        #endif
    }
    #endregion
}