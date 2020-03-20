﻿using Corona.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corona.Data
{
    public class CoronaDataSql : ICoronaData
    {
        private readonly CoronaDbContext coronaDbContext;

        public CoronaDataSql(CoronaDbContext coronaContext)
        {
            this.coronaDbContext = coronaContext;
        }
        public int Commit()
        {
            return coronaDbContext.SaveChanges();
        }

        public int Count()
        {
            return coronaDbContext.Patients.Count();
        }

        public Patient Create(Patient patient)
        {
            coronaDbContext.Patients.Add(patient);
            return patient;
        }

        public Patient Delete(int patientId)
        {
            var tempPatient = coronaDbContext.Patients.SingleOrDefault(p => p.Id == patientId);
            if (tempPatient != null)
            {
               coronaDbContext.Patients.Remove(tempPatient);
            }
            return tempPatient;
        }

        public Patient GetPatientById(int patientId)
        {
            return coronaDbContext.Patients.SingleOrDefault(p => p.Id == patientId);
        }

        public IEnumerable<Patient> GetPatients(string name = null)
        {
            var param = !string.IsNullOrEmpty(name) ? $"{name}%" : name;
            return coronaDbContext.Patients.Where(p => string.IsNullOrEmpty(name) || EF.Functions.Like(p.Name, param)).ToList();
        }

        public Patient Update(Patient patient)
        {
           coronaDbContext.Entry(patient).State = EntityState.Modified;
            return patient;
        }
    }
}
