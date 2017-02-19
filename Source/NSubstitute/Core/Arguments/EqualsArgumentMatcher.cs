using System.Collections.Generic;

namespace NSubstitute.Core.Arguments
{
    public class EqualsArgumentMatcher<T> : IArgumentMatcher
    {
        private static readonly IArgumentFormatter DefaultArgumentFormatter = new ArgumentFormatter();

        private readonly T _value;
        private readonly IEqualityComparer<T> _comparer;

        public EqualsArgumentMatcher(T value)
            : this(value, EqualityComparer<T>.Default)
        {
        }

        public EqualsArgumentMatcher(T value, IEqualityComparer<T> comparer)
        {
            _value = value;
            _comparer = comparer;
        }

        public override string ToString()
        {
            return DefaultArgumentFormatter.Format(_value, false);
        }

        public bool IsSatisfiedBy(object argument)
        {
	        return _comparer.Equals(_value, (T) argument);
        }
    }
}