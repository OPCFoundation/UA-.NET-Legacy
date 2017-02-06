using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua;
using Opc.Ua.Configuration;
using Opc.Ua.Client;
using System.IdentityModel.Tokens;
using System.Windows.Forms;
using Opc.Ua.Gds;

namespace AuthorizationClient
{
    partial class Program
    {
        [STAThread]
        static void Main()
        {
            // Initialize the user interface.
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            Session session = null;

            try
            {
                ApplicationInstance application = new ApplicationInstance();
                application.ApplicationType = ApplicationType.Client;
                application.ConfigSectionName = "Opc.Ua.ClientConfiguration";

                // load the application configuration.
                application.LoadApplicationConfiguration(false);

                // check the application certificate.
                application.CheckApplicationInstanceCertificate(false, 0);

                // set up the HTTP validator.
                var httpsCertificateValidator = new CertificateValidator();
                httpsCertificateValidator.CertificateValidation += CertificateValidator_HttpsCertificateValidation;
                ApplicationInstance.SetUaValidationForHttps(httpsCertificateValidator);

                string response = null;

                while (String.IsNullOrEmpty(response) || response.StartsWith("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    // select the endpoint from the 
                    var endpoint = EndpointDescription.SelectEndpoint(application.ApplicationConfiguration, "opc.tcp://localhost:49710", false);

                    Console.WriteLine("Choose a User Token Policy:");
                    Console.WriteLine();

                    // connect to the server and select one of the supported token types.
                    var policy = SelectUserTokenPolicy(endpoint.UserIdentityTokens);

                    // create the token that can be used to login.
                    var task = CreateIdentity(application, endpoint, policy);
                    task.Wait();

                    EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(application.ApplicationConfiguration);
                    ConfiguredEndpoint ce = new ConfiguredEndpoint(null, endpoint, endpointConfiguration);

                    Console.WriteLine("Created Token[{0}] {1}", task.Result.TokenType, task.Result.DisplayName);

                    session = Session.Create(
                        application.ApplicationConfiguration,
                        ce,
                        true,
                        false,
                        "Authorization Client",
                        60000,
                        task.Result,
                        null);

                    Console.WriteLine("Connected ({0})", session.Connected);
                    Console.WriteLine("Choose a different token? [Y]");
                    response = Console.ReadLine();
                    session.Close();
                    session = null;
                }
            }
            catch (AggregateException e)
            {
                foreach (var ie in e.InnerExceptions)
                {
                    Console.WriteLine("EXCEPTION [{0}] {1}", ie.GetType().Name, ie.Message);
                }

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEPTION [{0}] {1}", e.GetType().Name, e.Message);
                Console.ReadLine();
            }

            // clean up.
            if (session != null)
            {
                session.Dispose();
                session = null;
            }
        }

        static void CertificateValidator_HttpsCertificateValidation(CertificateValidator sender, CertificateValidationEventArgs e)
        {
            // automatically accept all untrusted certficates.
            if (e.Error.Code == StatusCodes.BadCertificateUntrusted)
            {
                e.Accept = true;
            }
        }

        static UserTokenPolicy SelectUserTokenPolicy(IList<UserTokenPolicy> policies)
        {
            int ii = 1;

            foreach (var policy in policies)
            {
                Console.Write(ii++);
                Console.Write(") ");

                switch (policy.TokenType)
                {
                    case UserTokenType.Anonymous: { Console.WriteLine("Anonymous"); break; }
                    case UserTokenType.UserName: { Console.WriteLine("User Name/Password"); break; }
                    case UserTokenType.Certificate: { Console.WriteLine("User Certificate"); break; }

                    case UserTokenType.IssuedToken:
                    {
                        if (policy.IssuedTokenType == "http://opcfoundation.org/UA/UserToken#JWT")
                        {
                            Console.Write("JSON Web Token (JWT) ");

                            JwtEndpointParameters parameters = new JwtEndpointParameters();
                            parameters.FromJson(policy.IssuerEndpointUrl);

                            int pos = parameters.AuthorityProfileUri.LastIndexOf("#");

                            Console.Write(parameters.AuthorityProfileUri.Substring(pos + 1));
                            Console.Write(" ");
                            Console.WriteLine(parameters.AuthorityUrl);
                        }
                        else
                        {
                            Console.Write("Issued Token ");
                            Console.WriteLine(policy.IssuedTokenType);
                        }

                        break;
                    }
                }
            }

            Console.WriteLine();
            Console.Write("Enter Choice: ");

            int index = 0;

            if (!Int32.TryParse(Console.ReadLine(), out index))
            {
                Console.WriteLine("Operation Cancelled.");
                return null;
            }

            return policies[index - 1];
        }

        static NodeId GetClientApplicationId(ApplicationInstance application, string gdsUrl)
        {
            GlobalDiscoveryServer gds = new GlobalDiscoveryServer(application);

            try
            {
                gds.AdminCredentials = new UserIdentity("gdsadmin", "demo");
                gds.Connect(gdsUrl);

                var records = gds.FindApplication(application.ApplicationConfiguration.ApplicationUri);

                if (records == null || records.Length == 0)
                {
                    var record = new ApplicationRecordDataType()
                    {
                        ApplicationNames = new LocalizedTextCollection(new LocalizedText[] { application.ApplicationConfiguration.ApplicationName }),
                        ApplicationType = ApplicationType.Client,
                        ApplicationUri = application.ApplicationConfiguration.ApplicationUri,
                        ProductUri = application.ApplicationConfiguration.ProductUri
                    };

                    return gds.RegisterApplication(record);
                }

                return records[0].ApplicationId;
            }
            finally
            {
                gds.Disconnect();
            }
        }
    }
}
