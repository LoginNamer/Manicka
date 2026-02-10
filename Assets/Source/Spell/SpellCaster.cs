using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    [SerializeField] private SpellAnimator _spellAnimator;

    public List<Spell> Spells = new List<Spell>();

    private void Update()
    {
        if (Spells.Count == 0)
            return;

        for (int i = 0; i < Spells.Count; i++)
        {
            if (Input.GetKeyDown(Spells[i].KeyCode))
            {
                Spells[i].UpdateSpell();
                _spellAnimator.StartCoroutine(_spellAnimator.PlayHand(Spells[i].Hands.ToArray(),
                    () => { Spells[i].SpellSpawnType.PerformSpawn(Spells[i])?.Invoke(); }, Spells[i]));
            }
        }
    }
}