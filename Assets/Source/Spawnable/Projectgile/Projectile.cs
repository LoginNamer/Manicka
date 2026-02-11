using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using UnityEngine;

public class Projectile : SpawnableSpell
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _speed;

    private bool _moving;

    public override void Init(Spell spell)
    {
        base.Init(spell);
        _rigidBody.velocity = new Vector3(0, 0, 0);
        _moving = true;
    }

    private void Update()
    {
        if (_moving)
            _rigidBody.velocity += transform.forward * _speed;
    }

    private void OnDisable()
    {
        _rigidBody.velocity = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController PlayerController))
            return;

        _moving = false;
        _rigidBody.velocity = new Vector3(0, 0, 0);


        if (other.gameObject.TryGetComponent<ISpellVisitor>(out ISpellVisitor spellVisitor))
        {
            spellVisitor.Visit(damage, element);
        }


        SpellHitEffect SpellHitEffect = SpellCaster.Instance.HitEffectPool
            .GetFreeElement(transform.position, Quaternion.identity)
            .GetComponent<SpellHitEffect>();
        SpellHitEffect.transform.localScale = transform.localScale;
        SpellHitEffect.Init(element);
        ReturnToPool();
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}