using MelhoresPraticasTp3.Domain.Model;
using MelhoresPraticasTp3.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MelhoresPraticasTp3.Domain.Model {
    public class Student {
        [DisplayName("Tipo do Aluno")]
        public String Type { get; set; }
        public int Id { get; set; }
        public Name Name { get; set; }
        public Cpf Cpf { get; set; }
        public String Email { get; set; }

        public bool Archived { get; set; }

        public IStudyBehaviour StudyBehaviour { get; set; }

        public String Study() {
            return StudyBehaviour.Study();
        }

        internal Student() { }

        internal Student(Name name, Cpf cpf, String email, bool archived) {
            this.Name = name;
            this.Cpf = cpf;
            this.Email = email;
            this.Archived = archived;
        }

        internal Student(int id, Name name, Cpf cpf, String email, bool archived) {
            this.Id = id;
            this.Name = name;
            this.Cpf = cpf;
            this.Email = email;
            this.Archived = archived;
        }


    }


}