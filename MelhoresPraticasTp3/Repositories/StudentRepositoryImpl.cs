using MelhoresPraticasTp3.Domain.Enums;
using MelhoresPraticasTp3.Domain.Model;
using MelhoresPraticasTp3.Domain.Repositories;
using MelhoresPraticasTp3.Domain.Rules.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelhoresPraticasTp3.Repositories {
    public class StudentRepositoryImpl : IStudentRepository {

        private static List<Student> Students = new List<Student>() {
            new HighSchoolStudent() { Id = 1, Name = new Domain.ValueObject.Name("Luis", "Fagundes"), Cpf = new Domain.ValueObject.Cpf("16105960649"), Email = "luis@gmail.com", Archived = true },
            new PrimaryStudent() { Id = 2, Name = new Domain.ValueObject.Name("Julliana", "Assis"), Cpf = new Domain.ValueObject.Cpf("16105960649"), Email = "julliana@gmail.com", Archived = false },
            new PrimaryStudent() { Id = 3, Name = new Domain.ValueObject.Name("Isis", "Fagundes"), Cpf = new Domain.ValueObject.Cpf("16105960649"), Email = "isis@gmail.com", Archived = true },
            new PrimaryStudent() {Id = 4, Name = new Domain.ValueObject.Name("Rafael", "Corona"), Cpf = new Domain.ValueObject.Cpf("16105960649"), Email = "rafaelcorona", Archived = false}
            };

        public List<Student> ListStudents() {
            return Students;
        }

        public IReadOnlyList<Student> GetStudentsByRule(ISpecification<Student> studentRule) {
            return Students.Where(studentRule.IsSatisfiedBy).ToList();
        }

        public Status Delete(int id) {
            try {
                foreach (Student student in Students) {
                    if (student.Id == id) {
                        Students.Remove(student);
                        break;
                    }
                };
                return Status.SUCCESS;
            } catch (ArgumentOutOfRangeException exception) {
                return Status.ERROR;
            }
        }

        public Student GetStudent(int id) {
            try {
                return Students.Find(student => student.Id == id);
            } catch {
                return null;
            }
            
        }

        public Status Save(Student student) {
            try {
                Students.Add(student);
                return Status.SUCCESS;
            } catch {
                return Status.ERROR;
            }
        }

        public Status Update(int id, Student updatedStudent) {

            try {
                foreach (Student student in Students) {
                    if (student.Id == id) {
                        student.Name = updatedStudent.Name;
                        student.Cpf = updatedStudent.Cpf;
                        student.Email = updatedStudent.Email;
                    }
                };
                return Status.SUCCESS;
            } catch {
                return Status.ERROR;
            }
        }
    }
}