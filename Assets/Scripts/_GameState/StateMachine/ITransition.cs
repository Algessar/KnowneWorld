public interface ITransition
{
    IState To { get; }
    Ipredicate Condition { get; }
}
