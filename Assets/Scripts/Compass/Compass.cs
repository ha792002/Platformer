using UnityEngine;

public class Compass : MonoBehaviour
{
    void Start()
    {
        // Ẩn la bàn ngay từ đầu game
        gameObject.SetActive(false);
    }

    public void RevealCompass()
    {
        // Hiện la bàn khi được gọi
        gameObject.SetActive(true);
    }
}