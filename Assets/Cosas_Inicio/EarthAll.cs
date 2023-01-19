using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAll : MonoBehaviour
{
    public static EarthAll instance;

    #region DontDestroyOnLoad
    private void Awake()
    {
        if (EarthAll.instance == null)
        {
            EarthAll.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
