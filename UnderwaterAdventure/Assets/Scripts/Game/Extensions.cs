using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Extensions 
{
    public static void DivideImageBar(this Image image, float biggerValue, float smallerValue)
    {
     float fillValue = (float)smallerValue;
     fillValue /= biggerValue;
    image.fillAmount = fillValue;
    }
    public static void ChangeStateOfCanvasGroup(this CanvasGroup canvasGroup, bool isTunrOn)
    {
        canvasGroup.blocksRaycasts = isTunrOn;
        canvasGroup.alpha = isTunrOn ? 1 : 0;
    }
    public static T GetRandomElementOfList<T>(this List<T> list)
    {
        return list[Random.Range(0,list.Count)];
    }
}
