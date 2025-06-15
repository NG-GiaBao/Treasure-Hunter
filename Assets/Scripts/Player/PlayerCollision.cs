using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private GameObject overlayItemFly;
    [SerializeField] private Vector2 targetRectranform;
    [SerializeField] private RectTransform overlayContainer;
    [SerializeField] private float durationFly;
    [ShowInInspector]
    private readonly Dictionary<ItemType, RectTransform> targetUIPositions = new();
    private const string PATH_OVERLAY_ITEM_FLY = "Prefabs/UI/Overlap/OverlayItemFly";

    private void Start()
    {
        overlayItemFly = Resources.Load<GameObject>(PATH_OVERLAY_ITEM_FLY);
        if(ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Register(ListenType.OnSendRectItem, OnEventSendRectItem);
        }
    }
    private void OnDestroy()
    {
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Unregister(ListenType.OnSendRectItem, OnEventSendRectItem);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Diamond":
                InitItem(collision);
                break;
            case "Coin":
                InitItem(collision);
                break;
            case "Minimap":
                InitItem(collision);
                break;
            default:
                // Handle other collisions if needed
                break;
        }
       
    }

    private void InitItem(Collider2D collision)
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE("ItemSound");
        }
        Sprite sprite = collision.GetComponent<SpriteRenderer>().sprite;
        ItemType itemType = collision.GetComponent<MapType>().ItemType;
        switch(itemType)
        {
            case ItemType.Coin:
                SpawnItemFly(collision.transform.position, targetUIPositions[itemType].anchoredPosition, sprite, itemType);
                break;
            case ItemType.Map:
                SpawnItemFly(collision.transform.position, targetRectranform, sprite, itemType);
                break;
            case ItemType.GreenDiamond:
                SpawnItemFly(collision.transform.position, targetUIPositions[itemType].anchoredPosition, sprite, itemType);
                break;
            case ItemType.RedDiamond:
                SpawnItemFly(collision.transform.position, targetUIPositions[itemType].anchoredPosition, sprite, itemType);
                break;
            case ItemType.BlueDiamond:
                SpawnItemFly(collision.transform.position, targetUIPositions[itemType].anchoredPosition, sprite, itemType);
                break;
        }

        //SpawnItemFly(collision.transform.position, targetRectranform, sprite, itemType);
        Destroy(collision.gameObject);
    }

    private void SpawnItemFly(Vector3 worldPos,Vector2 targetFly,Sprite sprite,ItemType itemType)
    {
        if (overlayItemFly != null && targetRectranform != null)
        {
            GameObject item = Instantiate(overlayItemFly, overlayContainer);
            if(item.TryGetComponent<Image>(out var itemImage))
            {
                itemImage.sprite = sprite;
            }
            RectTransform rt = item.GetComponent<RectTransform>();
            // B. Tính vị trí bắt đầu trên Canvas (local point) từ worldPos
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(worldPos);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                mainCanvas.transform as RectTransform,
            screenPoint,
            mainCanvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : mainCanvas.worldCamera,
                out Vector2 localPoint
            );
            rt.anchoredPosition = localPoint;

            // C. Tween bay tới targetUIPos
            rt
              .DOAnchorPos(targetFly, durationFly)
              .SetEase(Ease.InBack)
              .OnComplete(() =>
              {
                  if(GameManager.HasInstance)
                  {
                      switch (itemType)
                      {
                          case ItemType.Coin:
                              GameManager.Instance.AddItemValue(itemType);
                              break;
                          case ItemType.Map:
                              ShowNotifyCollector();
                              break;
                          case ItemType.GreenDiamond:
                              GameManager.Instance.AddItemValue(itemType);
                              break;
                          case ItemType.RedDiamond:
                              GameManager.Instance.AddItemValue(itemType);
                              break;
                          case ItemType.BlueDiamond:
                              GameManager.Instance.AddItemValue(itemType);
                              break;
                              // Add other item types as needed
                      }
                  }
                  // Ví dụ: add vào inventory, update UI, or destroy icon
                  Destroy(item);
                  
              });
        }
    }
    private void ShowNotifyCollector()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowNotify<NotifyMission>();
        }
    }
    private void OnEventSendRectItem(object value)
    {
        if (value is (RectTransform rectTransform, ItemType itemType))
        {
            switch(itemType)
            {
                case ItemType.Coin:
                    {
                        if (!targetUIPositions.ContainsKey(itemType)) targetUIPositions.Add(itemType, rectTransform);
                        else targetUIPositions[itemType] = rectTransform;
                    }
                    break;
                case ItemType.GreenDiamond:
                    {
                        if (!targetUIPositions.ContainsKey(itemType)) targetUIPositions.Add(itemType, rectTransform);
                        else targetUIPositions[itemType] = rectTransform;
                    }
                    break;
                case ItemType.RedDiamond:
                    {
                        if (!targetUIPositions.ContainsKey(itemType)) targetUIPositions.Add(itemType, rectTransform);
                        else targetUIPositions[itemType] = rectTransform;
                    }
                    break;
                case ItemType.BlueDiamond:
                    {
                        if (!targetUIPositions.ContainsKey(itemType)) targetUIPositions.Add(itemType, rectTransform);
                        else targetUIPositions[itemType] = rectTransform;
                    }
                    break;
            }
        }
    }
}
