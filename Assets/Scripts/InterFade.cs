using System.Collections;
using UnityEngine;

public class InterFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeSpeed = 1f;

    private bool _isShown;

    IEnumerator Fade()
    {
        float alpha = _isShown ? 0f : 1f;
        if (_isShown) // == true
        {
            while (alpha < 1f)
            {
                alpha += _fadeSpeed * Time.deltaTime;
                _canvasGroup.alpha = alpha;
                yield return null;
            }
        }
        else
        {
            while (alpha > 0f)
            {
                alpha -= _fadeSpeed * Time.deltaTime;
                _canvasGroup.alpha = alpha;
                yield return null;
            }
        }
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Hello World");
    }

    [ContextMenu("Toggle UI")]
    public void ToggleUI()
    {
        _isShown = !_isShown;

        StartCoroutine(Fade());
    }
}
