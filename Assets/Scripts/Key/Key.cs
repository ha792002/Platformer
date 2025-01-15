using UnityEngine;

public class Key : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Health targetHealth; // Reference to Health component to monitor
    [SerializeField] private SpriteRenderer keySprite;
    [SerializeField] private BoxCollider2D keyCollider;

    private bool isKeyActivated = false;

    private void Start()
    {
        // Ẩn chìa khóa khi bắt đầu
        keySprite.enabled = false;
        keyCollider.enabled = false;

        // Kiểm tra xem có Health component được gán chưa
        if (targetHealth == null)
        {
            Debug.LogWarning("Health component is not assigned to Key script!");
        }
    }

    private void Update()
    {
        // Kiểm tra trạng thái của Health component
        if (targetHealth != null && !isKeyActivated && targetHealth.currentHealth <= 0)
        {
            ActivateKey();
        }
    }

    private void ActivateKey()
    {
        isKeyActivated = true;
        keySprite.enabled = true;
        keyCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isKeyActivated)
        {
            CollectKey();
        }
    }

    private void CollectKey()
    {
        keySprite.enabled = false;
        keyCollider.enabled = false;
        gameObject.SetActive(false);
    }
}