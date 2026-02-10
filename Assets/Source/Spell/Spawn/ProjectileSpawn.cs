using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : SpellSpawnType
{
    [SerializeField] private Pool _projectilePool;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _camera;

    public override int Count { get; set; } = 1;

    public override Action PerformSpawn(Spell spell)
    {
        return () =>
        {
            for (int i = 0; i < Count; i++)
            {
                _projectilePool.GetFreeElement(_spawnPoint.position, _camera.rotation).GetComponent<SpawnableSpell>()
                    .Init(spell);
            }
        };
    }

    public override void PerformModificator(Spell spell)
    {
        spell.Hands.Add("Projectile");
    }
}