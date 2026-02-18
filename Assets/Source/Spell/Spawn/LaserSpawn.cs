using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LaserSpawn : SpellSpawnType
{
    private Pool _laserPool;
    private Transform _spawnPoint;
    private Transform _camera;
    [SerializeField] private Hand _hand;

    public override void PerformModificator(Spell spell)
    {
        spell.Hands.Add(_hand);
    }

    public override int Count { get; set; } = 1;
    public override float Size { get; set; } = 1;


    private void Start()
    {
        _laserPool = Pools.Instance.LaserPool;
        _spawnPoint = SpellCaster.Instance.LaserCastPoint;
        _camera = SpellCaster.Instance.Camera;
    }


    public override Action PerformSpawn(Spell spell)
    {
        return () =>
        {
            Debug.LogError("Coroutine");
            StartCoroutine(Spawning(spell));
        };
    }

    private IEnumerator Spawning(Spell spell)
    {
        for (int i = 0; i < Count; i++)
        {
            Debug.LogError(_laserPool);
            Debug.LogError(_spawnPoint);
            Debug.LogError(_camera);
            SpawnableSpell SpawnableSpell = _laserPool.GetFreeElement(_spawnPoint.position,
                    _camera.rotation * Quaternion.Euler(i * Random.Range(0, 10), i * Random.Range(0, 10), 0),
                    _spawnPoint)
                .GetComponent<SpawnableSpell>();
            Debug.Log(SpawnableSpell);
            SpawnableSpell.transform.localScale = new Vector3(Size, Size, Size);
            SpawnableSpell.Init(spell);
            yield return new WaitForSeconds(0.1f);
        }
    }
}