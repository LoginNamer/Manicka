using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : SpawnableSpell
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _speed;

    public override void Init(Spell spell)
    {
        base.Init(spell);
        _rigidBody.velocity = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        _rigidBody.velocity += transform.forward * _speed;
    }

    private void OnDisable()
    {
        _rigidBody.velocity = new Vector3(0, 0, 0);
    }
}