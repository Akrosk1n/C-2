using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    public class Hospital
    {
        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; }
        public List<HospitalRoom> Rooms { get; set; }
        public List<MedicalRecord> Records { get; set; }

        public Hospital()
        {
            Doctors = new List<Doctor>();
            Patients = new List<Patient>();
            Rooms = new List<HospitalRoom>();
            Records = new List<MedicalRecord>();
        }

        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor);
            Console.WriteLine($"Лікар {doctor.Name} ({doctor.Specialization}) доданий до системи");
        }

        public void RegisterPatient(Patient patient)
        {
            Patients.Add(patient);
            Console.WriteLine($"Пацієнт {patient.Name}, {patient.Age} років, зареєстрований");
        }

        public void CreateRoom(HospitalRoom room)
        {
            Rooms.Add(room);
            Console.WriteLine($"Палата №{room.RoomNumber} створена (місткість: {room.Capacity})");
        }

        public void HospitalizePatient(int patientId, int roomNumber)
        {
            var patient = Patients.FirstOrDefault(p => p.Id == patientId);
            var room = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (patient == null)
            {
                Console.WriteLine($"Пацієнт з ID {patientId} не знайдений!");
                return;
            }

            if (room == null)
            {
                Console.WriteLine($"Палата {roomNumber} не знайдена!");
                return;
            }
            room.AddPatient(patient);
        }

        public void AddMedicalRecord(MedicalRecord record)
        {
            Records.Add(record);
            Console.WriteLine($"Медичний запис створено: {record.Patient.Name} -> {record.Doctor.Name}");
        }

        public List<MedicalRecord> GetPatientHistory(int patientId)
        {
            return Records.Where(r => r.Patient.Id == patientId).ToList();
        }

        public string GetStatistics()
        {
            int totalPatientsInRooms = Rooms.Sum(r => r.Patients.Count);

            return 
                $@" === СТАТИСТИКА ЛІКАРНІ ===
                Кількість лікарів: {Doctors.Count}
                Кількість зареєстрованих пацієнтів: {Patients.Count}
                Кількість палат: {Rooms.Count}
                Кількість пацієнтів у палатах: {totalPatientsInRooms}
                Кількість медичних записів: {Records.Count}";
        }

    }
}