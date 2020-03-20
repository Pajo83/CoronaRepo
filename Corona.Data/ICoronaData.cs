using Corona.Core;
using System;
using System.Collections.Generic;

namespace Corona.Data
{
    public interface ICoronaData
    {
        IEnumerable<Patient> GetPatients(string name = null);
        Patient GetPatientById(int patientId);
        Patient Update(Patient patient);
        int Commit();
        Patient Create(Patient patient);
        Patient Delete(int patientId);
        int Count();
    }
}
