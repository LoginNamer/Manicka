using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ElementTypeVisual
{
    public Element Element;
    public GameObject Visual;
}

public class SpawnableSpellVisual : MonoBehaviour
{
    [SerializeField] private ElementTypeVisual[] _elementTypesVisuals;
    [SerializeField] private SpawnableSpell _spawnableSpell;

    private void OnEnable()
    {
        _spawnableSpell.Initialized += OnSpawnableSpellInitialized;
    }

    private void OnSpawnableSpellInitialized()
    {
        for (int i = 0; i < _elementTypesVisuals.Length; i++)
        {
            if (_elementTypesVisuals[i].Element == _spawnableSpell.element)
            {
                _elementTypesVisuals[i].Visual.SetActive(true);
            }
            else
            {
                _elementTypesVisuals[i].Visual.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        _spawnableSpell.Initialized -= OnSpawnableSpellInitialized;
    }
}