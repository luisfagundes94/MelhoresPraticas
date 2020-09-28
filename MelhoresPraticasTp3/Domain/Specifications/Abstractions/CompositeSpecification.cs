using MelhoresPraticasTp3.Domain.Rules.Conditionals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelhoresPraticasTp3.Domain.Rules.Abstractions {
    public abstract class CompositeSpecification<TModel> : ISpecification<TModel> {
        public abstract bool IsSatisfiedBy(TModel model);

        public CompositeSpecification<TModel> And(ISpecification<TModel> andRule) {
            return new AndSpecification<TModel>(this, andRule);
        }

        public CompositeSpecification<TModel> AndNot(ISpecification<TModel> andRule) {
            return new AndNotSpecification<TModel>(this, andRule);
        }
    }
}
