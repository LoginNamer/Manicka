using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    [SerializeField] private Spell _spell;
    [SerializeField] private SpellAnimator _spellAnimator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _spell.UpdateSpell();
            _spellAnimator.StartCoroutine(_spellAnimator.PlayHand(_spell.Hands.ToArray(),
                () => { _spell.SpellSpawnType.PerformSpawn(_spell)?.Invoke(); }, _spell));
        }
    }
}