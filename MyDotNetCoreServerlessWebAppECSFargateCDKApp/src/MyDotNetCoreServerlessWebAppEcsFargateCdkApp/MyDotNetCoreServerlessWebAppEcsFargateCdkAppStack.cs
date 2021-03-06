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

            var imageTagParameter = this.Node.TryGetContext("ImageTag");
            string imageTag = imageTagParameter.ToString() ??  "latest";
            IRepository ecrRepository = Repository.FromRepositoryArn(this, "MyDotNetCorServerlessWebAppServiceContainerRepository", "arn:aws:ecr:eu-west-1:098208531922:repository/mydotnetcorewebapp");

            var loadBalancedFargateService = new ApplicationLoadBalancedFargateService(this, "MyDotNetCorServerlessWebAppService", new ApplicationLoadBalancedFargateServiceProps()
            {
                AssignPublicIp = true,
                TaskImageOptions = new ApplicationLoadBalancedTaskImageOptions()
                {
                    Image = ContainerImage.FromEcrRepository(ecrRepository, imageTag),
                }
            }); ;
        }
    }
}
