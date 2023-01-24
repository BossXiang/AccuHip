using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Step3_Controller : MonoBehaviour
{
    [SerializeField] private Sprite background, background_selected;
    [SerializeField] private GameObject supineBGObj, lateralBGObj;
    [SerializeField] private GameObject nextButton;
    private Workflow workflow;

    // Start is called before the first frame update
    void Start()
    {
        workflow = Workflow.None;
        nextButton.SetActive(workflow != Workflow.None);
    }
    
    public void SetToSupine()
    {
        workflow = Workflow.Supine;
        supineBGObj.GetComponent<SpriteRenderer>().sprite = background_selected;
        lateralBGObj.GetComponent<SpriteRenderer>().sprite = background;
        nextButton.SetActive(true);
    }

    public void SetToLateral()
    {
        workflow = Workflow.Lateral;
        supineBGObj.GetComponent<SpriteRenderer>().sprite = background;
        lateralBGObj.GetComponent<SpriteRenderer>().sprite = background_selected;
        nextButton.SetActive(true);
    }
}
