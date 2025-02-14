using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager uiManager; //UI màn hình kết thúc sau khi người chơi chết 

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void RespawnCheck()
    {
        if (currentCheckpoint == null) 
        {
            uiManager.GameOver();
            return;
        }

        playerHealth.Respawn(); //phục hồi sức khỏe của người chơi và thiết lập hình ảnh 
        transform.position = currentCheckpoint.position; //di chuyển người chơi đến vị trí checkopion  

        //di chuyển máy quay đến vị trí checkpoin sau khi player chết 
        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;//cập nhập vị trí checkpoint
            SoundManager.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("activate");
        }
    }
}