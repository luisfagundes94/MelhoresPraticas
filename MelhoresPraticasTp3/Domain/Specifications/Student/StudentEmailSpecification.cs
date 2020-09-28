using MelhoresPraticasTp3.Domain.Rules.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelhoresPraticasTp3.Domain.Rules.Student {
    public class StudentEmailSpecification : CompositeSpecification<Domain.Model.Student> {
        public override bool IsSatisfiedBy(Domain.Model.Student model) {
            return model?.Email?.Contains("@") == true;
        }
    }
}