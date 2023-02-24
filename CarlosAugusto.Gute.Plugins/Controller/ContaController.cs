using CarlosAugusto.Gute.MyPlugins.Model;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Rest;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosAugusto.Gute.MyPlugins.Controller
{
    public class ContaController
    {
        public IOrganizationService ServiceClient { get; set; }
        public Conta Conta { get; set; }

        public ContaController(IOrganizationService crmServiceCliente)
        {
            ServiceClient = crmServiceCliente;
            this.Conta = new Conta(ServiceClient);
        }

        public ContaController(CrmServiceClient crmServiceCliente)
        {
            ServiceClient = crmServiceCliente;
            this.Conta = new Conta(ServiceClient);
        }

        public Entity GetAccountById(Guid id, string[] columns)
        {
            return Conta.GetAccountById(id, columns);
        }

        public void IncrementOrDecrementNumberOfOpp(Entity oppAccount, bool? incrementOrDecrement)
        {
            Conta.IncrementOrDecrementNumberOfOpp(oppAccount, incrementOrDecrement);
        }
    }
}
