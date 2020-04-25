using AutoMapper;
using Ember_Medical_Service.Data;
using Ember_Medical_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ember_Medical_Service.DBMapping
{                                                       
    public class MappingDB: Profile
    {
        public MappingDB()
        {
            CreateMap<Patient, PatientInfoVM>().ReverseMap();
            CreateMap<Patient, CreatePatientVM>().ReverseMap();
            CreateMap<Staff, StaffInfoVM>().ReverseMap();
            CreateMap<Staff, CreateStaffVM>().ReverseMap();
            CreateMap<Position, ListOfPositionsVM>().ReverseMap();
            CreateMap<Position, CreatePositionVM>().ReverseMap();
            CreateMap<MedicalRecord, MedicalHistoryVM>().ReverseMap();
            CreateMap<MedicalRecord, CreateMedicalRecordVM>().ReverseMap();
            CreateMap<Appointment, ListOfAppointmentVM>().ReverseMap();
            CreateMap<Appointment, CreateAppointmentVM>().ReverseMap();
        }
    }
}
