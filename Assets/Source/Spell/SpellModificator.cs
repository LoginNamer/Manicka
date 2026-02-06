using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellModificator : MonoBehaviour
{
    public abstract void PerformModificator(Spell spell);
}