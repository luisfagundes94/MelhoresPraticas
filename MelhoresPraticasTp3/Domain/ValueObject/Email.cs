using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelhoresPraticasTp3.Domain.ValueObject {
    public class Email {
        public string Address { get; set; }

        public Email() { }

        public Email(string address) {
            if (!IsValidEmail(address)) {
                throw new Exception("Invalid Email Address");
            }
            this.Address = address;
        }

        private bool IsValidEmail(string email) {
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            } catch {
                return false;
            }
        }
    }
}