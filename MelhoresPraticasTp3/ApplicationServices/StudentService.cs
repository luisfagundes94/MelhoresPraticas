using MelhoresPraticasTp3.Domain.Enums;
using MelhoresPraticasTp3.Domain.Model;
using MelhoresPraticasTp3.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelhoresPraticasTp3.ApplicationServices {
    public class StudentService {

        private IStudentRepository StudentRepository { get; set; }

        public StudentService(IStudentRepository studentRepository) {
            this.StudentRepository = studentRepository;
        }

        public List<Student> ListStudents() {
            return StudentRepository.ListStudents();
        }

        public Status Delete(int id) {
            return StudentRepository.Delete(id);
        }

        public Student GetStudent(int id) {
            return StudentRepository.GetStudent(id);
        }
    }
}