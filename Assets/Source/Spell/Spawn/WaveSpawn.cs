using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawn : SpellSpawnType
{
    [SerializeField] private Hand _hand;
    private Pool _projectilePool;
    private Transform _spawnPoint;
    private Transform _camera;

    public override int Count { get; set; } = 1;
    public override float Size { get; set; } = 1;

    private void Start()
    {
        _spawnPoint = SpellCaster.Instance.CastPoint;
        _projectilePool = Pools.Instance.WavePool;
        _camera = SpellCaster.Instance.Player;
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
                    _camera.rotation)
                .GetComponent<SpawnableSpell>();
            Debug.Log(SpawnableSpell);
            SpawnableSpell.transform.eulerAngles = new Vector3(0, _camera.eulerAngles.y, 0);
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