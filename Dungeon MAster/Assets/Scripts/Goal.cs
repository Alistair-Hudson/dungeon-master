using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnDestroy()
    {
        print("GAME OVER");
    }
}
