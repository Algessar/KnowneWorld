public class Transition : ITransition
{
    public IState To { get; }

    public Ipredicate Condition { get; }

    public Transition(IState to, Ipredicate condition )
    {
        To = to;
        Condition = condition;
    }
}
