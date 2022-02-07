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
        int n = 2;  // number of states
        private double[] x;      // array of states
        private double[] f;      // right side of the equation evaulated
        //--------------------------------------------------------------------
        // contrustor
        //--------------------------------------------------------------------
        public SimplePend() 
        {
            x = new double[n];  // We tell the contructor how big the arrow is.
            f = new double[n];  // we tell the constructor how big the array is.
            
            x[0] = 1.0; // tell it the intial condition of the  pendulum
            x[1] = 0.0; // intial start of the acceleration
        } 
         
        //--------------------------------------------------------------------
        // step perform one integration step via Euler's Method 
        //   Soon, it will implement RK4
        //--------------------------------------------------------------------
        public  void step(double dt) 
        {
          rhsFunc(x,f);
        
          for(int i=0;i<n;++i)
          {
            x[i] = x[i] + f[i] * dt;
          }
          
        }
        //--------------------------------------------------------------------
        // rhsFunc: function to calculate right hand side of pendulum ODE'S
        //--------------------------------------------------------------------
        public void rhsFunc(double[] st, double[] ff)
        {
         
         ff[0] = st[1]; // theta dot which is state one 
         ff[1] = -g/Len * Math.Sin(st[0]); 

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

       public double theta
       {
         get { return x[0];}

         set{x[0] = value;}
       }

        public double thetaDot
       {
         get{return x[1];}

         set{x[1] = value;}
       }
    }

    
}
