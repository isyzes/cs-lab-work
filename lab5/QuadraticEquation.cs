using System;

namespace cs_lab_work.lab5
{
    public class QuadraticEquation {
        private int a;
        private int b;
        private int c;

        public int A
        {
            get => a;
            set
            {
                if (value == 0) throw new ArgumentException("Коэффициент 'a' не может быть 0.");
                a = value;
            }
        }

        public int B
        {
            get => b;
            set => b = value;
        }

        public int C
        {
            get => c;
            set => c = value;
        }

        public int this[int index]
        {
            get => index switch
            {
                0 => A,
                1 => B,
                2 => C,
                _ => throw new IndexOutOfRangeException("Допустимые индексы: 0 (a), 1 (b), 2 (c)")
            };
            set
            {
                switch (index)
                {
                    case 0: A = value; break;
                    case 1: B = value; break;
                    case 2: C = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        public QuadraticEquation(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public QuadraticEquation() : this(1, 0, 0) { }

        public (double? x1, double? x2) FindRoots()
        {
            double d = B * B - 4 * A * C;
            if (d < 0) return (null, null);
            if (d == 0)
            {
                double x = -B / (2.0 * A);
                return (x, x);
            }
            double sqrtD = Math.Sqrt(d);
            return (
                (-B + sqrtD) / (2 * A),
                (-B - sqrtD) / (2 * A)
            );
        }

        public override string ToString()
        {
            return $"{A}x² + {B}x + {C} = 0";
        }

        public static QuadraticEquation operator +(QuadraticEquation eq, int n)
            => new(eq.A + n, eq.B + n, eq.C + n);

        public static QuadraticEquation operator -(QuadraticEquation eq, int n)
            => new(eq.A - n, eq.B - n, eq.C - n);

        public static QuadraticEquation operator *(QuadraticEquation eq, int n)
            => new(eq.A * n, eq.B * n, eq.C * n);

        public static QuadraticEquation operator /(QuadraticEquation eq, int n)
        {
            if (n == 0) throw new DivideByZeroException();
            return new(eq.A / n, eq.B / n, eq.C / n);
        }

        public static QuadraticEquation operator ++(QuadraticEquation eq)
            => new(eq.A + 1, eq.B + 1, eq.C + 1);

        public static QuadraticEquation operator --(QuadraticEquation eq)
            => new(eq.A - 1, eq.B - 1, eq.C - 1);

        public static bool operator ==(QuadraticEquation q1, QuadraticEquation q2)
            => q1.A == q2.A && q1.B == q2.B && q1.C == q2.C;

        public static bool operator !=(QuadraticEquation q1, QuadraticEquation q2)
            => !(q1 == q2);

        public static bool operator <(QuadraticEquation q1, QuadraticEquation q2)
            => q1.Discriminant() < q2.Discriminant();

        public static bool operator >(QuadraticEquation q1, QuadraticEquation q2)
            => q1.Discriminant() > q2.Discriminant();

        public override bool Equals(object obj)
            => obj is QuadraticEquation q && this == q;

        public override int GetHashCode()
            => HashCode.Combine(A, B, C);

        private double Discriminant() => B * B - 4 * A * C;

        public static bool operator true(QuadraticEquation eq)
            => eq.FindRoots().x1.HasValue;

        public static bool operator false(QuadraticEquation eq)
            => !eq.FindRoots().x1.HasValue;

        public static explicit operator QuadraticEquation(int a)
            => new(a, 0, 0);

        public static explicit operator int(QuadraticEquation eq)
            => eq.A;
    }
}

