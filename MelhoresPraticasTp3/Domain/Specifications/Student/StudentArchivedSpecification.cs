using MelhoresPraticasTp3.Domain.Rules.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelhoresPraticasTp3.Domain.Specifications.Student {
    public class StudentArchivedSpecification : CompositeSpecification<Model.Student> {
        public override bool IsSatisfiedBy(Model.Student model) {
            return model?.Archived == true;
        }
    }
}