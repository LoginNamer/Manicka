using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element
{
    Clear,
    Fire,
    Ice
}

public class Spell : MonoBehaviour
{
    [field: SerializeField] public List<string> Hands = new List<string>(0);
    [field: SerializeField] public KeyCode KeyCode;
    [field: SerializeField] public SpellModificatorContainer Modificators;
    [field: SerializeField] public Element Element { get; private set; }
    [field: SerializeField] public SpellSpawnType SpellSpawnType { get; private set; }
    [field: SerializeField] public float BaseCastSpeed { get; private set; }
    [field: SerializeField] public float BaseCastSpeedMultiplier { get; private set; }
    [field: SerializeField] public float BaseDamage { get; private set; }
    [field: SerializeField] public float BaseDamageMultiplier { get; private set; }

    [HideInInspector] public float Damage;
    [HideInInspector] public float DamageMultiplier;

    [HideInInspector] public float CastSpeed;
    [HideInInspector] public float CastSpeedMultiplier;

    private void Start()
    {
        UpdateSpell();
    }

    public void UpdateSpell()
    {
        CastSpeed = BaseCastSpeed;
        CastSpeedMultiplier = BaseCastSpeedMultiplier;

        Damage = BaseDamage;
        DamageMultiplier = BaseDamageMultiplier;
        SpellSpawnType.UpdateModificators();
        Hands = new List<string>();

        for (int i = 0; i < Modificators.SpellModificators.Count; i++)
        {
            Modificators.SpellModificators[i].PerformModificator(this);
        }

        SpellSpawnType.PerformModificator(this);
    }


    public float GetDamage()
    {
        return Damage * DamageMultiplier;
    }

    public float GetCastSpeed()
    {
        return CastSpeed * CastSpeedMultiplier;
    }
}