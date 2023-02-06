using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Step1_Controller : MonoBehaviour
{
    [SerializeField] private Transform step1_trans;
    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private Sprite rowBG, rowBG_selected;
    private List<GameObject> rows;
    private List<Patient> patients;
    private int lastSelectedIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        patients = new List<Patient>();
        rows = new List<GameObject>();

        Patient patient = new Patient();
        patient.initialization("01/02/2021", "Jason Lee", "male", "6809203819");
        patients.Add(patient);
        Patient patient2 = new Patient();
        patient2.initialization("01/03/2021", "Tom", "male", "6809203820");
        patients.Add(patient2);
        Patient patient3 = new Patient();
        patient3.initialization("01/04/2021", "Johnson", "male", "6809203821");
        patients.Add(patient3);

        for(int i = 0;i < patients.Count; i++)
        {
            GameObject row = Instantiate(rowPrefab, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
            row.transform.parent = step1_trans;
            row.transform.localPosition = new Vector3(0, 0.7f - 0.4778f * i, 0);
            row.transform.localScale = new Vector3(1, 1, 1);

            // Update Information
            row.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshPro>().text = patients[i].date;
            row.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshPro>().text = patients[i].name;
            row.transform.GetChild(1).transform.GetChild(2).GetComponent<TextMeshPro>().text = patients[i].gender;
            row.transform.GetChild(1).transform.GetChild(3).GetComponent<TextMeshPro>().text = patients[i].chart_number;
            row.name = patients[i].chart_number;

            // Add event listener
            row.transform.GetChild(0).GetComponent<PressableButtonHoloLens2>().ButtonPressed.AddListener(() => { ItemClicked(row.name); });

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

        rows[lastSelectedIndex].transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = rowBG;
        rows[index].transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = rowBG_selected;
        lastSelectedIndex = index;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
