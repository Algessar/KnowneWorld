using System;

public class FuncPredicate : Ipredicate
{
    readonly Func<bool> func;

    public FuncPredicate( Func<bool> func )
    {
        this.func = func;
    }
    public bool Evaluate() => func.Invoke();
}