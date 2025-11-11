using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    public class HospitalDemo
    {
        public void Run()
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===\n");

            Hospital hospital = new Hospital();

            Doctor d1 = new Doctor(1, "Трошкін Роман", "Невропотолог");
            Doctor d2 = new Doctor(2, "Хроненко Денис", "Окуліст");
            Doctor d3 = new Doctor(3, "Школяренко Олександр", "Кардіолог");

            hospital.AddDoctor(d1);
            hospital.AddDoctor(d2);
            hospital.AddDoctor(d3);

            Patient p1 = new Patient(1, "Тараканов Родіон", 19);
            Patient p2 = new Patient(2, "Прокопенко Кірил", 18);
            Patient p3 = new Patient(3, "Дмитро Тисячний", 17);
          
            hospital.RegisterPatient(p1);
            hospital.RegisterPatient(p2);
            hospital.RegisterPatient(p3);
          
            HospitalRoom r1 = new HospitalRoom(10, 2);
            HospitalRoom r2 = new HospitalRoom(11, 2);
            HospitalRoom r3 = new HospitalRoom(12, 1);

            hospital.CreateRoom(r1);
            hospital.CreateRoom(r2);
            hospital.CreateRoom(r3);

            hospital.HospitalizePatient(1, 10);
            hospital.HospitalizePatient(2, 11);
            hospital.HospitalizePatient(3, 11);
            hospital.HospitalizePatient(4, 12); // нема такого пацієнта

            MedicalRecord m1 = new MedicalRecord(p1, d1, DateTime.Now, "Проблеми з очима");
            MedicalRecord m2 = new MedicalRecord(p1, d2, DateTime.Now, "Застуда у дитини");
            MedicalRecord m3 = new MedicalRecord(p1, d3, DateTime.Now, "Обстеження серця");

            hospital.AddMedicalRecord(m1);
            hospital.AddMedicalRecord(m2);
            hospital.AddMedicalRecord(m3);

            Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА ---");
            var history = hospital.GetPatientHistory(1);
            foreach (var record in history)
            {
                Console.WriteLine($"  Дата: {record.Date.ToShortDateString()}");
                Console.WriteLine($"  Лікар: {record.Doctor.Name}");
                Console.WriteLine($"  Опис: {record.Description}\n");
            }
            Console.WriteLine(hospital.GetStatistics());
        }

    }
}

