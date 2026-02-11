using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public Pool HitEffectPool;
    
    public Transform CastPoint;
    public Transform LaserCastPoint;
    public Transform Camera;
    [SerializeField] private SpellAnimator _spellAnimator;

    public List<Spell> Spells = new List<Spell>();

    public static SpellCaster Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Debug.LogError("THERE IS ONE MORE SPELL CASTER BRA");
    }

    private void Update()
    {
        if (Spells.Count == 0)
            return;

        for (int i = 0; i < Spells.Count; i++)
        {
            if (Input.GetKeyDown(Spells[i].KeyCode))
            {
                Spell spell = Spells[i];
                Spells[i].UpdateSpell();
                _spellAnimator.StartCoroutine(_spellAnimator.PlayHand(Spells[i].Hands.ToArray(),
                    () => { spell.SpellSpawnType.PerformSpawn(spell)?.Invoke(); }, spell));
            }
        }
    }
}