using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : SpellSpawnType
{
    [SerializeField] private Pool _projectilePool;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _camera;

    public override Action PerformSpawn(Spell spell)
    {
        return () =>
        {
            _projectilePool.GetFreeElement(_spawnPoint.position, _camera.rotation).GetComponent<SpawnableSpell>()
                .Init(spell);
        };
    }
}