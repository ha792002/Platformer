
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextDoor : MonoBehaviour
{
    public string sceneToLoad;  
    public Vector2 point1;  // góc đầu tiên (x, y) 
    public Vector2 point2;  //góc thứ 2 (x', y') 

    void Update()
    {

        //Kiểm tra xem người chơi có đang nằm trong khu vực hình chữ nhật được xác định bởi điểm 1 và điểm 2 hay không ?
        if (transform.position.x >= Mathf.Min(point1.x, point2.x) && transform.position.x <= Mathf.Max(point1.x, point2.x) &&
            transform.position.y >= Mathf.Min(point1.y, point2.y) && transform.position.y <= Mathf.Max(point1.y, point2.y))
        {
           

            // Cảnh tiếp theo
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}