using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBox : MonoBehaviour, ISpellVisitor
{
    public void Visit(float damage, Element element)
    {
    }

    public void Visit(float damage, Element element, Vector3 point)
    {
    }
}