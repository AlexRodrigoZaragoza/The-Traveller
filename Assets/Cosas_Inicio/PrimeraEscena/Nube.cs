using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nube : MonoBehaviour
{

    public GameObject Spawner;

    private void OnBecameInvisible()
    {
        if (gameObject.transform.position.x < 0)
        {
            gameObject.transform.position = new Vector3(Spawner.transform.position.x, transform.position.y, transform.position.z);
        }
      
    }
}
