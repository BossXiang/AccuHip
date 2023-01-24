using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Side
{
    None, Left, Right
}
enum Workflow
{
    None, Supine, Lateral
}
class CupOrientation
{
    public float Inclination, Anteversion;
}
class ReferencePlane
{
    public float Inclination, Anteversion;
}
class HipCenter_Rotation
{
    public float Superior, Lateral, Anterior;
}
class LegLength_Offset
{
    public float Inclination, Anteversion;
}
class SummaryInfo
{
    public CupOrientation cupOrientation;
    public ReferencePlane referencecPlane;
    public HipCenter_Rotation hipCenter_Rotation;
    public LegLength_Offset legLength_Offset;
}

public class Patient
{
    private string PatientName;
    private Side operatingSide = Side.None;
    private Workflow workflow = Workflow.None;
    private SummaryInfo summaryInfo;

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