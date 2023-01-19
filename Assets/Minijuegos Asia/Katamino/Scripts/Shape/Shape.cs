using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shape : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    Grid grid;
    public GameObject squareShapeImagen;
    public Vector3 shapeSelectedScale;
    Vector2 offset = new Vector2(-120f, -90f);

    [HideInInspector]
    public ShapeData CurrentShapeData;

    public int TotalSquareNumber { get; set; }

    private List<GameObject> _currentShape = new List<GameObject>();
    private Vector3 _shapeStartScale;
    private RectTransform _transform;
    public bool _shapeDraggable = true;
    public bool _shapeSelected = false;
    public float rotacion;
    private Canvas _canvas;
    private Vector3 _startPosition;
    private bool _shapeActive = true;

    public void Awake()
    {
        _shapeStartScale = this.GetComponent<RectTransform>().localScale;
        _transform = this.GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _shapeDraggable = true;
        _startPosition = _transform.localPosition;
        _shapeActive = true;
        _shapeSelected = false;
    }
    private void Update()
    {
        rotacion = _transform.localRotation.z;
    }
    private void OnEnable()
    {
        GameEvents.MoveShapeToStartPosition += MoveShapeToStartPosition;
    }

    private void OnDisable()
    {
        GameEvents.MoveShapeToStartPosition -= MoveShapeToStartPosition;
    }
    public bool IsOnStartPosition()
    {
        return _transform.localPosition == _startPosition;
    }
    public bool IsAnyOfShapeSquareActive()
    {
        foreach (var square in _currentShape)
        {
            if (square.gameObject.activeSelf)
                return true;
        }

        return false;
    }
    public void DeactivateShape()
    {
        if (_shapeActive)
        {
            foreach (var square in _currentShape)
            {
                square?.GetComponent<ShapeSquare>().DeactivateShape();
            }
        }

        _shapeActive = false;
    }
    public void ActivateShape()
    {
        if (!_shapeActive)
        {
            foreach (var square in _currentShape)
            {
                square?.GetComponent<ShapeSquare>().ActivateShape();
            }
        }

        _shapeActive = true;
    }
    public void RequestNewShape(ShapeData shapeData)
    {
        _transform.localPosition = _startPosition;
        CreateShape(shapeData);
    }
    public void CreateShape(ShapeData shapeData)
    {
        CurrentShapeData = shapeData;
        TotalSquareNumber = GetNumberOfSquares(shapeData);

        while (_currentShape.Count <= TotalSquareNumber)
        {
            _currentShape.Add(Instantiate(squareShapeImagen, transform) as GameObject);
        }

        foreach (var square in _currentShape)
        {
            square.gameObject.transform.position = Vector3.zero;
            square.gameObject.SetActive(false);
        }

        var squareRect = squareShapeImagen.GetComponent<RectTransform>();
        var moveDistance = new Vector2(squareRect.rect.width * squareRect.localScale.x, squareRect.rect.height * squareRect.localScale.y);
        
        int currentIndexInList = 0;

        //Posicion para el shape final
        for (int row = 0; row < shapeData.rows; row++)
        {
            for (int column = 0; column < shapeData.columns; column++)
            {
                if (shapeData.board[row].column[column])
                {
                    _currentShape[currentIndexInList].SetActive(true);
                    _currentShape[currentIndexInList].GetComponent<RectTransform>().localPosition = new Vector2(GetXPositionForShapeSquares(shapeData, column, moveDistance), GetYPositionForShapeSquares(shapeData, row, moveDistance));

                    currentIndexInList++;
                }
            }
        }
    }
    private float GetYPositionForShapeSquares(ShapeData shapeData, int row, Vector2 moveDistance)
    {
        float shiftOnY = 0f;

        if (shapeData.rows > 1)
        {
            if (shapeData.rows % 2 != 0)
            {
                var middleSquareIndex = (shapeData.rows - 1) / 2;
                var multiplier = (shapeData.rows - 1) / 2;

                if (row < middleSquareIndex)//Mover en negativo
                {
                    shiftOnY = moveDistance.y * 1;
                    shiftOnY *= multiplier;
                }
                else if (row > middleSquareIndex)//Mover en positivo
                {
                    shiftOnY = moveDistance.y * -1;
                    shiftOnY *= multiplier;
                }
            }
            else
            {
                var middleSquareIndex2 = (shapeData.rows == 2) ? 1 : (shapeData.rows / 2);
                var middleSquareIndex1 = (shapeData.rows == 2) ? 0 : shapeData.rows - 2;
                var multiplier = shapeData.rows / 2;

                if (row == middleSquareIndex1 || row == middleSquareIndex2)
                {
                    if (row == middleSquareIndex2)
                    {
                        shiftOnY = (moveDistance.y / 2) * -1;
                    }
                    if (row == middleSquareIndex1)
                    {
                        shiftOnY = (moveDistance.y / 2);
                    }
                }

                if (row < middleSquareIndex1 && row < middleSquareIndex2)//Mover en negativo
                {
                    shiftOnY = moveDistance.y * 1;
                    shiftOnY *= multiplier;
                }
                else if (row > middleSquareIndex1 && row > middleSquareIndex2)//Mover en positivo
                {
                    shiftOnY = moveDistance.y * -1;
                    shiftOnY *= multiplier;
                }
            }
        }

        return shiftOnY;
    }
    private float GetXPositionForShapeSquares(ShapeData shapeData, int column, Vector2 moveDistance)
    {
        float shiftOnX = 1f;

        if (shapeData.columns > 1)//Calculando vertical position 
        {
            if (shapeData.columns % 2 != 0)
            {
                var middleSquareIndex = (shapeData.columns - 1) / 2;
                var multiplier = (shapeData.columns - 1) / 2;
                if (column < middleSquareIndex)//Mover en negativo
                {
                    shiftOnX = moveDistance.x * -1;
                    shiftOnX *= multiplier;
                }
                else if (column > middleSquareIndex)//Mover en positivo
                {
                    shiftOnX = moveDistance.x * 1;
                    shiftOnX *= multiplier;
                }
            }
            else
            {
                var middleSquareIndex2 = (shapeData.columns == 2) ? 1 : (shapeData.columns / 2);
                var middleSquareIndex1 = (shapeData.columns == 2) ? 0 : shapeData.columns - 1;
                var multiplier = shapeData.columns / 2;

                if (column == middleSquareIndex1 || column == middleSquareIndex2)
                {
                    if (column == middleSquareIndex2)
                    {
                        shiftOnX = moveDistance.x / 2;
                    }
                    if (column == middleSquareIndex1)
                    {
                        shiftOnX = (moveDistance.x / 2) * -1;
                    }
                }
                if (column < middleSquareIndex1 && column < middleSquareIndex2)//Mover en negativo
                {
                    shiftOnX = moveDistance.x * -1;
                    shiftOnX *= multiplier;
                }
                else if (column > middleSquareIndex1 & column > middleSquareIndex2)//Mover en positivo
                {
                    shiftOnX = moveDistance.x * 1;
                    shiftOnX *= multiplier;
                }
            }
        }

        return shiftOnX;
    }
    private int GetNumberOfSquares(ShapeData shapeData)
    {
        int number = 0;

        foreach (var rowData in shapeData.board)
        {
            foreach (var active in rowData.column)
            {
                if (active)
                {
                    number++;
                }
            }
        }

        return number;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            _shapeSelected = false;
            //this.GetComponent<RectTransform>().localScale = _shapeStartScale;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //this.GetComponent<RectTransform>().localScale = shapeSelectedScale;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _transform.anchorMin = new Vector2(0, 0);
            _transform.anchorMax = new Vector2(0, 0);
            _transform.pivot = new Vector2(0, 0);

            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, eventData.position, Camera.main, out pos);
            _transform.localPosition = pos + offset;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        GameEvents.CheckIfShapeCanBePlaced();
        //this.GetComponent<RectTransform>().localScale = _shapeStartScale;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _shapeSelected = true;
            //this.GetComponent<RectTransform>().localScale = shapeSelectedScale;
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            _transform.localEulerAngles = new Vector3(0, 0, _transform.localEulerAngles.z + 90f);
        }
    }
    private void MoveShapeToStartPosition()
    {
        //_transform.transform.localPosition = _startPosition;
    }
}