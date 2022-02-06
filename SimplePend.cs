//============================================================================
// simplePend.cs defines a class for simulating a Simple Pendulum
//============================================================================
using System;

namespace sim
{
    public class SimplePend
    {
        private double Len = 1.1; // pendulum lenght
        private double g = 9.81; // gravitational field strenght

        //--------------------------------------------------------------------
        // contrustor
        //--------------------------------------------------------------------
        public SimplePend() 
        {
            Console.WriteLine("inside Constructor");
        } 


        //--------------------------------------------------------------------
        // Getters And Setters
        //--------------------------------------------------------------------
 
          public double L
          {

                get{return(Len);}

                set
                {
                    if(value > 0.0)
                    Len = value;
                }

          }
            public double G
          {

            get {return(g);}

            set
            {
                if (value >= 0.0)
                    g = value;
            }

          }

    }
    
}
