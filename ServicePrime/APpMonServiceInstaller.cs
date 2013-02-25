using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Install;
using System.ComponentModel;

using System.ServiceProcess;


namespace ServicePrime
{
    [RunInstaller(true)]

    public class APpMonServiceInstaller : Installer
    {

        public APpMonServiceInstaller()
        {
            //initialize ServiceProcessInstaller();
            ServiceProcessInstaller _processInstaller = 
                new ServiceProcessInstaller();
            
            //initialize ServiceInstaller()
            ServiceInstaller _serviceInstaller = 
                new ServiceInstaller();
            
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
        

            //add ServiceInstaller and 
                  //ServiceProcessInstaller to the
                    //Installers Collection

            this.Installers.Add(_processInstaller);
            this.Installers.Add(_serviceInstaller);


        }

 
        

     
      
      

        


    }
}
