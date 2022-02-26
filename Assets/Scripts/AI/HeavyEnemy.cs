using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : BaseEnemy
{
    protected override void Start()
    {
        base.Start();
        StartCoroutine(HeavyEnemyShout());
    }
    IEnumerator HeavyEnemyShout()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("IM following you !!!");
    }
}
