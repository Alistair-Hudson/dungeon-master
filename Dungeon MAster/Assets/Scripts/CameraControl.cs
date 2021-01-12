using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] float screenScrolRate = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VerticalScroll();
        HorizontalScroll();
    }

    private void HorizontalScroll()
    {
        float deltaX = Input.GetAxis("Horizontal")* screenScrolRate*Time.deltaTime;
        transform.position = new Vector3(transform.position.x + deltaX, 
                                        transform.position.y, 
                                        transform.position.z);
    }

    private void VerticalScroll()
    {
        float deltaZ = Input.GetAxis("Vertical") * screenScrolRate * Time.deltaTime;
        transform.position = new Vector3(transform.position.x,
                                        transform.position.y,
                                        transform.position.z + deltaZ);
    }
}
