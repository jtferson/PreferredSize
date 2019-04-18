using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPreferredSize : MonoBehaviour
{
    [SerializeField]
    public LayoutElement LayoutElement;
    [SerializeField]
    public CanvasScaler CanvasScaler;
    [SerializeField]
    public float TabletMinInches = 7.0f;
    [SerializeField]
    public float MaxSize = 750;

    [SerializeField]
    public float ScreenDpi = 326;

    private bool _isTablet;
    private void Start()
    {
        var inches = GetScreenInches();
        print(inches);

        _isTablet = inches >= TabletMinInches;
        print(_isTablet);
        var scaleFactor = CanvasScaler.gameObject.transform.localScale.x;
        var preferredWidth = Screen.width;
        if (_isTablet)
        {
            LayoutElement.preferredWidth = preferredWidth >= MaxSize ? MaxSize / scaleFactor : preferredWidth / scaleFactor;
        }
        else
        {
            LayoutElement.preferredWidth = preferredWidth / scaleFactor;
        }
    }

    private float GetScreenInches()
    {
#if UNITY_EDITOR
        var screenDpi = ScreenDpi;
#else
        var screenDpi = Screen.dpi;
#endif
        var width = (float)Screen.width * Screen.width;
        var height = (float)Screen.height * Screen.height;
        var temp = width + height;
        temp = Mathf.Sqrt(temp);
        return temp / screenDpi;
    }
}
