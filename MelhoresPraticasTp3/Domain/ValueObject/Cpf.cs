using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MelhoresPraticasTp3.Domain.ValueObject {
    public class Cpf {

        [DisplayName("CPF")]
        public string Value { get; set; }
        public string Formatted => FormattedValue(this.Value);

        public Cpf() {

        }

        public Cpf(string value) {
            this.Value = value?.Replace(".", "").Replace("-", "") ?? throw new ArgumentNullException(nameof(Cpf));
        }

        private string FormattedValue(string value) => Convert.ToInt64(value).ToString(@"000\.000\.000\-00");
    }
}