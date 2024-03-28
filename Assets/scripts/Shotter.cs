using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotter : MonoBehaviour
{
    public GameObject bola;
    public float time = 0.5f;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tiro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Tiro()
    {
        GameObject nova_bola = Instantiate(bola, transform.position, Quaternion.identity);
        nova_bola.transform.Rotate(90, 0, 0);
        nova_bola.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        yield return new WaitForSeconds(time);
        StartCoroutine(Tiro());
    }
    public void LVL(float nvl, float newForce)
    {
        time = nvl;
        force = newForce;
    }
}
