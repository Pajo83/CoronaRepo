using Corona.Core;
using System;
using System.Collections.Generic;

namespace Corona.Data
{
    public interface ICoronaData
    {
        IEnumerable<Patient> GetPatients(string name = null);
        Patient GetPatientById(int patientId);
        Hospital GetHospitalById(int hospitalId);
        Patient Update(Patient patient);
        Hospital Update(Hospital hospital);
        int Commit();
        Patient Create(Patient patient);
        Hospital Create(Hospital hospital);
        Patient Delete(int patientId);
        int Count();
        int CountHospitals();
    }
}
