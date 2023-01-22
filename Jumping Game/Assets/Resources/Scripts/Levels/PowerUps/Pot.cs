using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Pot : MonoBehaviour, IDropHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static PointerEventData eventData;
    public static CanvasGroup canvas;
    private GameObject[] listOfPowerUps = new GameObject[3]; 
    private Animator potAnim;
    private RectTransform potTransform;
    private Vector2 initialPos;
    private bool drag = false;
    private GameObject selectedCharacter;
    public static bool successfulPowerUp = false;
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        potAnim = GetComponent<Animator>();
        potAnim.SetFloat("fractionOfPotions", 0);
        potTransform = GetComponent<RectTransform>();
        selectedCharacter = Level1.selectedCharacterCollider.gameObject;
    }
    void Update()
    {
    }
    public void OnDrop(PointerEventData eventData)
    {
        Pot.eventData = eventData;
        if (eventData.pointerDrag != null)
        {
            canvas.alpha = 1;
            if (!drag && eventData.pointerDrag.transform.parent.gameObject == PowerUps.powerUpPanelTransform.gameObject)
            {
                if (listOfPowerUps[0] == null)
                {
                    listOfPowerUps[0] = eventData.pointerDrag.GetComponent<RectTransform>().gameObject;
                    potAnim.SetFloat("fractionOfPotions", (float)1/3);
                } 
                else if (listOfPowerUps[0] != null && listOfPowerUps[1] == null)
                {
                    listOfPowerUps[1] = eventData.pointerDrag.GetComponent<RectTransform>().gameObject;
                    potAnim.SetFloat("fractionOfPotions", (float)2/3);
                }
                else if (listOfPowerUps[0] != null && listOfPowerUps[1] != null)
                {
                    listOfPowerUps[2] = eventData.pointerDrag.GetComponent<RectTransform>().gameObject;
                    potAnim.SetFloat("fractionOfPotions", (float)1);
                }
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (listOfPowerUps[1] != null)
        {
            canvas.alpha = 1;
            potTransform.anchoredPosition += eventData.delta;
        }
    }
    public  void OnBeginDrag(PointerEventData eventData)
    {
        initialPos = potTransform.anchoredPosition;
        drag = true;
    }
    public  void OnEndDrag(PointerEventData eventData)
    {
        if (potTransform.transform.position.x < selectedCharacter.transform.position.x + selectedCharacter.transform.GetChild(0).gameObject.GetComponent<Renderer>().bounds.size.x && potTransform.transform.position.x > selectedCharacter.transform.position.x - selectedCharacter.transform.GetChild(0).gameObject.GetComponent<Renderer>().bounds.size.x)
        {
            if (potTransform.transform.position.y < selectedCharacter.transform.position.y + selectedCharacter.transform.GetChild(0).gameObject.GetComponent<Renderer>().bounds.size.y && potTransform.transform.position.y > selectedCharacter.transform.position.y - selectedCharacter.transform.GetChild(0).gameObject.GetComponent<Renderer>().bounds.size.y)
            {
                potTransform.anchoredPosition = initialPos;
                Array.Clear(listOfPowerUps, 0, listOfPowerUps.Length);
                successfulPowerUp = true;
                potAnim.SetFloat("fractionOfPotions", (float)0);
                canvas.blocksRaycasts = false;
                canvas.alpha = 0.2f;
                //Code to execute power up
            }
            else
            {
                potTransform.anchoredPosition = initialPos;
            }
        } 
        else 
        {
            potTransform.anchoredPosition = initialPos;
        }
        drag = false;
    }
}
