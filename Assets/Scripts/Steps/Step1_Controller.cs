using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step1_Controller : MonoBehaviour
{
    [SerializeField] private Transform step1_trans;
    [SerializeField] private GameObject rowPrefab;
    private List<Patient> patients;

    // Start is called before the first frame update
    void Start()
    {
        patients = new List<Patient>();

        Patient patient = new Patient();
        patient.initialization("01/02/2021", "Jason Lee", "male", "6809203819");

        patients.Add(patient);
        patients.Add(patient);
        patients.Add(patient);

        for(int i = 0;i < patients.Count; i++)
        {
            GameObject row = Instantiate(rowPrefab, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
            row.transform.parent = step1_trans;
            row.transform.localPosition = new Vector3(0, 0.7f - 0.4778f * i, 0);
            row.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
