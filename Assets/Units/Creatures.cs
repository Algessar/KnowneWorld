using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creatures : MonoBehaviour, IUnit, ITargetable
{
    public void DealDamage( int damage, int bonusDamage )
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage( int damage, int reduction )
    {
        throw new System.NotImplementedException();
    }
}
