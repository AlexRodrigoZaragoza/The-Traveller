using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MovimientoPiezas : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform objectTransform; //RECT TRANSFORM PARA MOVER LAS PIEZAS
    public CanvasGroup canvasGroup; //CANVASGROUP PARA CAMBIAR EL ALFA DE LAS PIEZAS
    float speed = 45f; //VELOCIDAD DE LA ROTACIÓN
    public float rotacion; //FLOAT PARA LA ROTACIÓN DE LAS PIEZAS
    private int numeroPiezasCogidas = 0;//INT PARA SABER SI SE HA COGIDO UNA PIEZA
    public AudioSource pieceSelectedSound;
    private void Awake()
    {
        objectTransform = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //--------------------CAMBIO DE LOS VALORES DEL CANVAS GROUP Y LA BOOL DE LA PIEZA SELECCIONADA--------------------//
        if (Input.GetKey(KeyCode.Mouse0) && SombrasTangram.piezaCompletada == false && numeroPiezasCogidas <= 1) //Input.GetKey("mouse0")
        {
            pieceSelectedSound.Play();
            canvasGroup.alpha = .6f;
            numeroPiezasCogidas = 1;
        }

        }
    public void OnDrag(PointerEventData eventData)
    {
        //--------------------MOVIMIENTO PIEZAS--------------------//
        if (Input.GetKey(KeyCode.Mouse0) && SombrasTangram.piezaCompletada == false && numeroPiezasCogidas<=1)
        {
            objectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        pieceSelectedSound.Play();
        //--------------------CAMBIO DE LOS VALORES DEL CANVAS GROUP Y LA BOOL DE LA PIEZA SELECCIONADA--------------------//
        canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        numeroPiezasCogidas = 0;

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //--------------------ROTACIÓN PIEZAS--------------------//
        if (Input.GetKey(KeyCode.Mouse1) && SombrasTangram.piezaCompletada == false && numeroPiezasCogidas <= 1)
        {
            canvasGroup.blocksRaycasts = true;
            objectTransform.localEulerAngles = new Vector3(0f, 0f, objectTransform.localEulerAngles.z + speed);
        }
        if (Input.GetKey(KeyCode.Mouse2) && SombrasTangram.piezaCompletada == false && numeroPiezasCogidas <= 1)
        {
            canvasGroup.blocksRaycasts = true;
            objectTransform.localEulerAngles = new Vector3(0f, 0f, objectTransform.localEulerAngles.z - speed);
        }
    }
}
   

