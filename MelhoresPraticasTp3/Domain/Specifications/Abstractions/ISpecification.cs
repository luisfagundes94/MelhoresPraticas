using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelhoresPraticasTp3.Domain.Rules.Abstractions {
    public interface ISpecification<in TModel> {
        bool IsSatisfiedBy(TModel model);
    }
}