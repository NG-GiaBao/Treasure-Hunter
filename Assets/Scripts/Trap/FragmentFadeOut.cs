using UnityEngine;


public class FragmentFadeOut : MonoBehaviour
{
    public float fadeDuration = 1f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float fadeStartTime;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fadeStartTime = Time.time;
    }
    private void Update()
    {
        ChangeAlpha();
    }
    public virtual void ChangeAlpha()
    {
        if (spriteRenderer != null)
        {
            // Tính toán độ alpha dựa trên thời gian
            float elapsed = Time.time - fadeStartTime;

            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);


            // Cập nhật màu sắc
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);

            // Nếu alpha đã giảm xuống 0, hủy đối tượng
            if (alpha <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
