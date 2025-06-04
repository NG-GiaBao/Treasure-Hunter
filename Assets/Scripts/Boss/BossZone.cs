using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZone : MonoBehaviour
{
    [SerializeField] private GameObject[] m_Bg;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("go");
            GetSpriteRenderer();
            AudioManager.instance.MusicCombat();
        }
    }

    private void GetSpriteRenderer()
    {
        foreach (GameObject go in m_Bg)
        {
            SpriteRenderer[] spriteRenderers = go.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                StartCoroutine(ChangeColor(spriteRenderer, new Color32(197, 12, 12, 255), 2f));
            }
        }
    }

    private IEnumerator ChangeColor(SpriteRenderer spriteRenderer, Color32 targetColor, float duration)
    {
        Color32 initialColor = spriteRenderer.color;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            spriteRenderer.color = Color32.Lerp(initialColor, targetColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        spriteRenderer.color = targetColor;
    }
    
}