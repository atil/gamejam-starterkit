using System;
using UnityEngine;
using UnityEngine.UI;

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

[Serializable]
public class FlashInfo
{
    public Color StartColor;
    public Color EndColor;
    public float Duration;
    public AnimationCurve Curve;
}
