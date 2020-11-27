using Amazon.CDK;
using Amazon.CDK.AWS.ECR;
using Amazon.CDK.AWS.ECS;
using Amazon.CDK.AWS.ECS.Patterns;

namespace MyDotNetCoreServerlessWebAppEcsFargateCdkApp
{
    public class MyDotNetCoreServerlessWebAppEcsFargateCdkAppStack : Stack
    {
        internal MyDotNetCoreServerlessWebAppEcsFargateCdkAppStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            IRepository ecrRepository = Repository.FromRepositoryArn(this, "MyDotNetCorServerlessWebAppServiceContainerRepository", "arn:aws:ecr:eu-west-1:204847680503:repository/mydotnetcoreserverlesswebapp");

            var loadBalancedFargateService = new ApplicationLoadBalancedFargateService(this, "MyDotNetCorServerlessWebAppService", new ApplicationLoadBalancedFargateServiceProps()
            {
                TaskImageOptions = new ApplicationLoadBalancedTaskImageOptions()
                {
                    Image = ContainerImage.FromEcrRepository(ecrRepository)
                }
            });
        }
    }
}
