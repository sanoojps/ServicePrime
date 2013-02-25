 two functions are implimented 

 1) Install a service using InstallUtil.exe of .net 2.0
	public void _InstallServiceUsingInstallutil(string _serviceLocation)
 
 2) UnInstall a service using InstallUtil.exe of .net 2.0
	public void _UnInstallServiceUsingInstallutil(string _serviceLocation)


6:49 AM 2/25/2013
ToLookInto
----------

A command Prompt appears before the process is elevated using the
 "runas" verb of ProcessStartInfo

Could Be avoided by changing 

	<requestedExecutionLevel level="asInvoker" uiAccess="false" />
to
	<requestedExecutionLevel level="requireAdministrator" uiAccess="false" />
 in the manifest file  

url:http://msdn.microsoft.com/en-us/library/windows/desktop/bb756929.aspx
<requestedExecutionLevel
level="asInvoker|highestAvailable|requireAdministrator"
uiAccess="true|false"/>

To Impliment
------------

ErrorChecking to all Functions
 