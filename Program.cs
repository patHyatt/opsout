using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace opsout
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration config = new Configuration();
            //validate we're configured
            if (!config.IsValid())
            {
                Console.Error.WriteLine("Missing .config entries. Ensure you have values for keys defined.");
                return;
            }

            // ProjectID,Environment1,Environment2,...,EnvironmentN
            // 86179841,Internal,Release,Production
            if (args?.Length < 2)
            {
                Console.Error.WriteLine("A project ID and at least two (2) environments are required");
                Console.Error.WriteLine("example:");
                Console.Error.WriteLine("86179841|Internal,Release");
                return;
            }

            List<QueryArgument> lookups = new List<QueryArgument>();
            foreach (string argument in args)
            {
                string[] separated = argument.Split('|');
                QueryArgument query = new QueryArgument
                {
                    ProjectId = Convert.ToInt32(separated[0]),
                    Environments = new HashSet<string>(separated[1].Split(','))
                };

                lookups.Add(query);
            }

            RestClient client = new RestClient(config.Url);
            client.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator(config.User, config.Password);

            //foreach
            foreach (QueryArgument query in lookups)
            {
                RestRequest request = new RestRequest("/rest/api/latest/deploy/dashboard/{id}", Method.GET);
                request.AddUrlSegment("id", query.ProjectId.ToString());

                IRestResponse<List<ProjectDeployment>> response = client.Execute<List<ProjectDeployment>>(request);
                ProjectDeployment dashboard = response.Data?[0];

                IEnumerable<EnvironmentStatus> filteredStatuses = dashboard.environmentStatuses.FindAll(envStatus => query.Environments.Contains(envStatus.environment.name));

                Console.Write($"{dashboard.deploymentProject.name} ({dashboard.deploymentProject.planKey.key})");
                string goldenBoy = filteredStatuses.First(s => s.environment.name == query.Environments.First()).deploymentResult.deploymentVersionName;
                bool allSynchronized = filteredStatuses.All(status => status.deploymentResult.deploymentVersionName == goldenBoy);
                Console.ForegroundColor = allSynchronized ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine(allSynchronized ? " Is all good." : $" {goldenBoy} needs deployment.");
                Console.ResetColor();
            }
            Console.WriteLine("Completed. Hit 'Enter' to exit.");
            Console.ReadLine();
        }
    }


}