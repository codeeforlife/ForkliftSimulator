using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankSign : MonoBehaviour
{
    // Döndürme hızı  
    public float rotationSpeed = 50f; 
    // Update is called once per frame
    void Update()
    {
        // Nesneyi Z ekseni etrafında döndür  
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);  
    }
}
