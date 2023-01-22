using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{

    [SerializeField] private GameObject stepControls;
    [SerializeField] private GameObject popupControls;
    [SerializeField] private List<GameObject> steps;
    private int currentStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void reset()
    {
        foreach(GameObject g in steps) g.gameObject.SetActive(false);
        currentStep = 0;
        steps[currentStep].gameObject.SetActive(true);
        updateControls();
    }
    
    private void updateControls()
    {
        if(currentStep == 0)
        {
            stepControls.gameObject.SetActive(false);
            popupControls.gameObject.SetActive(false);
        } else {
            stepControls.gameObject.SetActive(true);
            popupControls.gameObject.SetActive(true);
        }
    }

    public void goToLastStep()
    {
        if (currentStep <= 0) return;
        steps[currentStep].gameObject.SetActive(false);
        currentStep--;
        steps[currentStep].gameObject.SetActive(true);
        updateControls();
    }

    public void goToNextStep()
    {
        Debug.Log("test");
        if (currentStep >= steps.Count - 1) return;
        steps[currentStep].gameObject.SetActive(false);
        currentStep++;
        steps[currentStep].gameObject.SetActive(true);
        updateControls();
    }

}
