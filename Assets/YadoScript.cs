using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YadoScript : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject childObj;
    private bool isHold;

    public void SetIsHold(bool set) { isHold = set; }
    void Start()
    {
        childObj = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHold)
        {
            childObj.SetActive(false);
        }
        else
        {
            childObj.SetActive(true);
        }
    }
}
