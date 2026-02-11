using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;


    public IEnumerator PlayHand(Hand[] names, Action HandPlayed, Spell spell)
    {
        float fade = 0.25f / spell.GetCastSpeed();
        _animator.speed = 0.25f * spell.GetCastSpeed();

        bool handPlayed = false;
        for (int i = 0; i < names.Length; i++)
        {
            _animator.CrossFadeInFixedTime(names[i].Name, fade);
            yield return new WaitForSeconds(fade);
            yield return new WaitUntil(() =>
            {
                var state = _animator.GetCurrentAnimatorStateInfo(0);
                return state.IsName(names[i].Name) && state.normalizedTime >= 0.95f;
            });
            if (names[i].Duration != 0)
            {
                if (names[i].PerformSpawn)
                {
                    HandPlayed?.Invoke();
                    handPlayed = true;
                }

                yield return new WaitForSeconds(names[i].Duration);
            }
        }

        if (!handPlayed)
            HandPlayed?.Invoke();
        _animator.CrossFadeInFixedTime("Idle", fade);
        yield return new WaitForSeconds(fade);
        yield return new WaitUntil(() =>
        {
            var state = _animator.GetCurrentAnimatorStateInfo(0);
            return state.IsName("Idle") && state.normalizedTime >= 0.95f;
        });
        _animator.speed = 1;
    }
}