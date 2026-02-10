using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class SpellModificator
{
    public abstract void PerformModificator(Spell spell);
}