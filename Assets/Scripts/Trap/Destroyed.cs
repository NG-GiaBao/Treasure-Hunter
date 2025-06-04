using UnityEngine;
using System.Collections.Generic;

public class Destroyed : MonoBehaviour
{
    public GameObject[] fragments; // Mảng chứa các prefab mảnh vỡ
    public int fragmentCount = 4;  // Số lượng mảnh vỡ tạo ra
    public float explosionForce = 300f; // Lực nổ
    public List<int> usedIndices = new(); // Danh sách theo dõi các chỉ số đã chọn
    [SerializeField] private AudioClip m_ShatterAudioClip;

   
    public void DestroyTrap()
    {
        PlayShatterAudioClip();
        // Tạo các mảnh vỡ
        for (int i = 0; i < fragmentCount; i++)
        {
            // Lựa chọn mảnh vỡ chưa được sử dụng
            int index = GetRandomUniqueIndex();
            GameObject fragment = Instantiate(fragments[index], transform.position, Quaternion.identity);

            // Thêm lực nổ cho mảnh vỡ
            Rigidbody2D rb = fragment.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Tạo một vector lực ngẫu nhiên
                float forceX = Random.Range(-1f, 1.5f) * explosionForce;
                float forceY = Random.Range(-1f, 1.5f) * explosionForce;
                Vector2 force = new(forceX, forceY);
                
                // Thêm lực cho mảnh vỡ
                rb.AddForce(force);
                
            }
            Destroy(fragment, 5.0f);
        }
        gameObject.SetActive(false);
    }

    // Hàm này trả về chỉ số ngẫu nhiên không bị trùng
    private int GetRandomUniqueIndex()
    {
        int index;
        do
        {
            index = Random.Range(0, fragments.Length); // Chọn ngẫu nhiên mảnh vỡ
        }
        while (usedIndices.Contains(index)); // Kiểm tra nếu đã chọn chỉ số này rồi thì chọn lại

        usedIndices.Add(index); // Thêm chỉ số vào danh sách đã chọn
        return index;
    }

    private void PlayShatterAudioClip()
    {
        AudioManager.instance.PlaySoundEffect(m_ShatterAudioClip);
    }
}
