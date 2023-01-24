using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
   
    public static void savePatient(PatientData patientData) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/patient.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        // PatientData data = new PatientData(patientData);

        // formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PatientData LoadPatient()
    {
        string path = Application.persistentDataPath + "/patient.dat";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PatientData data = formatter.Deserialize(stream) as PatientData;
            stream.Close();
            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
