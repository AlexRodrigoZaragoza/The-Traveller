using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserActive : MonoBehaviour
{
    public static UserActive instance;
    public string _id;

    #region DontDestroyOnLoad
    private void Awake()
    {
        if (UserActive.instance == null)
        {
            UserActive.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public void SetID(string id)
    {
        _id = id;
    }
}
