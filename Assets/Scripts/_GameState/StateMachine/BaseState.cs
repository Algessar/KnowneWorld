public abstract class BaseState : IState
{
    // What classes does this one need to know about? Animator and controller arent relevant.
    // 
    protected readonly CombatManager combatManager;


    public virtual void OnEnter()
    {
        // noop
    }

    public virtual void OnExit()
    {
        // noop
    }

    public virtual void Update()
    {
        // noop
    }
}
