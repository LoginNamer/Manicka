using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellModificatorContainer : MonoBehaviour
{
    [field: SerializeReference]
    [field: SerializeReferenceButton]
    [field: SerializeField]
    public List<SpellModificator> SpellModificators { get; private set; } = new List<SpellModificator>();

    public void PerformModificators(Spell spell)
    {
        for (int i = 0; i < SpellModificators.Count; i++)
        {
            SpellModificators[i].PerformModificator(spell);
        }
    }
}