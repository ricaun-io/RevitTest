using Nuke.Common;
using Nuke.Common.Execution;
using ricaun.Nuke;
using ricaun.Nuke.Components;

class Build : NukeBuild, IPublish, ITestLocal
{
    string IHazMainProject.MainName => "RevitTest.Samples";
    string ITestLocal.TestLocalProjectName => "RevitTest.Samples";
    public static int Main() => Execute<Build>(x => x.From<IPublish>().Build);
}