using System.Collections;
using UnityEngine;

public class InterFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup _fadeCanvasGroup;
    [SerializeField] private float _fadeSpeed = 1f;
    
    private bool _isOpen = false;

    private void Start()
    {
        PlayerController.Instance._input.Player.ToggleUI.performed += _ => ToggleUI();
    }

    private void ToggleUI()
    {
        _isOpen = !_isOpen;

        StartCoroutine(Faded(_isOpen));
    }

    IEnumerator Faded(bool isOpen)
    {
        float alpha = isOpen ? 0f : 1f;
        if(isOpen) // == true
        {
            while(alpha < 1f)
            {
                alpha += _fadeSpeed * Time.deltaTime;
                _fadeCanvasGroup.alpha = alpha;
                yield return null;
            }
        }
        else
        {
            while(alpha > 0f)
            {
                alpha -= _fadeSpeed * Time.deltaTime;
                _fadeCanvasGroup.alpha = alpha;
                yield return null;
            }
        }
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Hello World");
    }
}
