using UnityEngine;
using UnityEngine.UI;

public class DragonBallWin : MonoBehaviour
{
    // gọi đến UICanvas win
    public GameObject winCanvas;

    // hàm di chuyển của người chơi
    public MonoBehaviour playerMovement;

    // canvas được ẩn đi khi game bắt đầu
    void Start()
    {
        if (winCanvas != null)
        {
            winCanvas.SetActive(false);
        }
    }

    // phát hiện va chạm với người chơi
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowWinScreen();
        }
    }

    // Hiển thị màn hình chiến thắng
    void ShowWinScreen()
    {
        // hiển thị màn camvas win
        if (winCanvas != null)
        {
            winCanvas.SetActive(true);
        }

        
       

        // tắt chuyển động của người chơi khi trò chơi kết thúc 
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        // tạm dừng thời gian 
        Time.timeScale = 0f;
    }

 
}