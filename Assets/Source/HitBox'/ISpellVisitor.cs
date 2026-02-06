using UnityEngine;

public interface ISpellVisitor
{
    public void Visit(float damage, Element element);
    public void Visit(float damage, Element element, Vector3 point);
}