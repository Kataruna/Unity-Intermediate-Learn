using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    public bool _isPlayerInView = false;
    public NavMeshAgent _agent;
    
    private State _currentState;

    void Awake()
    {
        _currentState = new Idle(this, _agent);
    }

    void FixedUpdate()
    {
        _currentState = _currentState.Process();
    }
}
