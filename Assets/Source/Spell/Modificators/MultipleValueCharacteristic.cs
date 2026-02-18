using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleValueCharacteristic : AddValueToCharacterisc
{
    public override void AddValue(ref float value, float toValue)
    {
        value *= toValue;
    }

    public override void AddSizeValue(SpellSpawnType spellSpawnType, float toValue)
    {
        spellSpawnType.Size *= toValue;
    }

    public override void AddCountValue(SpellSpawnType spellSpawnType, float toValue)
    {
        spellSpawnType.Count *= (int) toValue;
    }
}