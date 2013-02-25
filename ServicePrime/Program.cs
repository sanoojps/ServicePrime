using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;

namespace ServicePrime
{
    class Program : ServiceBase
    {
        static void Main(string[] args)
        {
            ServiceBase.Run(new Program());
        }

        //constructor

        public Program()
        {
            this.ServiceName = "APpMon";
          
        }


        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

    }
}
