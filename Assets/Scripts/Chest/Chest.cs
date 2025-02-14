using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator animator;
    public Compass compassScript;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Open", true);

            if (compassScript != null)
            {
                compassScript.RevealCompass();
            }
        }
    }
}