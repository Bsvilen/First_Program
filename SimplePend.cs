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
        // RK4 method 

        private double dydx(double x, double y)
        {
          return ((x-y)/2);
        }
        private double RK4Method( double x0, double y0, double x, double h)
        {

          int n = (int)((x-x0)/h); // number of itterations
          double yi = y0;

          double[] y = new double[n];  // New estimates
          double[] t = new double[n]; // time index for each cycle

          t[0] = 0.0;
          y[0] = 0.5;



          // four different states
          double k1;
          double k2;
          double k3;
          double k4;


        // calculation for the loop

        for(int i= 1;i <=n; i++ )
        {
            // calculation for each K value 
            k1 = h*(dydx(x0, yi));
            k2 = h*(dydx(x0 + 0.5*h,yi+0.5*k1));
            k3 = h*(dydx(x0 + 0.5*h,yi+0.5*k2));
            k4 = h*(dydx(x0 + 0.5*h,yi+0.5*k3));


            y[i] = yi;

            // update the value 

            yi += (1.0/6.0)*(k1+2*k2+2*k3+k4); // updates the value of y everytime

            x = x0 + h;   //update the next value of the x
        }
        return yi;


        }
        
        
        // Euler method
        public void step(double dt) 
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
