using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Step1_Controller : MonoBehaviour
{
    [SerializeField] private FlowController flowController;
    [SerializeField] private Transform step1_trans;
    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private GameObject popupAdd, popupDelete, popupSummary, popupInfo;
    [SerializeField] private Sprite rowBG, rowBG_selected;
    [SerializeField] private TextMeshPro nameTxt, informationTxt;
    [SerializeField] private TextMeshPro step2NameTxt, step2InformationTxt;
    [SerializeField] private TextMeshPro popupNameTxt, popupInformationTxt;
    private List<GameObject> rows;
    private List<Patient> patients;
    private int lastSelectedIndex = -1;
    private int editTarget = -1, deletionTarget = -1, informationTarget = -1;
    private const float rowTopPos = 0.7f, rowInterval = 0.4778f;
    // Start is called before the first frame update
    void Start()
    {
        popupAdd.gameObject.SetActive(false);
        popupDelete.gameObject.SetActive(false);
        popupSummary.gameObject.SetActive(false);
        popupInfo.gameObject.SetActive(false);

        patients = new List<Patient>();
        rows = new List<GameObject>();

        Patient patient = new Patient();
        patient.initialization("01/02/2021", "Jason Lee", "male", "6809203819", 63);
        patient.additionalInfo.Add("L hip osteonecrosis");
        patient.additionalInfo.Add("Zimmer Biomet G7 cup + E1 liner + M/L taper stem");
        patients.Add(patient);
        Patient patient2 = new Patient();
        patient2.initialization("01/03/2021", "Tom", "male", "6809203820", 57);
        patient2.additionalInfo.Add("L hip osteonecrosis");
        patient2.additionalInfo.Add("Zimmer Biomet G7 cup + E1 liner + M/L taper stem");
        patients.Add(patient2);
        Patient patient3 = new Patient();
        patient3.initialization("01/04/2021", "Johnson", "male", "6809203821", 98);
        patient3.additionalInfo.Add("L hip osteonecrosis");
        patient3.additionalInfo.Add("Zimmer Biomet G7 cup + E1 liner + M/L taper stem");
        patients.Add(patient3);

        for(int i = 0;i < patients.Count; i++)
        {
            GameObject row = Instantiate(rowPrefab, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
            row.transform.parent = step1_trans;
            row.transform.localPosition = new Vector3(0, rowTopPos - rowInterval * i, 0);
            row.transform.localScale = new Vector3(1, 1, 1);

            // Update Information
            row.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshPro>().text = patients[i].date;
            row.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshPro>().text = patients[i].name;
            row.transform.GetChild(1).transform.GetChild(2).GetComponent<TextMeshPro>().text = patients[i].gender;
            row.transform.GetChild(1).transform.GetChild(3).GetComponent<TextMeshPro>().text = patients[i].chart_number;
            row.name = patients[i].chart_number;

            // Add event listener
            row.transform.GetChild(0).GetComponent<PressableButtonHoloLens2>().ButtonPressed.AddListener(() => { ItemClicked(row.name); });
            row.transform.GetChild(2).transform.GetChild(0).GetComponent<PressableButtonHoloLens2>().ButtonPressed.AddListener(() => { ItemEdit(row.name); }); // Edit
            row.transform.GetChild(2).transform.GetChild(1).GetComponent<PressableButtonHoloLens2>().ButtonPressed.AddListener(() => { ItemDelete(row.name); }); // Deletion
            row.transform.GetChild(2).transform.GetChild(2).GetComponent<PressableButtonHoloLens2>().ButtonPressed.AddListener(() => { ItemInformation(row.name); }); // Information Inquiry

            rows.Add(row);
        }

    }

    private int getIndex(string chartNo)
    {
        for(int i = 0;i < rows.Count; ++i)
        {
            if (rows[i].name == chartNo) return i;
        }
        Debug.LogWarning(chartNo + " is not found in patient list!!");
        return -1;
    }

    private void ItemClicked(string name)
    {
        int index = getIndex(name);
        if(lastSelectedIndex != -1) rows[lastSelectedIndex].transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = rowBG;
        rows[index].transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = rowBG_selected;
        lastSelectedIndex = index;
    }

    private void ItemEdit(string name)
    {
        int index = getIndex(name);
        flowController.setControlEnable(false);
        popupAdd.gameObject.SetActive(true);
    }

    public void ItemCreate()
    {
        flowController.setControlEnable(false);
        popupAdd.gameObject.SetActive(true);
    }

    public void saveEdit()
    {

        popupAdd.gameObject.SetActive(false);
        flowController.setControlEnable(true);
    }

    public void revertEdit()
    {

        popupAdd.gameObject.SetActive(false);
        flowController.setControlEnable(true);
    }

    private void ItemDelete(string name)
    {
        int index = getIndex(name);

        flowController.setControlEnable(false);
        deletionTarget = index;
        popupDelete.gameObject.SetActive(true);
    }

    private void ItemInformation(string name)
    {
        int index = getIndex(name);
        flowController.setControlEnable(false);
        // Load data
        nameTxt.text = patients[index].name;
        informationTxt.text = $" - {patients[index].age} y/o {patients[index].gender}";
        for(int i = 0;i < patients[index].additionalInfo.Count;i++) informationTxt.text += Environment.NewLine + " - " + patients[index].additionalInfo[i];

        popupSummary.gameObject.SetActive(true);
    }

    public void removeTargetedItem()
    {
        patients.RemoveAt(deletionTarget);
        for (int i = deletionTarget + 1;i < rows.Count;++i)
        {
            rows[i].transform.localPosition += new Vector3(0.0f, rowInterval, 0.0f);
        }
        Destroy(rows[deletionTarget]);
        rows.RemoveAt(deletionTarget);
        if (deletionTarget == lastSelectedIndex) lastSelectedIndex = -1;
        else if (lastSelectedIndex > deletionTarget) lastSelectedIndex--;
    }

    public void proceedToStart()
    {
        if (lastSelectedIndex == -1) return;

        currentPatient.initialization(patients[lastSelectedIndex].date, patients[lastSelectedIndex].name, patients[lastSelectedIndex].gender, patients[lastSelectedIndex].chart_number, patients[lastSelectedIndex].age);
        currentPatient.additionalInfo.Clear();
        foreach (string info in patients[lastSelectedIndex].additionalInfo) currentPatient.additionalInfo.Add(info);

        // Load data
        step2NameTxt.text = currentPatient.name;
        step2InformationTxt.text = $" - {currentPatient.age} y/o {currentPatient.gender}";
        for (int i = 0; i < currentPatient.additionalInfo.Count; i++) step2InformationTxt.text += Environment.NewLine + " - " + currentPatient.additionalInfo[i];

        popupNameTxt.text = currentPatient.name;
        popupInformationTxt.text = $" - {currentPatient.age} y/o {currentPatient.gender}";
        for (int i = 0; i < currentPatient.additionalInfo.Count; i++) popupInformationTxt.text += Environment.NewLine + " - " + currentPatient.additionalInfo[i];

        flowController.goToNextStep();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
