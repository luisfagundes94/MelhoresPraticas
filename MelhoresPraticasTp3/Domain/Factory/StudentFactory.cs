using MelhoresPraticasTp3.Domain.Model;
using MelhoresPraticasTp3.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelhoresPraticasTp3.Domain.Factory {
    public static class StudentFactory {

        public static Student Create(string type, int id, string name, string lastName, string cpf, string email) {
            switch(type) {
                case "High School":
                    return new HighSchoolStudent(id, CreateName(name, lastName), new Cpf(cpf), email);
                case "Primary":
                    return new PrimaryStudent(id, CreateName(name, lastName), new Cpf(cpf), email);
                default:
                    return new Student(id, CreateName(name, lastName), new Cpf(cpf), email, false);
            }
        }

        private static Name CreateName(string name, string lastName) {
            return new Name(name, lastName);
        }

    }
}