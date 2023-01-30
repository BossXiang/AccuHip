using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Step4_Controller : MonoBehaviour
{
    [SerializeField] private Sprite left, left_selected, right, right_selected;
    [SerializeField] private Sprite left_selected_pic, right_selected_pic;
    [SerializeField] private GameObject picObj;
    [SerializeField] private GameObject leftObj, rightObj;
    [SerializeField] private GameObject nextButton;

    // Start is called before the first frame update
    void Start()
    {
        nextButton.gameObject.SetActive(currentPatient.operatingSide != Side.None);
    }

    public void SetToLeft()
    {
        currentPatient.operatingSide = Side.Left;
        leftObj.GetComponent<SpriteRenderer>().sprite = left_selected;
        rightObj.GetComponent<SpriteRenderer>().sprite = right;
        picObj.GetComponent<SpriteRenderer>().sprite = left_selected_pic;
        nextButton.SetActive(true);
    }

    public void SetToRight()
    {
        currentPatient.operatingSide = Side.Right;
        leftObj.GetComponent<SpriteRenderer>().sprite = left;
        rightObj.GetComponent<SpriteRenderer>().sprite = right_selected;
        picObj.GetComponent<SpriteRenderer>().sprite = right_selected_pic;
        nextButton.SetActive(true);
    }
}
