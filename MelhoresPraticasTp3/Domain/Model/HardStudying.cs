using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelhoresPraticasTp3.Domain.Model {
    public class HardStudying : IStudyBehaviour {
        public string Study() {
            return "Studying hard!";
        }

    }
}