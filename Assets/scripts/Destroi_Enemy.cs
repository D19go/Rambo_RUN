using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroi_Enemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision ot)
    {
        Destroy(ot.gameObject);
    }

}
