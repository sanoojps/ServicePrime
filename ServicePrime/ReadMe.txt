Creating A Service

url:http://tech.pro/tutorial/895/creating-a-simple-windows-service-in-csharp
8:38 AM 2/24/2013

Step 1) Create a Console App

filename:Program.cs

using System;
using System.Collections.Generic;
using System.Text;

namespace ServicePrime
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

Step 2) In order to build services, 
        we depend on some .NET objects location in the 
	    System.ServiceProcess and 
	    System.Configuration.Install assemblies. 
	    Go ahead and add those references to your project.
		Solutions Explorer > References > Add Reference > 

Step 3) The only thing we need to do in order to make this class into a 
        service is make Program extend 
		System.ServiceProcess.ServiceBase.

		Add 'using directive to import System.ServiceProcess 
		>> using System.ServiceProcess;

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
        }
    }
}

Step 4) At a minimum, every service should override 
        OnStart 
		
		  protected override void OnStart(string[] args)
        {
            base.OnStart(args);
			//TODO: place your start code here
        }

		and 
		OnStop

		protected override void OnStop()
        {
            base.OnStop();
			//TODO: clean up any variables and stop any threads
        }
		
		that we can override


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
        }


        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
			//TODO: place your start code here
        }

        protected override void OnStop()
        {
            base.OnStop();
			//TODO: clean up any variables and stop any threads
        }

    }
}


Step 5) add some information about our service - like a name.
        Let's add a constructor.

		 public Program()
        {
            this.ServiceName = "APpMon";
          
        }


Step 6) tell Windows what service to run when your application it executed. 
        Just like normal applications, execution begins in the Main function. 
		This is where we'll 
		create an instance of our service and tell it to run.

		static void Main(string[] args)
        {
            ServiceBase.Run(new Program());
        }

		That's it! The service implementation is complete.


Step 7) implementing an installer.
        -------------------------
		filename : APpMonServiceInstaller.cs

		add another (public) class to our project called 
		APpMonServiceInstaller.
		(Then Visual Studio creates a class for you, 
		it doesn't automatically make it public. 
		It's very important that this class be made public.
		When you install a service, the installer will look through your 
		assembly for public classes with a specific attribute. 
		If it's not public, it won't find it.)

		filename:APpMonServiceInstaller.cs

		using System;
        using System.Collections.Generic;
        using System.Text;

		namespace ServicePrime
		{
		public class APpMonServiceInstaller
		{
		}
		}

Step 8) This class needs to extend 
		System.Configuration.Install.Installer
		
		using System.Configuration.Install;
		using System.ComponentModel;
		 
		and be given a 
		RunInstaller attribute.
		 
		 [RunInstaller(true)]
		  
		This is the attribute that the service installer looks 
		for when installing your service.

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Install;
using System.ComponentModel;

namespace ServicePrime
{
    [RunInstaller(true)]

    public class APpMonServiceInstaller : Installer
    {
        

    }
}


Step 9) Configuring the service
        -----------------------
		step a )//create  Constructor
		public APpMonServiceInstaller()
        {
        }	

		step b)//initialize ServiceProcessInstaller();
		       Installs an executable containing classes that 
			   extend ServiceBase. 
			   This class is called by installation utilities, 
			   such as InstallUtil.exe, 
			   when installing a service application.

		using System.ServiceProcess;
        ServiceProcessInstaller _processInstaller =
            new ServiceProcessInstaller();

       step c)// //initialize ServiceInstaller();
				Installs a class that extends ServiceBase 
				to implement a service.
				This class is called by the install utility when 
				installing a service application.	

        ServiceInstaller _serviceInstaller =
            new ServiceInstaller();

	    step d)//Configuring the Service

		//Service Name
            //must be the same as what was set in Program's constructor
            _serviceInstaller.ServiceName = "APpMon";

            //Service description
            _serviceInstaller.Description = 
                "This service shows popup NotificationStatus";

            //Service StartType
            _serviceInstaller.StartType =
                ServiceStartMode.Manual;

            //Service Display Name
            _serviceInstaller.DisplayName = 
                "App Monitoring";


			 //set the privileges
            _processInstaller.Account =
                ServiceAccount.LocalSystem;


		step e)  //add ServiceInstaller and 
                  //ServiceProcessInstaller to the
                    //Installers Collection

            this.Installers.Add(_processInstaller);
            this.Installers.Add(_serviceInstaller);				
	    









		

		


		
		 

