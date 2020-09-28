using System;
using System.Collections.Generic;
using System.Linq;
using MelhoresPraticasTp3.ApplicationServices;
using MelhoresPraticasTp3.Domain.Enums;
using MelhoresPraticasTp3.Domain.Model;
using MelhoresPraticasTp3.Domain.Repositories;
using MelhoresPraticasTp3.Domain.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MelhoresPraticasTesting {

    [TestClass]
    public class StudentUnitTesting {

        private StudentService StudentService { get; set; }
        private Mock<IStudentRepository> MockStudentRepository { get; set; }
        private List<Student> Students { get; set; }

        [TestInitialize]
        public void TearUp() {
            this.MockStudentRepository = new Mock<IStudentRepository>();
            this.StudentService = new StudentService(this.MockStudentRepository.Object);

            this.Students = new List<Student>() {
            new HighSchoolStudent() { Id = 1, Name = new Name("Luis", "Fagundes"), Cpf = new Cpf("16105960649"), Email = "luis@gmail.com", Archived = true },
            new PrimaryStudent() { Id = 2, Name = new Name("Julliana", "Assis"), Cpf = new Cpf("16105960649"), Email = "julliana@gmail.com", Archived = false },
            new PrimaryStudent() { Id = 3, Name = new Name("Isis", "Fagundes"), Cpf = new Cpf("16105960649"), Email = "isis@gmail.com", Archived = true },
            new PrimaryStudent() {Id = 4, Name = new Name("Rafael", "Corona"), Cpf = new Cpf("16105960649"), Email = "rafaelcorona", Archived = false}
            };
        }

        [TestMethod]
        public void CanAddStudentToRepository() {
            //Arrange
            Student student = new PrimaryStudent() { Id = 2, Name = new Name("Julliana", "Assis"), Cpf = new Cpf("16105960649"), Email = "julliana@gmail.com", Archived = false };
            this.MockStudentRepository.Setup(x => x.Save(student)).Returns(Status.SUCCESS);

            // Act
            var result = this.MockStudentRepository.Object.Save(student);

            // Assert
            this.MockStudentRepository.Verify(x => x.Save(student), Times.Once());
            Assert.AreEqual(result, Status.SUCCESS);
        }


        [TestMethod]
        public void CanReturnAllStudents() {
            // Arrange
            this.MockStudentRepository.Setup(x => x.ListStudents()).Returns(this.Students);

            // Act
            var students = this.StudentService.ListStudents();

            // Assert
            Assert.IsNotNull(students);
            Assert.AreEqual(4, students.Count);
        }

        [TestMethod]
        public void CanReturnStudentById() {
            // Arrange
            int studentId = 2;
            this.MockStudentRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns((int id) =>
                this.Students.Where(x => x.Id == id).Single());

            // Act
            var student = this.StudentService.GetStudent(studentId);

            // Assert
            Assert.IsNotNull(student);
            Assert.IsInstanceOfType(student, typeof(Student));
            Assert.AreEqual(studentId, student.Id);
        }
    }
}
