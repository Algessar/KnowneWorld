public abstract class BaseState : IState
{
    // What classes does this one need to know about? Animator and controller arent relevant.
    // 
    protected readonly CombatManager combatManager;


    public void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
