using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;


    public IEnumerator PlayHand(string[] names, Action HandPlayed, Spell spell)
    {
        float fade = 0.25f / spell.GetCastSpeed();
        _animator.speed = 0.25f * spell.GetCastSpeed();
        for (int i = 0; i < names.Length; i++)
        {
            _animator.CrossFadeInFixedTime(names[i], fade);
            yield return new WaitForSeconds(fade);
            yield return new WaitUntil(() =>
            {
                var state = _animator.GetCurrentAnimatorStateInfo(0);
                return state.IsName(names[i]) && state.normalizedTime >= 0.95f;
            });
        }

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