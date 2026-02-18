using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


[Serializable]
public class AddValueToCharacterisc : SpellModificator
{
    [SerializeField] private Hand _hand;
    [SerializeField] private SpellCharacteristic _characteristic;
    [SerializeField] private float _addValue;

    [SerializeField] public bool _elemntCondition;
    [SerializeField] private Element _needElement;

    public override void PerformModificator(Spell spell)
    {
        if (_elemntCondition && spell.Element != _needElement)
            return;
        switch (_characteristic)
        {
            case SpellCharacteristic.Damage:
                AddValue(ref spell.Damage, _addValue);
                break;
            case SpellCharacteristic.DamageMultiplicator:
                AddValue(ref spell.DamageMultiplier, _addValue);
                break;
            case SpellCharacteristic.Speed:
                AddValue(ref spell.CastSpeed, _addValue);
                break;
            case SpellCharacteristic.SpeedMultiplicator:
                AddValue(ref spell.CastSpeedMultiplier, _addValue);
                break;
            case SpellCharacteristic.SpawnCount:
                AddCountValue(spell.SpellSpawnType, _addValue);
                break;
            case SpellCharacteristic.Size:
                AddSizeValue(spell.SpellSpawnType, _addValue);
                break;
        }

        if (_hand.Name != "")
        {
            spell.Hands.Add(_hand);
        }
    }

    public virtual void AddValue(ref float value, float toValue)
    {
        value += toValue;
    }

    public virtual void AddCountValue(SpellSpawnType spellSpawnType, float toValue)
    {
        spellSpawnType.Count += (int) toValue;
    }

    public virtual void AddSizeValue(SpellSpawnType spellSpawnType, float toValue)
    {
        spellSpawnType.Size += toValue;
    }
}