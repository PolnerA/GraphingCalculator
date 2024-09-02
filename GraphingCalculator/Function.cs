using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphingCalculator
{
    public class Function
    {//acts as a tree, recursively has smaller functions within it, useful for user input
        public Function left;
        public Function right;
        //left and right sides to the function help evaluate the two arguments a function has

        //sine and cosine aren't operations as they only take one argument, so they act like wrappers for the function
        //if a number or op has a sine in it, it takes what it would return and returns the sine or cosine of it instead
        bool Sine = false;
        bool Cosine = false;
        public void SetSine()
        {
            Sine=true;
        }
        public void SetCosine()
        {
            Cosine=true;
        }
        //check trig is called after every functions return to check if you need to return a trig value of the value
        //you would be returning
        public double CheckTrig(double toReturn)
        {
            if (Sine)
            {
                return Math.Sin(toReturn);
            }
            if (Cosine)
            {
                return Math.Cos(toReturn);
            }
            return toReturn;
        }
        //equals check if each of the classes check out recursively
        //helps distinguish the equality of two trees, useful if I want to continue this project
        //copy and pasted from java find equivalence for .getClass equals isn't a thing yet
        /*
        */
        //Perform operation performs the operations recursively throughout the tree to get a result
        //Perform operation in the Function class isn't actually used for anything only for overrides
        //so the method below would just recurse infinitely as if you access it you did something wrong.
        public virtual double PerformOperation(double input)
        {
            if (left!=null)
            {
                double l = left.PerformOperation(input);
            }
            if (right!=null)
            {
                double r = right.PerformOperation(input);
            }
            return PerformOperation(input);
        }
    }
    public class Operation : Function
    {//empty class used to distinguish inheritance relationships between
     //an operator and a number
        public override double PerformOperation(double input)
        {//if you inherit from operation you override this with the given op.
            return 0.0;
        }
    }
    public class Add : Operation
    {
        //returns the addition of the left and right values
        //     +
        //    / \    would return 15
        //   5  10
        public override double PerformOperation(double input)
        {
            return CheckTrig(left.PerformOperation(input) + right.PerformOperation(input));
        }
    }
    public class Sub : Operation
    {
        //returns the subtraction of the left and right values
        //     -
        //    / \    would return -5
        //   5  10
        public override double PerformOperation(double input)
        {
            return CheckTrig(left.PerformOperation(input)-right.PerformOperation(input));
        }
    }
    public class Mult : Operation
    {
        //returns the multiplication of the left and right values
        //     *
        //    / \    would return 50
        //   5  10
        public override double PerformOperation(double input)
        {
            return CheckTrig(left.PerformOperation(input)*right.PerformOperation(input));
        }
    }
    public class Div : Operation
    {
        //returns the division of the left and right values
        //     /
        //    / \    would return 0.5
        //   5  10
        public override double PerformOperation(double input)
        {
            return CheckTrig(left.PerformOperation(input)/right.PerformOperation(input));
        }
    }
    public class Exp : Operation
    {
        //returns the exponentiation of the left and right values
        //     ^
        //    / \    would return 9,765,625
        //   5  10
        public override double PerformOperation(double input)
        {
            double numright = right.PerformOperation(input);
            return CheckTrig(Math.Pow(left.PerformOperation(input), numright));
        }
    }
    public class Number : Function
    {
        //number class has a number that it returns if it is asked to,
        //or it returns double input if it is an entrance (x, variable for whatever input is placed in)
        //numbers value if constant
        double number;
        //boolean entrance to indicate x in the tree
        bool entrance = false;

        //if you construct a number with a value it keeps that value
        public Number(double a)
        {
            number=a;
        }
        //if it is a variable it is flagged to return the input instead of the value of nothing to make a variable
        //is a blank Number()
        public Number()
        {
            entrance=true;
        }
        //if it is x it returns the input, otherwise it returns the number
        public override double PerformOperation(double input)
        {
            if (entrance) { return CheckTrig(input); }
            return CheckTrig(number);
        }
    }
    class Function
    {
        public Function()
        {
        }
    }
}