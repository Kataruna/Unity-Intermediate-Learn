using UnityEngine;

public class Character : MonoBehaviour
{
        [Header("Assign")]
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Rigidbody _rigidbody;

    protected float _speed;

    protected virtual void Movement()
    {

    }
}
