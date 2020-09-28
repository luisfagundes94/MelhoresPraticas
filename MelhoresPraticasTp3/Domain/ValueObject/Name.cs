using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MelhoresPraticasTp3.Domain.ValueObject {
    public class Name {
        [DisplayName("Nome")]
        public String First { get; set; }

        [DisplayName("Sobrenome")]
        public String Last { get; set; }

        public Name(String first, String last) {
            if (String.IsNullOrEmpty(first)) throw new Exception("Invalid First Name");
            if (String.IsNullOrEmpty(last)) throw new Exception("Invalid Last Name");

            First = first;
            Last = last;
        }
    }
}