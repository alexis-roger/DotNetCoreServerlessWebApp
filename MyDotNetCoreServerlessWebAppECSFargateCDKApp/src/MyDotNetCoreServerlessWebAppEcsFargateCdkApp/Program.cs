using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDotNetCoreServerlessWebAppEcsFargateCdkApp
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new MyDotNetCoreServerlessWebAppEcsFargateCdkAppStack(app, "MyDotNetCoreServerlessWebAppEcsFargateCdkAppStack");
            app.Synth();
        }
    }
}
