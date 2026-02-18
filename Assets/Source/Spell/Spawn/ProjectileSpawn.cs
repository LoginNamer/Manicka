using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProjectileSpawn : SpellSpawnType
{
    [SerializeField] private Hand _hand;
     private Pool _projectilePool;
    private Transform _spawnPoint;
    private Transform _camera;

    public override int Count { get; set; } = 1;
    public override float Size { get; set; } = 1;

    private void Start()
    {
        _projectilePool = Pools.Instance.ProjectilePool;
        _spawnPoint = SpellCaster.Instance.CastPoint;
        _camera = SpellCaster.Instance.Camera;
    }

    public override Action PerformSpawn(Spell spell)
    {
        return () => { StartCoroutine(Spawning(spell)); };
    }

    private IEnumerator Spawning(Spell spell)
    {
        for (int i = 0; i < Count; i++)
        {
            SpawnableSpell SpawnableSpell = _projectilePool.GetFreeElement(_spawnPoint.position,
                    _camera.rotation * Quaternion.Euler(Random.Range(0, 1), 0, Random.Range(0, 1)))
                .GetComponent<SpawnableSpell>();
            Debug.Log(SpawnableSpell);
            SpawnableSpell.transform.localScale = new Vector3(Size, Size, Size);
            SpawnableSpell.Init(spell);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public override void PerformModificator(Spell spell)
    {
        spell.Hands.Add(_hand);
    }
}