using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleOnEnable : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnEnable()
    {
        _particleSystem.Play();
    }
}