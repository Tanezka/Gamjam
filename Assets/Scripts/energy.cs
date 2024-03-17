using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy : MonoBehaviour
{
    public GameObject bar;
    public GameObject rocket;
    public RectTransform rectTransform;
    public int          time;
    int                 constant;
    bool				flag = true;

    float          scale;
    // Start is called before the first frame update
    void Start()
    {
        //AnimateBar();
        scale = rectTransform.localScale.x;
    }

    public void AnimateBar()
    {
        LeanTween.scaleX(bar, 1, time);
    }
    // Update is called once per frame
    void Update()
    {
		if (flag)
		{
	        if (rectTransform.localScale.x > 0)
	            rectTransform.localScale = new Vector3(rectTransform.localScale.x - (Time.deltaTime * (scale / time)), rectTransform.localScale.y, rectTransform.localScale.z);
			else
			{
				Destroy(rocket);
				flag = false;
			}
		}
	}
}
