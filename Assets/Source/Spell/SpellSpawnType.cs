using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellSpawnType : MonoBehaviour
{
    public abstract int Count { get; set; }
    public abstract int Size { get; set; }
    public abstract Action PerformSpawn(Spell spell);
    public abstract void PerformModificator(Spell spell);

    public virtual void UpdateModificators()
    {
        Count = 1;
        Size = 1;
    }
}