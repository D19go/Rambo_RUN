using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public int timer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroi", timer);   
    }

    // Update is called once per frame
    void destroi()
    {
        Destroy(gameObject);
    }
}
