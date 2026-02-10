using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellModificatorContainer : MonoBehaviour
{
    [field: SerializeReference]
    [field: SerializeReferenceButton]
    [field: SerializeField]
    public List<SpellModificator> SpellModificators { get; private set; } = new List<SpellModificator>();
}