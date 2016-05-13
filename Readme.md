# IOCUnityImplementation
Sample code of IOC using Unity implementing Dependency Injection Factory


##Self-Hosted WCF Notes:(windows service project)
- the service is configured to listen over SSL at port:9999 and should be bound to an SSL certificate. To bind it use the following netsh command below for Windows 7 and up.
- to install use installutil for installing windows service. Make sure you added a project installer before proceeding with installutil

##Self-Hosted WCF Using TopShelf Notes:(Console application)
- the service is configured to listen over SSL at port:9990 and should be bound to an SSL certificate. To bind it use the following netsh command below for Windows 7 and up.
- to install just execute the binary and pass install as parameter in windows command console(i.e. C:\ SelfHostedHRMSService install)
- to uninstall just execute the binary and pass ininstall as parameter in windows command console(i.e. C:\ SelfHostedHRMSService uninstall)

netsh http add sslcert ipport=0.0.0.0:9999   
		certhash=da26b6b8c9f4c4c455e1e8cebde1cdb57e7871ff  
		appid={00112233-4455-6677-8899-AABBCCDDEEFF}   
		clientcertnegotiation=enable  

###Parameters:  
ipport = IP address and Port to bind to.  
certhash = certificate thumbprint  
appid = GUID value that will own this binding.  