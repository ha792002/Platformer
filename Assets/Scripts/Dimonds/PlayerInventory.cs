
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfDiamonds {  get; private set; } // số lượng kim cương thu thập được 
    public UnityEvent<PlayerInventory> OnDiamondCollected;
    public void DiamondCollected()
    {
        NumberOfDiamonds ++;
        OnDiamondCollected.Invoke(this);
    }
}
