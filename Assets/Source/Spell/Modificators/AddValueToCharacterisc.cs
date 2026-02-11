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
                spell.Damage += _addValue;
                break;
            case SpellCharacteristic.DamageMultiplicator:
                spell.DamageMultiplier += _addValue;
                break;
            case SpellCharacteristic.Speed:
                spell.CastSpeed += _addValue;
                break;
            case SpellCharacteristic.SpeedMultiplicator:
                spell.CastSpeedMultiplier += _addValue;
                break;
            case SpellCharacteristic.SpawnCount:
                spell.SpellSpawnType.Count += (int) _addValue;
                break;
            case SpellCharacteristic.Size:
                spell.SpellSpawnType.Size += (int) _addValue;
                break;
        }

        if (_hand.Name != "")
        {
            spell.Hands.Add(_hand);
        }
    }
}