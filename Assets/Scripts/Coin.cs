using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private int price = 5;

    void PrintMessage(int i)
    {
        Debug.Log($"{name} knows that money is {i} | {transform.rotation}");

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void OnEnable()
    {
        GameManager.Instance.OnMoneyChanged.AddListener(PrintMessage);
        //ถ้าเงินเปลี่ยนแปลง ให้เรียกใช้ PrintMessage    
    }

    void OnDisable()
    {
        GameManager.Instance.OnMoneyChanged.RemoveListener(PrintMessage);
    }

    public void Collect()
    {
        GameManager.Instance.Money = price;

        Destroy(gameObject);
    }
}
