using UnityEngine;

public class Item : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        // GameManager.Instance.Money = price;
        Debug.Log("Item Collected");

        Destroy(gameObject);
    }
}