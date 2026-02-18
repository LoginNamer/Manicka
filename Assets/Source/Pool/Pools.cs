using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pools : MonoBehaviour
{
    [field: SerializeField] public Pool ProjectilePool { get; private set; }
    [field: SerializeField] public Pool WavePool { get; private set; }
    [field: SerializeField] public Pool LaserPool { get; private set; }

    public static Pools Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }
        Debug.LogError("there`s no pools");
    }
}