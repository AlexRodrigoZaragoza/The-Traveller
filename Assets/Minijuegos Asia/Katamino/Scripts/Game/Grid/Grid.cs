using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public ShapeStorage shapeStorage;
    public bool empezado = false;
    public int filas = 0;
    public int columnas = 0;
    public float squaresGap = 0.1f;
    public GameObject gridSquare;
    public Vector2 startPosition = new Vector2(0.0f, 0.0f);
    public float squareScale = 0.5f;
    public float everySquareOffset = 0.0f;

    private Vector2 _offset = new Vector2(0.0f, 0.0f);
    public List<GameObject> _gridSquares = new List<GameObject>();

    public int contador;//Arreglar problema (vuelve a sumar los valores ya añadidos)
    [SerializeField] Text timer;
    public static int t_dificultad = 0;
    public static int t_max = 0;
    public static float t_current;
    public static float t_usado;
    public Canvas fin, canvas_game;
    public bool bool_Victoria = false;
    public bool bool_Derrota = false;

    private void Awake()
    {
        if (Application.isEditor == false)
        {
            Debug.unityLogger.logEnabled = false;
        }
    }
    private void OnEnable()
    {
        GameEvents.CheckIfShapeCanBePlaced += CheckIfShapeCanBePlaced;
    }
    private void OnDisable()
    {
        GameEvents.CheckIfShapeCanBePlaced -= CheckIfShapeCanBePlaced;
    }
    private void Update()
    {
        Victoria();
        if (empezado == true)
        {
            t_current -= 1 * Time.deltaTime;
            timer.text = t_current.ToString("0") + " S";
        }
        if (t_current <= 0)
        {
            Derrota();
        }
        Grid.t_max = (int)t_current;
    }
    public void Victoria()
    {
        contador = 0;
        for (int i = 0; i < _gridSquares.Count; i++)
        {
            if (_gridSquares[i].GetComponent<GridSquare>().SquareOccupied == true)
            {
                contador++;
                if (contador == _gridSquares.Count)
                {
                    t_usado = t_dificultad - t_current;
                    Debug.Log("Victoria");
                    bool_Victoria = true;
                    bool_Derrota = false;   
                    StartCoroutine(delayEnd());
                }
            }
        }
    }
    public void Derrota()
    {
        for (int i = 0; i < _gridSquares.Count; i++)
        {
            if (_gridSquares[i].GetComponent<GridSquare>().SquareOccupied == false)
            {
                bool_Victoria = false;
                bool_Derrota = true;
                StartCoroutine(delayEnd());
            }
        }
    }
    IEnumerator delayEnd()
    {
        if (bool_Victoria == true)
        {
            feedbackmanager.win = true;
            feedbackmanager.lose = false;
        }
        else if (bool_Derrota == false)
        {
            feedbackmanager.win = false;
            feedbackmanager.lose = true;
        }
        feedbackmanager.tiempo = t_current / t_dificultad;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Feedback_Escena");
    }
    IEnumerator Empezar()
    {
        yield return new WaitForSeconds(1f);
        empezado = true;
    }
    void Start()
    {
        CreateGrid();
        t_current = t_max;
        StartCoroutine(Empezar());
        feedbackmanager.juego_feedback = "katamino";
    }
    private void CreateGrid()
    {
        SpawnGridSquares();
        SetGridSquaresPositions();
    }
    private void SpawnGridSquares()
    {
        //0, 1, 2, 3, 4,
        //5, 6, 7, 8, 9

        int square_index = 0;

        for (var fila = 0; fila < filas; ++fila)
        {
            for (var columna = 0; columna < columnas; ++columna)
            {
                _gridSquares.Add(Instantiate(gridSquare) as GameObject);

                _gridSquares[_gridSquares.Count - 1].GetComponent<GridSquare>().SquareIndex = square_index;
                _gridSquares[_gridSquares.Count - 1].transform.SetParent(this.transform);//Hacer _gridSquare hijo del objeto donde esta puesto este script
                _gridSquares[_gridSquares.Count - 1].transform.localScale = new Vector3(squareScale, squareScale, squareScale);//Se le cambia la escala a la establecida en el flotante
                _gridSquares[_gridSquares.Count - 1].GetComponent<GridSquare>().SetImage(square_index % 2 == 0);//Devuelve un true o false a la booleana de la funcion SetImage del script GridSquare
                square_index++;
            }

        }
    }
    private void SetGridSquaresPositions()
    {
        int columna_number = 0;
        int fila_number = 0;
        Vector2 square_gap_number = new Vector2(0.0f, 0.0f);
        bool fila_moved = false;

        var square_rect = _gridSquares[0].GetComponent<RectTransform>();

        _offset.x = square_rect.rect.width * square_rect.transform.localScale.x + everySquareOffset;
        _offset.y = square_rect.rect.height * square_rect.transform.localScale.y + everySquareOffset;

        foreach (GameObject squares in _gridSquares)
        {
            if (columna_number + 1 > columnas)
            {
                square_gap_number.x = 0;
                //Pasa a la siguiente columna
                columna_number = 0;
                fila_number++;
                fila_moved = false;
            }
            var pos_x_offset = _offset.x * columna_number + (square_gap_number.x * squaresGap);
            var pos_y_offset = _offset.y * fila_number + (square_gap_number.y * squaresGap);

            if (columna_number > 0 && columna_number % 3 == 0)
            {
                square_gap_number.x++;
                pos_x_offset += squaresGap;
            }
            if (fila_number > 0 && fila_number % 3 == 0 && fila_moved == false)
            {
                fila_moved = true;
                square_gap_number.y++;
                pos_y_offset += squaresGap;
            }

            squares.GetComponent<RectTransform>().anchoredPosition = new Vector2(startPosition.x + pos_x_offset, startPosition.y - pos_y_offset);

            squares.GetComponent<RectTransform>().localPosition = new Vector3(startPosition.x + pos_x_offset, startPosition.y - pos_y_offset, 0.0f);

            columna_number++;
        }
    }

    private void CheckIfShapeCanBePlaced()
    {
        var squareIndexes = new List<int>();

        foreach (var square in _gridSquares)
        {
            var gridSquare = square.GetComponent<GridSquare>();

            if (gridSquare.Selected && !gridSquare.SquareOccupied)
            {
                squareIndexes.Add(gridSquare.SquareIndex);
                gridSquare.Selected = false;
                //gridSquare.ActivateSquare();
            }
        }

        var currentSelectedShape = shapeStorage.GetCurrentSelectedShape();
        if (currentSelectedShape == null) return; //No seleccted shape 

        if (currentSelectedShape.TotalSquareNumber == squareIndexes.Count)
        {

            foreach (var squareIndex in squareIndexes)
            {
                _gridSquares[squareIndex].GetComponent<GridSquare>().PlaceShapeOnBoard();
            }

            currentSelectedShape.DeactivateShape();
        }
        else
        {
            GameEvents.MoveShapeToStartPosition();
        }
    }
    public void NewShapes()
    {
        GameEvents.RequestNewShapes();
    }
    public void Reiniciar(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
