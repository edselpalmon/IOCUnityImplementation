using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    
    public class ForceAnonymousEndpointBehavior : BehaviorExtensionElement, IDispatchMessageInspector, IEndpointBehavior
    {
        public override Type BehaviorType
        {
            get { return typeof(ForceAnonymousEndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new ForceAnonymousEndpointBehavior();
        }

        object IDispatchMessageInspector.AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            //HttpContext.Current.User = Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("", ""), null);
            return null;
        }

        void IDispatchMessageInspector.BeforeSendReply(ref Message reply, object correlationState)
        {

        }

        void IEndpointBehavior.ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            var requiredHeaders = new Dictionary<string, string>();

            requiredHeaders.Add("Access-Control-Allow-Origin", "*");
            requiredHeaders.Add("Access-Control-Request-Method", "POST,GET,PUT,DELETE,OPTIONS");
            requiredHeaders.Add("Access-Control-Allow-Headers", "X-Requested-With, Content-Type, Authorization");

            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new ForceAnonymousEndpointBehavior());
        }

        void IEndpointBehavior.AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {

        }

        void IEndpointBehavior.ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {

        }

        void IEndpointBehavior.Validate(ServiceEndpoint endpoint)
        {

        }
    }
}
