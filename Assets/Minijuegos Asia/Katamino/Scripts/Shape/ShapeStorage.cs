using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeStorage : MonoBehaviour
{
    public List<ShapeData> shapeData;
    public List<ShapeData> shapeData1;
    public List<ShapeData> shapeData2;
    public List<ShapeData> shapeData3;
    public List<ShapeData> shapeData4;
    public List<ShapeData> shapeData5;
    public List<ShapeData> shapeData6;
    public List<ShapeData> shapeData7;
    public List<ShapeData> shapeData8;
    public List<Shape> shapeList;
    public List<Shape> shapeList1;
    public List<Shape> shapeList2;
    public List<Shape> shapeList3;
    public List<Shape> shapeList4;
    public List<Shape> shapeList5;
    public List<Shape> shapeList6;
    public List<Shape> shapeList7;
    public List<Shape> shapeList8;

    private void OnEnable()
    {
        GameEvents.RequestNewShapes += RequestNewShapes;
    }
    private void OnDisable()
    {
        GameEvents.RequestNewShapes -= RequestNewShapes;
    }
    void Start()
    {
        foreach (var shape in shapeList)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData.Count);
            shape.CreateShape(shapeData[shapeIndex]);
        }
        foreach (var shape in shapeList1)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData1.Count);
            shape.CreateShape(shapeData1[shapeIndex]);
        }
        foreach (var shape in shapeList2)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData2.Count);
            shape.CreateShape(shapeData2[shapeIndex]);
        }
        foreach (var shape in shapeList3)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData3.Count);
            shape.CreateShape(shapeData3[shapeIndex]);
        }
        foreach (var shape in shapeList4)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData4.Count);
            shape.CreateShape(shapeData4[shapeIndex]);
        }
        foreach (var shape in shapeList5)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData5.Count);
            shape.CreateShape(shapeData5[shapeIndex]);
        }
        foreach (var shape in shapeList6)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData6.Count);
            shape.CreateShape(shapeData6[shapeIndex]);
        }
        foreach (var shape in shapeList7)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData7.Count);
            shape.CreateShape(shapeData7[shapeIndex]);
        }
        foreach (var shape in shapeList8)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData8.Count);
            shape.CreateShape(shapeData8[shapeIndex]);
        }
    }
    public Shape GetCurrentSelectedShape()
    {
        foreach (var shape in shapeList)
        {
            if (shape.IsOnStartPosition() == false && shape.IsAnyOfShapeSquareActive())
                return shape;
        }
        foreach (var shape in shapeList1)
        {
            if (shape.IsOnStartPosition() == false && shape.IsAnyOfShapeSquareActive())
                return shape;
        }
        foreach (var shape in shapeList2)
        {
            if (shape.IsOnStartPosition() == false && shape.IsAnyOfShapeSquareActive())
                return shape;
        }
        foreach (var shape in shapeList3)
        {
            if (shape.IsOnStartPosition() == false && shape.IsAnyOfShapeSquareActive())
                return shape;
        }
        foreach (var shape in shapeList4)
        {
            if (shape.IsOnStartPosition() == false && shape.IsAnyOfShapeSquareActive())
                return shape;
        }
        foreach (var shape in shapeList5)
        {
            if (shape.IsOnStartPosition() == false && shape.IsAnyOfShapeSquareActive())
                return shape;
        }
        foreach (var shape in shapeList6)
        {
            if (shape.IsOnStartPosition() == false && shape.IsAnyOfShapeSquareActive())
                return shape;
        }
        foreach (var shape in shapeList7)
        {
            if (shape.IsOnStartPosition() == false && shape.IsAnyOfShapeSquareActive())
                return shape;
        }
        foreach (var shape in shapeList8)
        {
            if (shape.IsOnStartPosition() == false && shape.IsAnyOfShapeSquareActive())
                return shape;
        }

        Debug.Log("No hay shape selecionada");
        return null;
    }
    private void RequestNewShapes()
    {
        foreach (var shape in shapeList)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData.Count);
            shape.RequestNewShape(shapeData[shapeIndex]);
        }
        foreach (var shape in shapeList1)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData1.Count);
            shape.RequestNewShape(shapeData1[shapeIndex]);
        }
        foreach (var shape in shapeList2)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData2.Count);
            shape.RequestNewShape(shapeData2[shapeIndex]);
        }
        foreach (var shape in shapeList3)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData3.Count);
            shape.RequestNewShape(shapeData3[shapeIndex]);
        }
        foreach (var shape in shapeList4)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData4.Count);
            shape.RequestNewShape(shapeData4[shapeIndex]);
        }
        foreach (var shape in shapeList5)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData5.Count);
            shape.RequestNewShape(shapeData5[shapeIndex]);
        }
        foreach (var shape in shapeList6)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData6.Count);
            shape.RequestNewShape(shapeData6[shapeIndex]);
        }
        foreach (var shape in shapeList7)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData7.Count);
            shape.RequestNewShape(shapeData7[shapeIndex]);
        }
        foreach (var shape in shapeList8)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData8.Count);
            shape.RequestNewShape(shapeData8[shapeIndex]);
        }
    }
}
