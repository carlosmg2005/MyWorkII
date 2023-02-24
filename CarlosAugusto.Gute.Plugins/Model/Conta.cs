using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Deployment;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosAugusto.Gute.MyPlugins.Model
{
    public class Conta
    {
        public IOrganizationService ServiceClient { get; set; }

        public string Logicalname { get; set; }

        public Conta(IOrganizationService crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.Logicalname = "account";
        }

        public Entity GetAccountById(Guid id, string[] columns)
        {
            return ServiceClient.Retrieve(this.Logicalname, id, new ColumnSet(columns));
        }

        public void IncrementOrDecrementNumberOfOpp(Entity oppAccount, bool? decrementOrIncrement)
        {
            int numberOfOpp = oppAccount.Contains("dcp_nmr_total_opp") ? (int)oppAccount["dcp_nmr_total_opp"] : 0;

            if (Convert.ToBoolean(decrementOrIncrement))
            {
                numberOfOpp += 1;  //FAZ PARTE DO CREATE, NAO FOI EXIGIDO NO ENUNCIADO, MAS OPTEI POR DEIXAR
            }
            else
            {
                numberOfOpp -= 1;
            }
            oppAccount["dcp_nmr_total_opp"] = numberOfOpp;
            ServiceClient.Update(oppAccount);
        }
    }
}
