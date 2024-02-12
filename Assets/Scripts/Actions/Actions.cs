using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class Actions 
{
    ITargetable target;

    //Movement Actions

    public virtual void Move( Character character )
    {
        character._actionPoints -= 1;
    }

    public virtual void Dash( Character character )
    {
        character._actionPoints -= 2;
        //Spend an additional AP to move faster. Enemy hit chance against you decreases by 5.
    }

    //I might actually forgo run/sprint. It's not necessary when you can just stack Action point spending to move further
    //public virtual void Sprint( Character character )
    //{
    //    character._actionPoints -= 1;
    //}

    //Melee Combat Actions
    public virtual void Attack(Character character, ITargetable target)
    {
        ITargetable targetable = target;
        character._actionPoints -= 1;
        character._bonusDamageMod += 0;
    }

    public virtual void Block( Character character, ITargetable target, int damage )
    {
        
        character._actionPoints -= 1;
        character.TakeDamage(damage, damage); //This looks very circular xD But feeding in the damage taken, then reducing the damage taken with damage done makes sense no?

    }

    public virtual void Disarm( Character character )
    {
        character._actionPoints -= 1;

    }

    //How the fuck am I going to handle avoidance in general?
    public virtual void Dodge( Character character )
    {
        character._actionPoints -= 1;

    }

    public virtual void Evade(Character character )
    {
        character._actionPoints -= 1;

    }

    public virtual void Feint(Character character )
    {
        character._actionPoints -= 1;
        //Decrease opponent
    }

    public virtual void Charge(Character character )
    {
        character._actionPoints -= 1;

    }

    public virtual void Parry(Character character )
    {
        character._actionPoints -= 1;

    }

    public virtual void Shove(Character character )
    {
        character._actionPoints -= 1;

    }

    public virtual void Mordhau(Character character )
    {
        character._actionPoints -= 2;

    }



}
