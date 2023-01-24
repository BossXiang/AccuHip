using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Step4_Controller : MonoBehaviour
{
    [SerializeField] private Sprite left, left_selected, right, right_selected;
    [SerializeField] private Sprite right_selected_pic;
    [SerializeField] private GameObject picObj;
    [SerializeField] private GameObject leftObj, rightObj;
    [SerializeField] private GameObject nextButton;
    private Side operativeSide;

    // Start is called before the first frame update
    void Start()
    {
        operativeSide = Side.None;
        nextButton.SetActive(operativeSide != Side.None);
    }

    public void SetToLeft()
    {
        operativeSide = Side.Left;
        leftObj.GetComponent<SpriteRenderer>().sprite = left_selected;
        rightObj.GetComponent<SpriteRenderer>().sprite = right;
        picObj.GetComponent<SpriteRenderer>().sprite = right_selected_pic;
        picObj.transform.rotation = Quaternion.Euler(0, 180, 0);
        nextButton.SetActive(true);
    }

    public void SetToRight()
    {
        operativeSide = Side.Right;
        leftObj.GetComponent<SpriteRenderer>().sprite = left;
        rightObj.GetComponent<SpriteRenderer>().sprite = right_selected;
        picObj.transform.rotation = Quaternion.Euler(0, 0, 0);
        nextButton.SetActive(true);
    }
}
