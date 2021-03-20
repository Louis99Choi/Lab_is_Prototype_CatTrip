using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour , IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform Lever;
    private RectTransform rectTransform;

    [SerializeField, Range(10, 150)]
    private float LeverRange;

    public static bool isInput;
    public Vector2 inputVector;
    public static Vector2 inputDirection;

    [SerializeField]
    private Player_Movement movement;
    [SerializeField]



    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        LeverControl(eventData);
        isInput = true;        
    }

    public void OnDrag(PointerEventData eventData)
    {
        LeverControl(eventData);        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Lever.anchoredPosition = Vector2.zero;
        isInput = false;               
    }

    public void LeverControl(PointerEventData eventData)
    {
        var inputPos = eventData.position - rectTransform.anchoredPosition;
        if (inputPos.magnitude < LeverRange)
        {
            inputVector = inputPos;
        }
        else
        {
            inputVector = inputPos.normalized * LeverRange;
        }
        Lever.anchoredPosition = inputVector;
        inputDirection = inputVector / LeverRange;
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }
}
