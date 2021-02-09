using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class FlashInfo
{
    [SerializeField]
    private Color _startColor = default;
    public Color StartColor => _startColor;

    [SerializeField]
    private Color _endColor = default;
    public Color EndColor => _endColor;

    [SerializeField]
    private float _duration = default;
    public float Duration => _duration;

    [SerializeField]
    private AnimationCurve _curve = default;
    public AnimationCurve Curve => _curve;
}

public class Ui : MonoBehaviour
{
    [SerializeField]
    private Image _flashImage = default;

    [SerializeField]
    private FlashInfo _startFlashInfo = default;

    public void StartFlash()
    {
        Curve.Tween(_startFlashInfo.Curve, _startFlashInfo.Duration,
            (t) =>
            {
                _flashImage.color = Color.Lerp(_startFlashInfo.StartColor, _startFlashInfo.EndColor, t);
            },
            () =>
            {
                _flashImage.color = _startFlashInfo.EndColor;
            });
    }

}
