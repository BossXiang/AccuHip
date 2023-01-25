using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{
    [SerializeField] private GameObject popupControls;
    [SerializeField] private GameObject stepControls;
    [SerializeField] private GameObject patientPopup, summaryPopup;
    [SerializeField] private GameObject lastStepButton, nextStepButton;
    [SerializeField] private List<GameObject> steps;
    [SerializeField] private int initialStep;
    private int currentStep = 0;
    private bool controlEnable = true;

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
        //initialStep = 4;
        foreach(GameObject g in steps) g.gameObject.SetActive(false);
        currentStep = initialStep;
        steps[currentStep].gameObject.SetActive(true);
        closePopups();
        updateControls();
    }
    
    private void updateControls()
    {
        if(currentStep <= 1 || currentStep >= steps.Count - 1)
        {
            stepControls.gameObject.SetActive(false);
            popupControls.gameObject.SetActive(false);
        } else {
            stepControls.gameObject.SetActive(true);
            popupControls.gameObject.SetActive(true);
        }
        lastStepButton.SetActive(true);
        nextStepButton.SetActive(true);
    }

    public void goToLastStep()
    {
        if (!controlEnable || currentStep <= 0) return;
        steps[currentStep].gameObject.SetActive(false);
        currentStep--;
        steps[currentStep].gameObject.SetActive(true);
        updateControls();
    }

    public void goToNextStep()
    {
        if (!controlEnable || currentStep >= steps.Count - 1) return;
        steps[currentStep].gameObject.SetActive(false);
        currentStep++;
        steps[currentStep].gameObject.SetActive(true);
        updateControls();
    }

    public void openPatientPopup()
    {
        controlEnable = false;
        patientPopup.SetActive(true);
    }

    public void openSummaryPopup()
    {
        controlEnable = false;
        summaryPopup.SetActive(true);
    }

    public void closePopups()
    {
        patientPopup.SetActive(false);
        summaryPopup.SetActive(false);
        controlEnable = true;
    }
}
