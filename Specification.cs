using System;
using System.Collections.Generic;
using System.Text;

namespace SpecificationPattern
{
    public abstract class Specification<T>
    {
        public abstract bool IsSatisfiedBy(T data, ref List<string> errors);
        public Specification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }
    }

    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> left;
        private readonly Specification<T> right;

        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override bool IsSatisfiedBy(T data, ref List<string> errors)
        {
            var result = this.left.IsSatisfiedBy(data, ref errors) && this.right.IsSatisfiedBy(data, ref errors);
            return result;
        }
    }


}