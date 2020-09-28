using MelhoresPraticasTp3.Domain.Rules.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelhoresPraticasTp3.Domain.Rules.Conditionals {
    public class AndNotSpecification<TModel> : CompositeSpecification<TModel> {
        private readonly ISpecification<TModel> _leftRule;
        private readonly ISpecification<TModel> _rightRule;

        public AndNotSpecification(ISpecification<TModel> leftRule, ISpecification<TModel> rightRule) {
            _leftRule = leftRule;
            _rightRule = rightRule;
        }

        public override bool IsSatisfiedBy(TModel model) {
            return _leftRule.IsSatisfiedBy(model) && !_rightRule.IsSatisfiedBy(model);
        }
    }
}