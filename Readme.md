# IOCUnityImplementation
Sample code of IOC using Unity implementing Dependency Injection Factory

##Self-Hosted WCF Notes:
- the service is configured to listen over SSL at port:9999 and should be bound to an SSL certificate. To bind it use the following command below for Windows 7 and up.

netsh http add sslcert ipport=0.0.0.0:9999   
		certhash=da26b6b8c9f4c4c455e1e8cebde1cdb57e7871ff  
		appid={00112233-4455-6677-8899-AABBCCDDEEFF}   
		clientcertnegotiation=enable  
Parameters:  
ipport = IP address and Port to bind to.  
certhash = certificate thumbprint  
appid = GUID value that will own this binding.  