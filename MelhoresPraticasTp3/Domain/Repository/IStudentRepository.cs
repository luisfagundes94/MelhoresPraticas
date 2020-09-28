using MelhoresPraticasTp3.Domain.Enums;
using MelhoresPraticasTp3.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelhoresPraticasTp3.Domain.Repositories {
    public interface IStudentRepository {

        List<Student> ListStudents();
        Status Save(Student student);
        Status Delete(int id);
        Status Update(int id, Student student);
        Student GetStudent(int id);
    }
}
