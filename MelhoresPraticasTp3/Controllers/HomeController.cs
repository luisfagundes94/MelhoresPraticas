using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MelhoresPraticasTp3.Domain.Factory;
using MelhoresPraticasTp3.Domain.Model;
using MelhoresPraticasTp3.Domain.Rules.Student;
using MelhoresPraticasTp3.Domain.Specifications.Student;
using MelhoresPraticasTp3.Domain.ValueObject;
using MelhoresPraticasTp3.Repositories;

namespace MelhoresPraticasTp3.Controllers {
    public class HomeController : Controller {

        StudentRepositoryImpl StudentRepository = new StudentRepositoryImpl();
        static int counter = 5;
        public ActionResult Index() {

            var studentQuery = new StudentEmailSpecification();

            return View(StudentRepository.GetStudentsByRule(studentQuery).ToList());
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
               
                var studentType = collection["Type"];
                var student = StudentFactory.Create(
                    studentType,
                    counter,
                    collection["Name.First"],
                    collection["Name.Last"],
                    collection["Cpf.Value"],
                    collection["Email"]
                    );

                StudentRepository.Save(student);
                counter++;

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        public ActionResult Delete(int id) {
            return View(StudentRepository.GetStudent(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                StudentRepository.Delete(id);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        public ActionResult Edit(int id) {
            return View(StudentRepository.GetStudent(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                Student student = new Student();
                var studentFirstName = collection["Name.First"];
                var studentLastName = collection["Name.Last"];
                student.Name = new Name(studentFirstName, studentLastName);
                student.Cpf = new Cpf(collection["Cpf.Value"]);
                student.Email = collection["Email"];

                StudentRepository.Update(id, student);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        public ActionResult Details(int id) {
            return View(StudentRepository.GetStudent(id));
        }
    }
}