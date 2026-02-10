using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MultipleSpellSpawnModificator : SpellModificator
{
    public override void PerformModificator(Spell spell)
    {
        spell.Hands.Add("DoubleSpell");
        spell.SpellSpawnType.Count += 1;
    }
}