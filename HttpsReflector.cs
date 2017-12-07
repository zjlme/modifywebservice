using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace webservicetest
{

    public class HttpsReflector : SoapExtensionReflector
    {

        public override void ReflectMethod()
        {
            //no-op
        }

        public override void ReflectDescription()
        {
            ServiceDescription description = ReflectionContext.ServiceDescription;
            foreach (Service service in description.Services)            {
                foreach (Port port in service.Ports)
                {
                    foreach (ServiceDescriptionFormatExtension extension in port.Extensions)
                    {
                        SoapAddressBinding binding = extension as SoapAddressBinding;
                        if (null != binding)
                        {
                            string loc_url = binding.Location;
                            string[] tmprepstr = loc_url.Split('/');
                            binding.Location = binding.Location.Replace(tmprepstr[2], "huapi.paas.zj.chinamobile.com");//  
                        }
                    }
                }
            }
        }

    }

}
