using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Get_ID_Button : MonoBehaviour, IPointerClickHandler
{
    public string ID;
    public void OnPointerClick(PointerEventData eventData)
    {
        ID = gameObject.transform.GetComponent<UserButton>()._id;
        GameObject.FindGameObjectWithTag("UserActive").GetComponent<UserActive>().SetID(ID);
        SceneManager.LoadScene("UsuarioInfo");
    }
}