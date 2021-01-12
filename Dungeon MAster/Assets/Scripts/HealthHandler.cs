using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;

    float health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;   
    }

    public void DecreaseHealth(float damage)
    {
        health -= damage;
        if (0 >= health)
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseHelath(float heal)
    {
        health += heal;
        if (maxHealth < health)
        {
            health = maxHealth;
        }
    }

    public float GetHealth()
    {
        return health;
    }

}
