using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    public void Move(Vector2 inputVector);
    public void Move(Vector3 inputVector);
}
public interface ITakeDamage{
    public void TakeDamage(float damage);
}
public interface IStatusEffect{
    public void OnStatusEffect(StatusEffect _statusEffect);
}
public enum StatusEffect{
    FROZEN,
    BURNED,
    BLEEDING,
    CONFUSED
}
