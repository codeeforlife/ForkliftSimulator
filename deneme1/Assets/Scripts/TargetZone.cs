using UnityEngine;

public class TargetZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box")) // Kutunun hedef bölgeye ulaştığını kontrol et
        {
            GameManager.Instance.AddScore(5); // 5 Puan Ekle
            Destroy(other.gameObject); // Kutuyu yok et (isteğe bağlı)
        }
    }
}