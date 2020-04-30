using AutoMapper;
using EmberMedicalServicePortal.Data;
using EmberMedicalServicePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmberMedicalServicePortal.MappingDB
{
    public class MappingDb : Profile
    {
        public MappingDb()
        {
            CreateMap<Patient, PatientInfoVM>().ReverseMap();
            //CreateMap<Patient, CreatePatientVM>().ReverseMap();       
            CreateMap<MedicalRecord, MedicalHistoryVM>().ReverseMap();
            CreateMap<MedicalRecord, CreateMedicalRecordVM>().ReverseMap();
            CreateMap<Appointment, ListOfAppointmentVM>().ReverseMap();
            CreateMap<Appointment, CreateAppointmentVM>().ReverseMap();
        }
    }
}
