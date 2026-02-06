using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellSpawnType : MonoBehaviour
{
    public abstract Action PerformSpawn(Spell spell);
}