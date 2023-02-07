using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{
    [SerializeField] private GameObject popupControls;
    [SerializeField] private GameObject stepControls;
    [SerializeField] private GameObject patientPopup, summaryPopup, femoralDiscPopup;
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


    private void reset()
    {
        foreach (GameObject g in steps) g.gameObject.SetActive(false);
        currentStep = initialStep;
        steps[currentStep].gameObject.SetActive(true);
        closePopups();
        updateControls();
    }

    private void updateControls()
    {
        if (currentStep <= 1 || currentStep >= steps.Count - 1)
        {
            stepControls.gameObject.SetActive(false);
            popupControls.gameObject.SetActive(false);
        } else {
            stepControls.gameObject.SetActive(true);
            popupControls.gameObject.SetActive(true);
        }

        if (currentStep == 9) nextStepButton.SetActive(false);
        else nextStepButton.SetActive(true);
        lastStepButton.SetActive(true);
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
        if (!controlEnable) return;
        controlEnable = false;
        patientPopup.SetActive(true);
    }

    public void openSummaryPopup()
    {
        if (!controlEnable) return;
        controlEnable = false;
        summaryPopup.SetActive(true);
    }

    public void openFemoralDiscPopup()
    {
        if (!controlEnable) return;
        controlEnable = false;
        femoralDiscPopup.SetActive(true);
    }

    public void closePopups()
    {
        patientPopup.SetActive(false);
        summaryPopup.SetActive(false);
        femoralDiscPopup.SetActive(false);
        controlEnable = true;
    }

    public void setControlEnable(bool _enable)
    {
        controlEnable = _enable;
    }
}
