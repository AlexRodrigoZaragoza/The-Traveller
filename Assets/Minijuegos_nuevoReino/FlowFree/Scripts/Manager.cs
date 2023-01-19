using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    lr_Trazado_flow Traz;

    public bool RojoActivo;
    public bool NegroActivo;
    public bool VerdeActivo;
    public bool AzulActivo;
    public bool AmarilloActivo;
    public bool RojoI;
    public bool NegroI;
    public bool VerdeI;
    public bool AzulI;
    public bool AmarilloI;
    public bool RojoF;
    public bool NegroF;
    public bool VerdeF;
    public bool AzulF;
    public bool AmarilloF;
    public bool Clear;

    public int j = 0;
    public int i = 0;
    public int k = 0;
    public int Rojo_Inum = 0;
    public int Rojo_Fnum = 0;
    public int Negro_Inum = 0;
    public int Negro_Fnum = 0;
    public int Verde_Inum = 0;
    public int Verde_Fnum = 0;
    public int Azul_Inum = 0;
    public int Azul_Fnum = 0;
    public int Amarillo_Inum = 0;
    public int Amarillo_Fnum = 0;

    public float dist2;

    Vector2 PositionM;

    public List<GameObject> Puntos = new List<GameObject>();
    public List<GameObject> FlowFacil_Azul = new List<GameObject>();
    public List<GameObject> FlowFacil_Negro = new List<GameObject>();
    public List<GameObject> FlowFacil_Amarillo = new List<GameObject>();
    public List<GameObject> FlowFacil_Rojo = new List<GameObject>();
    public List<GameObject> FlowFacil_Verde = new List<GameObject>();


    public MenuDePausa Menu;

    private void Start()
    {
        #region SETING
        Traz = FindObjectOfType<lr_Trazado_flow>();

        for (i = 0; i < Traz.FlowFacil.Length; i++)
        {
            if (Traz.FlowFacil[i].gameObject.tag == "Azul_inicio")
            {
                Azul_Inum = i;
            }
        }
        i = 0;
        for (i = 0; i < Traz.FlowFacil.Length; i++)
        {
            if (Traz.FlowFacil[i].gameObject.tag == "Azul_final")
            {
                Azul_Fnum = i;
            }
        }
        i = 0;
        for (i = 0; i < Traz.FlowFacil.Length; i++)
        {
            if (Traz.FlowFacil[i].gameObject.tag == "Negro_inicio")
            {
                Negro_Inum = i;
            }
        }
        i = 0;
        for (i = 0; i < Traz.FlowFacil.Length; i++)
        {
            if (Traz.FlowFacil[i].gameObject.tag == "Negro_final")
            {
                Negro_Fnum = i;
            }
        }
        i = 0;
        for (i = 0; i < Traz.FlowFacil.Length; i++)
        {
            if (Traz.FlowFacil[i].gameObject.tag == "Rojo_inicio")
            {
                Rojo_Inum = i;
            }
        }
        i = 0;
        for (i = 0; i < Traz.FlowFacil.Length; i++)
        {
            if (Traz.FlowFacil[i].gameObject.tag == "Rojo_final")
            {
                Rojo_Fnum = i;
            }
        }
        i = 0;
        for (i = 0; i < Traz.FlowFacil.Length; i++)
        {
            if (Traz.FlowFacil[i].gameObject.tag == "Amarillo_inicio")
            {
                Amarillo_Inum = i;
            }
        }
        i = 0;
        for (i = 0; i < Traz.FlowFacil.Length; i++)
        {
            if (Traz.FlowFacil[i].gameObject.tag == "Amarillo_final")
            {
                Amarillo_Fnum = i;
            }
        }
        i = 0;
        for (i = 0; i < Traz.FlowFacil.Length; i++)
        {
            if (Traz.FlowFacil[i].gameObject.tag == "Verde_inicio")
            {
                Verde_Inum = i;
            }
        }
        i = 0;
        for (i = 0; i < Traz.FlowFacil.Length; i++)
        {
            if (Traz.FlowFacil[i].gameObject.tag == "Verde_final")
            {
                Verde_Fnum = i;
            }
        }
        i = 0;
        #endregion
    }

    public void Update()
    {
        if ((FlowFacil_Rojo.Count+FlowFacil_Amarillo.Count+FlowFacil_Azul.Count+FlowFacil_Negro.Count+FlowFacil_Verde.Count) == Traz.FlowFacil.Length && (FlowFacil_Rojo.Contains(Traz.Rojo_inicio) && FlowFacil_Rojo.Contains(Traz.Rojo_final)) && (FlowFacil_Verde.Contains(Traz.Verde_inicio) && FlowFacil_Verde.Contains(Traz.Verde_final)) && (FlowFacil_Azul.Contains(Traz.Azul_inicio) && FlowFacil_Azul.Contains(Traz.Azul_final)) && (FlowFacil_Amarillo.Contains(Traz.Amarillo_inicio) && FlowFacil_Amarillo.Contains(Traz.Amarillo_final)) && (FlowFacil_Negro.Contains(Traz.Negro_inicio) && FlowFacil_Negro.Contains(Traz.Negro_final)))
        {
            Debug.Log("VICTORIA");
        }

        PositionM = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        

    }

    public void Comprobar()
    {

        if (FlowFacil_Rojo.Count >= 1 && RojoActivo == true)
        {
            for (int w = 0; w <= FlowFacil_Rojo.Count - 1; w++)
            {
                dist2 = Vector2.Distance(FlowFacil_Rojo[w].transform.position, PositionM);
                
            }
        }

        if (FlowFacil_Amarillo.Count >= 1 && AmarilloActivo == true)
        {
            for (int w = 0; w <= FlowFacil_Amarillo.Count - 1; w++)
            {
                dist2 = Vector2.Distance(FlowFacil_Amarillo[w].transform.position, PositionM);

            }
        }

        if (FlowFacil_Verde.Count >= 1 && VerdeActivo == true)
        {
            for (int w = 0; w <= FlowFacil_Verde.Count - 1; w++)
            {
                dist2 = Vector2.Distance(FlowFacil_Verde[w].transform.position, PositionM);

            }
        }

        if (FlowFacil_Azul.Count >= 1 && AzulActivo == true)
        {
            for (int w = 0; w <= FlowFacil_Azul.Count - 1; w++)
            {
                dist2 = Vector2.Distance(FlowFacil_Azul[w].transform.position, PositionM);

            }
        }

        if (FlowFacil_Negro.Count >= 1 && NegroActivo == true)
        {
            for (int w = 0; w <= FlowFacil_Negro.Count - 1; w++)
            {
                dist2 = Vector2.Distance(FlowFacil_Negro[w].transform.position, PositionM);

            }
        }
    }


    public void BotonDeInicio()
    {
        //AQUI LO QUE HAGA FALTA PARA QUE SE INICIE EL JUEGO SEGUN LA DIFICULTAD;
    }
}
