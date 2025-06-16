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
        if (ListenerManager.HasInstance)
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
        switch (collision.gameObject.tag)
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

        switch (itemType)
        {
            case ItemType.Coin:
                SpawnItemFly(collision.transform.position, targetUIPositions[itemType].anchoredPosition, sprite, itemType);
                Debug.Log($"SpawnItemFly: {itemType} at {targetUIPositions[itemType].anchoredPosition}");
                break;
            case ItemType.Map:
                SpawnItemFly(collision.transform.position, targetRectranform, sprite, itemType);
                break;
            case ItemType.GreenDiamond:
                var greenTarget = TargetLocal(targetUIPositions[itemType]);
                SpawnItemFly(collision.transform.position, greenTarget, sprite, itemType);
                Debug.Log($"SpawnItemFly: {itemType} at {targetUIPositions[itemType].anchoredPosition}");
                break;
            case ItemType.RedDiamond:
                var redTarget = TargetLocal(targetUIPositions[itemType]);
                SpawnItemFly(collision.transform.position, redTarget, sprite, itemType);
                Debug.Log($"SpawnItemFly: {itemType} at {targetUIPositions[itemType].anchoredPosition}");
                break;
            case ItemType.BlueDiamond:
                var blueTarget = TargetLocal(targetUIPositions[itemType]);
                SpawnItemFly(collision.transform.position, blueTarget, sprite, itemType);
                Debug.Log($"SpawnItemFly: {itemType} at {targetUIPositions[itemType].anchoredPosition}");
                break;
        }

        //SpawnItemFly(collision.transform.position, targetRectranform, sprite, itemType);
        Destroy(collision.gameObject);
    }

    private void SpawnItemFly(Vector3 worldPos, Vector2 targetFly, Sprite sprite, ItemType itemType)
    {
        if (overlayItemFly != null && targetRectranform != null)
        {
            GameObject item = Instantiate(overlayItemFly, overlayContainer);
            if (item.TryGetComponent<Image>(out var itemImage))
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
                  if (GameManager.HasInstance)
                  {
                      switch (itemType)
                      {
                          case ItemType.Coin:
                              QuestManager.Instance.AddItemValue(itemType);
                              break;
                          case ItemType.Map:
                              ShowNotifyCollector();
                              break;
                          case ItemType.GreenDiamond:
                              QuestManager.Instance.AddItemValue(itemType);
                              break;
                          case ItemType.RedDiamond:
                              QuestManager.Instance.AddItemValue(itemType);
                              break;
                          case ItemType.BlueDiamond:
                              QuestManager.Instance.AddItemValue(itemType);
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
        if (QuestManager.HasInstance)
        {
            QuestManager.Instance.SetCurrentMission(QuestMission.firstMission);
        }
    }
    private void OnEventSendRectItem(object value)
    {
        if (value is (RectTransform rectTransform, ItemType itemType))
        {
            switch (itemType)
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
    private Vector2 TargetLocal(RectTransform rectTransform)
    {
        Vector2 target = ConvertRectTransformToOverlayLocal(rectTransform, mainCanvas, overlayContainer);
        return target;

        //var targetRT = targetUIPositions[itemType];
        //Vector2 targetLocal = 
    }
    /// <summary>
    /// Chuyển một RectTransform bất kỳ trong canvas
    /// thành anchoredPosition tương ứng trong overlayContainer.
    /// </summary>
    Vector2 ConvertRectTransformToOverlayLocal(RectTransform source, Canvas canvas, RectTransform overlayContainer)
    // RectTransform gốc sâu trong hierarchy
    // Canvas chứa source
    // Container bạn tween tới
    {
        // 1) world position ở center của source
        Vector3 worldPoint = source.TransformPoint(source.rect.center);

        // 2) world → screen
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera, worldPoint);
        // 3) screen → local point trong overlayContainer
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            overlayContainer,
            screenPoint,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay
                ? null
                : canvas.worldCamera,
            out Vector2 localPoint);

        return localPoint;
    }

}
