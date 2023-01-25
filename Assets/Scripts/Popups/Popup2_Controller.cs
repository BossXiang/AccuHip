using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup2_Controller : MonoBehaviour
{
    [SerializeField] private FlowController flowController;
    [SerializeField] private GameObject nextBtnPicObj;
    [SerializeField] private List<Sprite> statePics;
    private int currentState = 0;

    public void ResetState()
    {
        currentState = 0;
        nextBtnPicObj.GetComponent<SpriteRenderer>().sprite = statePics[currentState];
    }


    public void nextStep()
    {
        if(currentState < statePics.Count - 1)
        {
            currentState++;
            nextBtnPicObj.GetComponent<SpriteRenderer>().sprite = statePics[currentState];
        } else
        {
            flowController.closePopups();
            flowController.goToNextStep();
        }
    }

}
