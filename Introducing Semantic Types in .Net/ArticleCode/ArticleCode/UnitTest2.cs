using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArticleCode
{
    public class SemanticType<T> : IEquatable<SemanticType<T>>
    {
        public T Value { get; private set; }

        protected SemanticType(Func<T, bool> isValidLambda, T value)
        {
            if ((Object)value == null)
            {
                throw new ArgumentException(string.Format("Trying to use null as the value of a {0}", this.GetType()));
            }

            if ((isValidLambda != null) && !isValidLambda(value))
            {
                throw new ArgumentException(string.Format("Trying to set a {0} to {1} which is invalid", this.GetType(), value));
            }

            Value = value;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types. 
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            return (Value.Equals(((SemanticType<T>)obj).Value));
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(SemanticType<T> other)
        {
            if (other == null) { return false; }

            return (Value.Equals(other.Value));
        }

        public static bool operator ==(SemanticType<T> a, SemanticType<T> b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            // Have to cast to object, otherwise you recursively call this == operator.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.Equals(b);
        }

        public static bool operator !=(SemanticType<T> a, SemanticType<T> b)
        {
            return !(a == b);
        }
    }
    
    
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}

namespace ArticleCode2
{
    public class SemanticType<T> : IEquatable<SemanticType<T>>
    {
        public T Value { get; private set; }

        protected SemanticType(Func<T, bool> isValidLambda, T value)
        {
            if ((Object)value == null)
            {
                throw new ArgumentException(string.Format("Trying to use null as the value of a {0}", this.GetType()));
            }

            if ((isValidLambda != null) && !isValidLambda(value))
            {
                throw new ArgumentException(string.Format("Trying to set a {0} to {1} which is invalid", this.GetType(), value));
            }

            Value = value;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types. 
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            return (Value.Equals(((SemanticType<T>)obj).Value));
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(SemanticType<T> other)
        {
            if (other == null) { return false; }

            return (Value.Equals(other.Value));
        }
    }
}

namespace ArticleCode3
{
    public class SemanticType<T>
    {
        public T Value { get; private set; }

        protected SemanticType(Func<T, bool> isValidLambda, T value)
        {
            if ((Object)value == null)
            {
                throw new ArgumentException(string.Format("Trying to use null as the value of a {0}", this.GetType()));
            }

            if ((isValidLambda != null) && !isValidLambda(value))
            {
                throw new ArgumentException(string.Format("Trying to set a {0} to {1} which is invalid", this.GetType(), value));
            }

            Value = value;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types. 
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            return (Value.Equals(((SemanticType<T>)obj).Value));
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}


namespace ArticleCode4
{
    public class SemanticType<T>
    {
        public T Value { get; private set; }

        protected SemanticType(Func<T, bool> isValidLambda, T value)
        {
            if ((Object)value == null)
            {
                throw new ArgumentException(string.Format("Trying to use null as the value of a {0}", this.GetType()));
            }

            if ((isValidLambda != null) && !isValidLambda(value))
            {
                throw new ArgumentException(string.Format("Trying to set a {0} to {1} which is invalid", this.GetType(), value));
            }

            Value = value;
        }
    }
}


namespace ArticleCode5
{
}



