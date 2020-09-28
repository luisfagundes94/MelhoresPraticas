using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelhoresPraticasTp3.Domain.Model {
    public class PrimaryStudent : Student {
        public PrimaryStudent() {
            InitPrimaryStudentBehaviour();
        }

        public PrimaryStudent(int id, ValueObject.Name name, ValueObject.Cpf cpf, String email) {
            Id = id;
            Name = name;
            Cpf = cpf;
            Email = email;
            InitPrimaryStudentBehaviour();
        }

        private void InitPrimaryStudentBehaviour() {
            StudyBehaviour = new StudyLightBehaviour();
            Type = "Primary Student";
        }
    }
}