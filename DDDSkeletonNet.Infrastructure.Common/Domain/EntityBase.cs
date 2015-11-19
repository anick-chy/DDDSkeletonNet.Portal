using System;
using System.Collections.Generic;

namespace DDDSkeletonNet.Infrastructure.Common.Domain
{
    /// <summary>
    /// The base class for all domain entities
    /// </summary>
    /// <typeparam name="IdType">Type of id of business domain</typeparam>
    public abstract class EntityBase<IdType>
    {
        public IdType Id { get; set; }

        public override bool Equals(object entity)
        {
            return entity != null && entity is EntityBase<IdType> && this == (EntityBase<IdType>)entity;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<IdType> entity1, EntityBase<IdType> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
                return true;
            if ((object)entity1 == null || (object)entity2 == null)
                return false;
            if (entity1.Id.ToString() == entity2.Id.ToString())
                return true;
            return false;
        }

        public static bool operator !=(EntityBase<IdType> entity1, EntityBase<IdType> entity2)
        {
            return (!(entity1 == entity2));
        }

        /// <summary>
        /// Abstract method to be implemented to validate business rules of the domain
        /// </summary>
        protected abstract void Validate();

        /// <summary>
        /// Storage of the broken business rules
        /// </summary>
        private List<BusinessRule> _brokenRules = new List<BusinessRule>();

        /// <summary>
        /// Implementing entities will add broken rules through this method.
        /// </summary>
        /// <param name="businessRule">The business rules of domain itself</param>
        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }

        /// <summary>
        /// External code will collect broken rules calling this method
        /// </summary>
        /// <returns>A list of broken business rules.</returns>
        public IEnumerable<BusinessRule> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }
    }
}
