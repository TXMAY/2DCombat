using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    Image _image;

    [SerializeField] float drainTime = 0.5f;
    float _target = 1f;

    void Start()
    {
        _image = GetComponent<Image>();
    }

    public void UpdateHPBar(int maxHP, int currentHP)
    {
        _target = (float)currentHP / maxHP;
        StartCoroutine(DrainHPBar());
    }

    public IEnumerator DrainHPBar()
    {
        float fillAmount = _image.fillAmount;

        Color currentColor = _image.color;

        float elapsedTime = 0;

        while (elapsedTime < drainTime)
        {
            elapsedTime += Time.deltaTime;

            _image.fillAmount = Mathf.Lerp(fillAmount, _target, elapsedTime / drainTime);

            yield return null;
        }
    }
}
