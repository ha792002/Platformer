
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    
    [SerializeField] private Text WIN;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "WIN")
        {
            WIN.gameObject.SetActive(true);
        }
    }
}
