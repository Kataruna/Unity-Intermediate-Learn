using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class State
{
    public UnityEvent OnStateChanaged;

    public enum STATE
    {
        IDLE,
        PATROL
    }

    public enum EVENT
    {
        ENTER,
        UPDATE,
        EXIT
    }

    public STATE Name; //State นี้คืออะไร
    protected EVENT Stage; //กำลังทำอะไรอยู่ใน State นี้
    protected State NextState; //จะไป State ไหน

    protected Enemy Me;
    protected NavMeshAgent Agent;

    public State(Enemy character, NavMeshAgent agent)
    {
        Me = character;
        Agent = agent;

        Stage = EVENT.ENTER;
    }

    /// <summary>
    /// What to do on Enter this stage
    /// </summary>
    public virtual void Enter()
    {
        Stage = EVENT.UPDATE;

        Debug.Log($"Enter {Name} State");
    }

    /// <summary>
    /// What to do when is in this stage. Including condition to change stage.
    /// *You need to Implement "Stage = EVENT.EXIT" on Change Stage by yourself*
    /// </summary>
    public virtual void Update()
    {
        Stage = EVENT.UPDATE;
    }

    /// <summary>
    /// What to do on Exit this stage (Wrap-up)
    /// </summary>
    public virtual void Exit()
    {
        Stage = EVENT.UPDATE;

        Debug.Log($"Exit {Name} State");
    }

    public State Process()
    {
        if(Stage == EVENT.ENTER)
        {
            Enter();
        }

        if(Stage == EVENT.UPDATE)
        {
            Update();
        }

        if(Stage == EVENT.EXIT)
        {
            Exit();
            OnStateChanaged?.Invoke();
            return NextState;
        }

        return this;
    }
}
