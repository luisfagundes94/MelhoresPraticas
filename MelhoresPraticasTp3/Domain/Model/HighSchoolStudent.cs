using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelhoresPraticasTp3.Domain.Model {
    public class HighSchoolStudent : Student {
        public HighSchoolStudent() {
            InitBehaviour();
        }

        public HighSchoolStudent(int id, ValueObject.Name name, ValueObject.Cpf cpf, String email) {
            Id = id;
            Name = name;
            Cpf = cpf; ;
            Email = email;
            InitBehaviour();
    }

        private void InitBehaviour() {
            StudyBehaviour = new HardStudying();
            Type = "High School Student";
        }
}
}