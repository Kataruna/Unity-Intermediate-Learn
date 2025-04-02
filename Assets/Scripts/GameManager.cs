using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : Singleton<GameManager>
{
    public UnityEvent<int> OnMoneyChanged;

    public List<ICollectable> allCollectableObjects;

    private int _money;
    public int Money
    {
        get => _money;
        set
        {
            //value is came from
            //Money = 123456
            //123456 = 
            _money += value;

            OnMoneyChanged.Invoke(_money);
        }
    }
}