using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    [SerializeField] HeroAI[] heros;
    [SerializeField] int maxNumHeros = 4;
    [SerializeField] float heroSpawnDelay = 5f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(heroSpawnDelay);
        for(int i = 0; i < maxNumHeros; ++i)
        {
            HeroAI newHero = Instantiate(heros[Random.Range(0, heros.Length)], transform.position, Quaternion.identity);
            newHero.transform.parent = transform;
        }
    }
}
