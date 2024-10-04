using System;
using UnityEngine;

public class DamageTrap : MonoBehaviour
{
    public static event Action<int> OnDamageDealt;

    public void DealDamage()
    {
        Debug.Log("Trap Dealed damage");
        OnDamageDealt?.Invoke(1);
    }
}
