using UnityEngine;

public class TestItem : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        Debug.Log("You're healthier. 'cause you ate vegetable");

        Destroy(gameObject);
    }
}
