using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform powerUpTransform;
    private VerticalLayoutGroup powerUpPanel;
    public static RectTransform powerUpPanelTransform;
    private CanvasGroup canvasGroup;
    public static Vector2 initialPos;
    void Start()
    {
        powerUpTransform = GetComponent<RectTransform>();
        powerUpPanel = GameObject.Find("PowerUps").GetComponent<VerticalLayoutGroup>();
        powerUpPanelTransform = GameObject.Find("PowerUps").GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void Update()
    {
        if (Pot.successfulPowerUp)
        {
            StartCoroutine(passiveMe(5));
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1;
        initialPos = powerUpTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
        Pot.eventData = null;
    }
    public void OnDrag(PointerEventData eventData)
    {
        powerUpPanel.enabled = false;
        powerUpTransform.anchoredPosition += eventData.delta / powerUpPanelTransform.localScale;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        powerUpTransform.anchoredPosition = initialPos;
        canvasGroup.alpha = .2f;
        if (Pot.eventData == null)
        {
            canvasGroup.alpha = .5f;
            canvasGroup.blocksRaycasts = true;
        }
    }
     IEnumerator passiveMe(int secs)
    {
        yield return new WaitForSeconds(secs);
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = .5f;
        Pot.canvas.blocksRaycasts = true;
        Pot.successfulPowerUp = false;
        Pot.canvas.alpha = 0.5f;
    }
}
