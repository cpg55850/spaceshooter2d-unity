using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        GameManager.Instance.drawHealth(health);
    }
}
