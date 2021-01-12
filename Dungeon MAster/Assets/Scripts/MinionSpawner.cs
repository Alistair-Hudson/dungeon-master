using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    [SerializeField] MonsterAI minion;


    // Start is called before the first frame update
    void Start()
    {
        
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
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                MonsterAI newMinion = Instantiate(minion, hit.point, Quaternion.identity);
                newMinion.transform.parent = transform;
            }
        }
    }
}
