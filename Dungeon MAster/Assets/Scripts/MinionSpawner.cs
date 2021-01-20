using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    [SerializeField] int goldPerSecond = 5;
    [SerializeField] int maxPopulation = 50;
    [SerializeField] MonsterAI[] minions;
    

    int selectedMinion = 0;
    int gold = 2000;
    int populationCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IncreaseGold());
    }

    IEnumerator IncreaseGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            gold += goldPerSecond;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlaceMinion();
    }

    private void PlaceMinion()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (!HaveEnoughGold())
            {
                return;
            }
            if (AtMaxPopulation())
            {
                return;
            }
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                MonsterAI newMinion = Instantiate(minions[selectedMinion], hit.point, Quaternion.identity);
                newMinion.transform.parent = transform;
            }
        }
    }

    private bool AtMaxPopulation()
    {
        if (populationCount >= maxPopulation)
        {
            return true;
        }
        return false;
    }

    private bool HaveEnoughGold()
    {
        if (gold < minions[selectedMinion].GetCost())
        {
            return false;
        }
        return true;
    }

    public void SetSelectedMinion(int minion)
    {
        selectedMinion = minion;
    }

    public int GetGoldAmount()
    {
        return gold;
    }

    public int GetPopulationCount()
    {
        return populationCount;
    }

    public void IncreasePopulationCount()
    {
        ++populationCount;
    }

    public void DecreasePopulationCount()
    {
        --populationCount;
    }

    public void DecreaseGold(int amount)
    {
        gold -= amount;
    }
}
