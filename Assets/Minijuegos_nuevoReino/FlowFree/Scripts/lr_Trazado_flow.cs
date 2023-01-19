using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class lr_Trazado_flow : MonoBehaviour
{
    public Manager Man;

    public GameObject[] FlowFacil = new GameObject[15];
    public GameObject[] FlowMedio = new GameObject[24];
    public GameObject[] FlowDificil = new GameObject[35];

    public LineRenderer LrAzul;
    public LineRenderer LrNegro;
    public LineRenderer LrAmarillo;
    public LineRenderer LrRojo;
    public LineRenderer LrVerde;

    public GameObject DibujoAzul;
    public GameObject DibujoNegro;
    public GameObject DibujoAmarillo;
    public GameObject DibujoRojo;
    public GameObject DibujoVerde;

    public GameObject Azul_inicio;
    public GameObject Azul_final;
    public GameObject Negro_inicio;
    public GameObject Negro_final;
    public GameObject Amarillo_inicio;
    public GameObject Amarillo_final;
    public GameObject Rojo_inicio;
    public GameObject Rojo_final;
    public GameObject Verde_inicio;
    public GameObject Verde_final;

    public Material Azul;
    public Material Negro;
    public Material Amarilo;
    public Material Rojo;
    public Material Verde;
    public Material Base;

    public static Vector3 Pos;

    public bool encontrado = false, Fin = false;


    public void Start()
    {
        #region SETING
        Man = FindObjectOfType<Manager>();

        Azul_inicio = GameObject.FindGameObjectWithTag("Azul_inicio");
        Azul_inicio.name = "Azul_inicio";
        Azul_final = GameObject.FindGameObjectWithTag("Azul_final");
        Azul_final.name = "Azul_final";
        Negro_inicio = GameObject.FindGameObjectWithTag("Negro_inicio");
        Negro_inicio.name = "Negro_inicio";
        Negro_final = GameObject.FindGameObjectWithTag("Negro_final");
        Negro_final.name = "Negro_final";
        Amarillo_inicio = GameObject.FindGameObjectWithTag("Amarillo_inicio");
        Amarillo_inicio.name = "Amarillo_inicio";
        Amarillo_final = GameObject.FindGameObjectWithTag("Amarillo_final");
        Amarillo_final.name = "Amarillo_final";
        Rojo_inicio = GameObject.FindGameObjectWithTag("Rojo_inicio");
        Rojo_inicio.name = "Rojo_inicio";
        Rojo_final = GameObject.FindGameObjectWithTag("Rojo_final");
        Rojo_final.name = "Rojo_final";
        Verde_inicio = GameObject.FindGameObjectWithTag("Verde_inicio");
        Verde_inicio.name = "Verde_final";
        Verde_final = GameObject.FindGameObjectWithTag("Verde_final");
        Verde_final.name = "Verde_inicio";
        #endregion
    }
   
    public void Clear()
    {
        if (Man.FlowFacil_Rojo.Contains(Rojo_inicio) && Man.RojoF == false)
        {
            for (Man.k = 0; Man.k <= Man.FlowFacil_Rojo.Count; Man.k++)
            {
                if (Man.FlowFacil_Rojo[Man.k].gameObject.tag == "Boton")
                {
                    Man.FlowFacil_Rojo[Man.k].GetComponent<Renderer>().material = Base;
                }
            }

            Man.FlowFacil_Rojo.Clear();
        }
    }



    public void OnMouseOver()
    {
        if ((gameObject.tag == "Boton" || gameObject.tag == "Azul_inicio" || gameObject.tag == "Azul_final" || gameObject.tag == "Negro_inicio" || gameObject.tag == "Negro_final" || gameObject.tag == "Amarillo_inicio" || gameObject.tag == "Amarillo_final" || gameObject.tag == "Rojo_inicio" || gameObject.tag == "Rojo_final" || gameObject.tag == "Verde_inicio" || gameObject.tag == "Verde_final") && Input.GetMouseButton(0))
        {

            Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            encontrado = false;
            Fin = false;

            if (Vector2.Distance(Pos, Rojo_inicio.transform.position) <= 0.5)
            {

                if(Man.FlowFacil_Rojo.Contains(Rojo_inicio) && Man.RojoF == false)
                {
                    while(Man.k <=Man.FlowFacil_Rojo.Count)
                    {
                          if(Man.FlowFacil_Rojo[Man.k].gameObject.tag == "Boton")
                          {
                            Man.FlowFacil_Rojo[Man.k].GetComponent<Renderer>().material = Base;
                            Man.Clear = true;
                          }

                        Man.k++;
                    }

                }

                if(Man.Clear == true)
                {
                    Man.FlowFacil_Rojo.Clear();
                    Man.Clear = false;
                }

                Man.RojoI = true;
                Man.RojoF = false;
                Man.RojoActivo = true;
                Man.NegroActivo = false;
                Man.AzulActivo = false;
                Man.AmarilloActivo = false;
                Man.VerdeActivo = false;
            }

            if (Vector2.Distance(Pos, Rojo_final.transform.position) <= 0.5)
            {

                if (Man.FlowFacil_Rojo.Contains(Rojo_final) && Man.RojoI == false)
                {
                    for (Man.k = 0; Man.k <= Man.FlowFacil_Rojo.Count; Man.k++)
                    {
                        if (Man.FlowFacil_Rojo[Man.k].gameObject.tag == "Boton")
                        {
                            Man.FlowFacil_Rojo[Man.k].GetComponent<Renderer>().material = Base;
                        }
                    }

                    Man.FlowFacil_Rojo.Clear();
                }


                Man.RojoF = true;
                Man.RojoI = false;
                Man.RojoActivo = true;
                Man.NegroActivo = false;
                Man.AzulActivo = false;
                Man.AmarilloActivo = false;
                Man.VerdeActivo = false;

            }

            if (Vector2.Distance(Pos, Negro_inicio.transform.position) <= 0.5)
            {
                if (Man.FlowFacil_Negro.Contains(Negro_inicio) && Man.NegroF == false)
                {
                    for (Man.k = 0; Man.k <= Man.FlowFacil_Negro.Count; Man.k++)
                    {
                        if (Man.FlowFacil_Negro[Man.k].gameObject.tag == "Boton")
                        {
                            Man.FlowFacil_Negro[Man.k].GetComponent<Renderer>().material = Base;
                        }
                    }

                    Man.FlowFacil_Negro.Clear();
                }
                Man.NegroI = true;
                Man.NegroF = false;
                Man.RojoActivo = false;
                Man.NegroActivo = true;
                Man.AzulActivo = false;
                Man.AmarilloActivo = false;
                Man.VerdeActivo = false;
            }

            if (Vector2.Distance(Pos, Negro_final.transform.position) <= 0.5)
            {
                if (Man.FlowFacil_Negro.Contains(Negro_final) && Man.NegroI == false)
                {
                    for (Man.k = 0; Man.k <= Man.FlowFacil_Negro.Count; Man.k++)
                    {
                        if (Man.FlowFacil_Negro[Man.k].gameObject.tag == "Boton")
                        {
                            Man.FlowFacil_Negro[Man.k].GetComponent<Renderer>().material = Base;
                        }
                    }

                    Man.FlowFacil_Negro.Clear();
                }
                Man.NegroF = true;
                Man.NegroI = true;
                Man.RojoActivo = false;
                Man.NegroActivo = true;
                Man.AzulActivo = false;
                Man.AmarilloActivo = false;
                Man.VerdeActivo = false;
            }

            if (Vector2.Distance(Pos, Azul_inicio.transform.position) <= 0.5)
            {
                if (Man.FlowFacil_Azul.Contains(Azul_inicio) && Man.AzulF == false)
                {
                    for (Man.k = 0; Man.k <= Man.FlowFacil_Azul.Count; Man.k++)
                    {
                        if (Man.FlowFacil_Azul[Man.k].gameObject.tag == "Boton")
                        {
                            Man.FlowFacil_Azul[Man.k].GetComponent<Renderer>().material = Base;
                        }
                    }

                    Man.FlowFacil_Azul.Clear();
                }
                Man.AzulI = true;
                Man.AzulF = false;
                Man.RojoActivo = false;
                Man.NegroActivo = false;
                Man.AzulActivo = true;
                Man.AmarilloActivo = false;
                Man.VerdeActivo = false;
            }

            if (Vector2.Distance(Pos, Azul_final.transform.position) <= 0.5)
            {
                if (Man.FlowFacil_Azul.Contains(Azul_final) && Man.AzulI == false)
                {
                    for (Man.k = 0; Man.k <= Man.FlowFacil_Azul.Count; Man.k++)
                    {
                        if (Man.FlowFacil_Azul[Man.k].gameObject.tag == "Boton")
                        {
                            Man.FlowFacil_Azul[Man.k].GetComponent<Renderer>().material = Base;
                        }
                    }

                    Man.FlowFacil_Azul.Clear();
                }
                Man.AzulF = true;
                Man.AzulI = false;
                Man.RojoActivo = false;
                Man.NegroActivo = false;
                Man.AzulActivo = true;
                Man.AmarilloActivo = false;
                Man.VerdeActivo = false;
            }

            if (Vector2.Distance(Pos, Amarillo_inicio.transform.position) <= 0.5)
            {
                if (Man.FlowFacil_Amarillo.Contains(Amarillo_inicio) && Man.AmarilloF == false)
                {
                    for (Man.k = 0; Man.k <= Man.FlowFacil_Amarillo.Count; Man.k++)
                    {
                        if (Man.FlowFacil_Amarillo[Man.k].gameObject.tag == "Boton")
                        {
                            Man.FlowFacil_Amarillo[Man.k].GetComponent<Renderer>().material = Base;
                        }
                    }

                    Man.FlowFacil_Amarillo.Clear();
                }
                Man.AmarilloI = true;
                Man.AmarilloF = false;
                Man.RojoActivo = false;
                Man.NegroActivo = false;
                Man.AzulActivo = false;
                Man.AmarilloActivo = true;
                Man.VerdeActivo = false;
            }

            if (Vector2.Distance(Pos, Amarillo_final.transform.position) <= 0.5)
            {
                if (Man.FlowFacil_Amarillo.Contains(Amarillo_final) && Man.AmarilloI == false)
                {
                    for (Man.k = 0; Man.k <= Man.FlowFacil_Amarillo.Count; Man.k++)
                    {
                        if (Man.FlowFacil_Amarillo[Man.k].gameObject.tag == "Boton")
                        {
                            Man.FlowFacil_Amarillo[Man.k].GetComponent<Renderer>().material = Base;
                        }
                    }

                    Man.FlowFacil_Amarillo.Clear();
                }
                Man.AmarilloF = true;
                Man.AmarilloI = false;
                Man.RojoActivo = false;
                Man.NegroActivo = false;
                Man.AzulActivo = false;
                Man.AmarilloActivo = true;
                Man.VerdeActivo = false;
            }

            if (Vector2.Distance(Pos, Verde_inicio.transform.position) <= 0.5)
            {
                if (Man.FlowFacil_Verde.Contains(Verde_inicio) && Man.VerdeF == false)
                {
                    for (Man.k = 0; Man.k <= Man.FlowFacil_Verde.Count; Man.k++)
                    {
                        if (Man.FlowFacil_Verde[Man.k].gameObject.tag == "Boton")
                        {
                            Man.FlowFacil_Verde[Man.k].GetComponent<Renderer>().material = Base;
                        }
                    }

                    Man.FlowFacil_Verde.Clear();
                }
                Man.VerdeI = true;
                Man.VerdeF = false;
                Man.RojoActivo = false;
                Man.NegroActivo = false;
                Man.AzulActivo = false;
                Man.AmarilloActivo = false;
                Man.VerdeActivo = true;
            }

            if (Vector2.Distance(Pos, Verde_final.transform.position) <= 0.5)
            {
                if (Man.FlowFacil_Verde.Contains(Verde_final) && Man.VerdeI == false)
                {
                    for (Man.k = 0; Man.k <= Man.FlowFacil_Verde.Count; Man.k++)
                    {
                        if (Man.FlowFacil_Verde[Man.k].gameObject.tag == "Boton")
                        {
                            Man.FlowFacil_Verde[Man.k].GetComponent<Renderer>().material = Base;
                        }
                    }

                    Man.FlowFacil_Verde.Clear();
                }
                Man.VerdeF = true;
                Man.VerdeI = false;
                Man.RojoActivo = false;
                Man.NegroActivo = false;
                Man.AzulActivo = false;
                Man.AmarilloActivo = false;
                Man.VerdeActivo = true;
            }

            while (Man.j < FlowFacil.Length && encontrado == false && Man.RojoActivo == true)
            {

                float dist = Vector2.Distance(Pos, FlowFacil[Man.j].transform.position);

                if (dist <= 0.5f)
                {
                    Man.Comprobar();


                    if (!Man.Puntos.Contains(FlowFacil[Man.j]))
                    {
                        Man.Puntos.Add(FlowFacil[Man.j]);
                    }
                    if (!Man.FlowFacil_Rojo.Contains(FlowFacil[Man.j]))
                    {
                        Man.FlowFacil_Rojo.Add(FlowFacil[Man.j]);
                    }
                    FlowFacil[Man.j].GetComponent<Renderer>().material = Rojo;
                    Man.j = 0;
                    encontrado = true;

                    break;
                }

                Man.j++;
            }

            while (Man.j < FlowFacil.Length && encontrado == false && Man.NegroActivo == true)
            {

                float dist = Vector2.Distance(Pos, FlowFacil[Man.j].transform.position);

                if (dist <= 0.5f)
                {
                    Man.Comprobar();

                    if (!Man.Puntos.Contains(FlowFacil[Man.j]))
                    {
                        Man.Puntos.Add(FlowFacil[Man.j]);
                    }
                    if (!Man.FlowFacil_Negro.Contains(FlowFacil[Man.j]))
                    {
                        Man.FlowFacil_Negro.Add(FlowFacil[Man.j]);
                    }
                    FlowFacil[Man.j].GetComponent<Renderer>().material = Negro;
                    Man.j = 0;
                    encontrado = true;

                    break;

                }

                Man.j++;
            }

            while (Man.j < FlowFacil.Length && encontrado == false && Man.AzulActivo == true)
            {
                float dist = Vector2.Distance(Pos, FlowFacil[Man.j].transform.position);

                if (dist <= 0.5f)
                {
                    Man.Comprobar();


                    if (!Man.Puntos.Contains(FlowFacil[Man.j]))
                    {
                        Man.Puntos.Add(FlowFacil[Man.j]);
                    }
                    if (!Man.FlowFacil_Azul.Contains(FlowFacil[Man.j]))
                    {
                        Man.FlowFacil_Azul.Add(FlowFacil[Man.j]);
                    }
                    FlowFacil[Man.j].GetComponent<Renderer>().material = Azul;
                    encontrado = true;
                    Man.j = 0;

                    break;
                }

                Man.j++;
            }

            while (Man.j < FlowFacil.Length && encontrado == false && Man.AmarilloActivo == true)
            {
                float dist = Vector2.Distance(Pos, FlowFacil[Man.j].transform.position);

                if (dist <= 0.5f)
                {
                    Man.Comprobar();


                    if (!Man.Puntos.Contains(FlowFacil[Man.j]))
                    {
                        Man.Puntos.Add(FlowFacil[Man.j]);
                    }
                    if (!Man.FlowFacil_Amarillo.Contains(FlowFacil[Man.j]))
                    {
                        Man.FlowFacil_Amarillo.Add(FlowFacil[Man.j]);
                    }
                    FlowFacil[Man.j].GetComponent<Renderer>().material = Amarilo;
                    encontrado = true;
                    Man.j = 0;
                    break;

                }

                Man.j++;
            }

            while (Man.j < FlowFacil.Length && encontrado == false && Man.VerdeActivo == true)
            {
                float dist = Vector2.Distance(Pos, FlowFacil[Man.j].transform.position);

                if (dist <= 0.5f)
                {
                    Man.Comprobar();


                    if (!Man.Puntos.Contains(FlowFacil[Man.j]))
                    {
                        Man.Puntos.Add(FlowFacil[Man.j]);
                    }
                    if (!Man.FlowFacil_Verde.Contains(FlowFacil[Man.j]))
                    {
                        Man.FlowFacil_Verde.Add(FlowFacil[Man.j]);
                    }
                    FlowFacil[Man.j].GetComponent<Renderer>().material = Verde;
                    encontrado = true;
                    Man.j = 0;

                    break;
                }

                Man.j++;
            }
        }
    }
}
