using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHitEffect : PoolObject
{
    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private ElementTypeVisual[] _elementTypesVisuals;

    public void Init(Element element)
    {
        for (int i = 0; i < _elementTypesVisuals.Length; i++)
        {
            if (_elementTypesVisuals[i].Element == element)
            {
                _elementTypesVisuals[i].Visual.SetActive(true);
            }
            else
            {
                _elementTypesVisuals[i].Visual.SetActive(false);
            }
        }
    }
}