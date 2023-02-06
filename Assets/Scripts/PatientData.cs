using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    None, Left, Right
}
public enum Workflow
{
    None, Supine, Lateral
}
public class CupOrientation
{
    public float Inclination, Anteversion;
}
public class ReferencePlane
{
    public float Inclination, Anteversion;
}
public class HipCenter_Rotation
{
    public float Superior, Lateral, Anterior;
}
public class LegLength_Offset
{
    public float Inclination, Anteversion;
}
public class SummaryInfo
{
    public CupOrientation cupOrientation;
    public ReferencePlane referencecPlane;
    public HipCenter_Rotation hipCenter_Rotation;
    public LegLength_Offset legLength_Offset;
}

//Information 
public class Patient
{
    public string date, name, gender, chart_number;
    public Side operatingSide = Side.None;
    public Workflow workflow = Workflow.None;
    public SummaryInfo summaryInfo;
    public void initialization(string _date, string _name, string _gender, string _chartNumber)
    {
        date = _date;
        name = _name;
        gender = _gender;
        chart_number = _chartNumber;
    }
}

// The information of the current patient
public static class currentPatient {
    public static string name;
    public static Side operatingSide = Side.None;
    public static Workflow workflow = Workflow.None;
    public static SummaryInfo summaryInfo;
    public static void initialization()
    {
        
    }
}


# region For Saving Purpose

[System.Serializable]
public class PatientData
{
    public PatientData()
    {

    }
    public PatientData(Patient patient)
    {

    }


}

#endregion