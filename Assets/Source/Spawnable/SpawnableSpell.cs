using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnableSpell : PoolObject
{
    public  float damage;
    public Element element;

    public event Action Initialized;

    public virtual void Init(Spell spell)
    {
        damage = spell.GetDamage();
        element = spell.Element;
        Initialized?.Invoke();
    }
}