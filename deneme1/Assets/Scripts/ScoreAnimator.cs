using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreAnimator : MonoBehaviour
{
    public Text scoreText;

    public void AnimateScore()
    {
        StartCoroutine(ScaleEffect());
    }

    private IEnumerator ScaleEffect()
    {
        Vector3 originalScale = scoreText.transform.localScale;
        scoreText.transform.localScale = originalScale * 1.2f; // Büyüt

        yield return new WaitForSeconds(0.2f);

        scoreText.transform.localScale = originalScale; // Eski haline getir
    }
}