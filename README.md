# RevitTest.Samples

[![Revit 2024](https://img.shields.io/badge/Revit-2024+-blue.svg)](https://github.com/ricaun-io/RevitTest/)
[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](https://github.com/ricaun-io/RevitTest/)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](https://github.com/ricaun-io/RevitTest/actions/workflows/Build.yml/badge.svg)](https://github.com/ricaun-io/RevitTest/actions)
[![nuget](https://img.shields.io/nuget/v/ricaun.RevitTest.TestAdapter?logo=nuget&label=nuget&color=blue)](https://www.nuget.org/packages/ricaun.RevitTest.TestAdapter)

[![RevitTest.Samples](assets/RevitTest.Samples.png)](https://github.com/ricaun-io/RevitTest)

[ricaun.RevitTest](https://github.com/ricaun-io/ricaun.RevitTest) is a multi-version NUnit testing framework for Revit API.

**This project contain samples and the basic info about the [ricaun.RevitTest](https://github.com/ricaun-io/ricaun.RevitTest) Framework.**

## Features

* Run tests and debug using `Visual Studio` to execute tests inside Revit.

<img src=assets/RevitTest.Feature.Run.gif width=400><img src=assets/RevitTest.Feature.Debug.gif width=400>

* Open and Close Revit and `dotnet test` execution.

<img src=assets/RevitTest.Feature.Open.Close.gif width=400><img src=assets/RevitTest.Feature.dotnet.gif width=400>

## Discussions

[RevitTest Discussions](https://github.com/ricaun-io/RevitTest/discussions) is a place to share ideas and aks questions about the framework.

## Samples

The sample project contains the basic usage of the [ricaun.RevitTest](https://github.com/ricaun-io/ricaun.RevitTest) Framework.

* [RevitTest.Samples](RevitTest.Samples)
* [RevitTest.Language](https://github.com/ricaun-io/RevitTest.Language)

## Install

To install the [ricaun.RevitTest.TestAdapter](https://www.nuget.org/packages/ricaun.RevitTest.TestAdapter), you can use the NuGet package manager.

### PackageReference 

The main package is [ricaun.RevitTest.TestAdapter](https://www.nuget.org/packages/ricaun.RevitTest.TestAdapter) that manage the NUnit test execution of tests inside Revit.

***The machine need to have the Autodesk Revit installed to work.***

```xml
<PackageReference Include="NUnit" Version="3.13.3" />
<PackageReference Include="ricaun.RevitTest.TestAdapter" Version="*" />
```

#### .Net Core

If you are using `.Net Core`, you need to add the `Microsoft.NET.Test.Sdk` package to the `.csproj` file.

```xml
<PackageReference Include="Microsoft.NET.Test.Sdk" Version="*" Condition="!$(TargetFramework.StartsWith('net4'))" />
```

### IsTestProject

If your are using `dotnet test` to execute the tests, you need to add the `IsTestProject` property to the `.csproj` file.

```xml
<IsTestProject>true</IsTestProject>
```

### Example

The framework injects the `UIApplication`, `UIControllerApplication`, `Application`, and `ControllerApplication` Revit objects to the tests methods, use in the method with `[OneTimeSetUp]` or `[SetUp]`.

```c#
using Autodesk.Revit.UI;
using NUnit.Framework;

public class RevitTest
{
    private UIApplication uiapp;
    [OneTimeSetUp]
    public void Setup(UIApplication uiapp)
    {
        this.uiapp = uiapp;
    }
    [Test]
    public void VersionName()
    {
        Assert.IsNotNull(uiapp);
        System.Console.WriteLine(uiapp.Application.VersionName);
    }
}
```

## ricaun.RevitTest

The [ricaun.RevitTest](https://github.com/ricaun-io/ricaun.RevitTest) Framework is composed by 3 projects:

```mermaid
---
title: ricaun.RevitTest
---
flowchart LR
    dll(dll)
    TestAdapter[TestAdapter]
    Console[Console]
    Application[Application]
    dll--dotnet test-->TestAdapter
    TestAdapter--Start-->Console
    Console--Run Tests-->Application
    Console-.Open/Close.-Revit
    subgraph Revit [Revit]
        Application
    end
```

* **TestAdapter**: The NUnit TestAdapter is responsible for executing the `Console` and waits for the tests results.
* **Console**: The Console application responsible for communicating with Revit, installing the `Application`, and opening/closing Revit.
* **Application**: The Revit Plugin application is responsible for executing the tests sent by `Console`.


## FAQ

</details>

<details><summary>The <b>ricaun.RevitTest</b> Framework is free to use ?</summary><br>

Yes.

</details>

<details><summary>What are the requirements to use <b>ricaun.RevitTest</b> Framework ?</summary><br>

It is a requirement to have [Autodesk Revit](http://revit.com) installed on the machine to run the tests in the official software.

</details>

<details><summary>The <b>ricaun.RevitTest</b> Framework is open-source ?</summary><br>

Not available yet.

</details>

<details><summary>Do you need an account to use the <b>ricaun.RevitTest</b> Framework ?</summary><br>

Yes, an Autodesk account is required inside Revit.

</details>

<details><summary>The <b>ricaun.RevitTest</b> Framework collects any use data ?</summary><br>

No.

</details>

<details><summary>The <b>ricaun.RevitTest</b> Framework works offline ?</summary><br>

Yes.

</details>

<details><summary>The <b>ricaun.RevitTest</b> Framework works with Design Automation for Revit ?</summary><br>

Yes, is possible to switch the `Console` to run the tests using the Design Automation for Revit instead of the Revit for desktop. (Not available yet)

</details>

<details><summary>The <b>ricaun.RevitTest</b> Framework works in Rider ?</summary><br>

Yes, the `TestAdapter` could work with Rider after some configuration, check the discussion: https://github.com/ricaun-io/RevitTest/discussions/8

</details>

<details><summary>Do you have plans to create a similar test framework for AutoCAD or Inventor ?</summary><br>

Could be possible, but I only use Revit so I don't have the incentive to do that.

</details>

<details><summary>How the <b>ricaun.RevitTest</b> Framework knows what Revit version to open ?</summary><br>

The `TestAdapter` checks for some `RevitApi` reference in the test assembly and get the version from it. If not found, the `TestAdapter` will use the lowest version of Revit installed in the machine.

</details>

<details><summary>How the force to use a specific Revit version ?</summary><br>

To overwrite the version selection of the `TestAdapter`, you can use the `AssemblyMetadataAttribute` property with `NUnit.Version` in the test project, like this:

In the `.cs` file:
```csharp
[assembly: System.Reflection.AssemblyMetadata("NUnit.Version", "2024")]
```
Or in the `.csproj` file:
```xml
<ItemGroup>
  <AssemblyAttribute Include="System.Reflection.AssemblyMetadataAttribute">
    <_Parameter1>NUnit.Version</_Parameter1>
    <_Parameter2>2024</_Parameter2>
  </AssemblyAttribute>
</ItemGroup>
```

</details>

<details><summary>How the force to use a specific Revit language ?</summary><br>

To force the `TestAdapter` to open Revit with a specific language, you can use the `AssemblyMetadataAttribute` property with `NUnit.Language` in the test project, like this:

In the `.cs` file:
```csharp
[assembly: System.Reflection.AssemblyMetadata("NUnit.Language", "ENU")]
```
Or in the `.csproj` file:
```xml
<ItemGroup>
  <AssemblyAttribute Include="System.Reflection.AssemblyMetadataAttribute">
    <_Parameter1>NUnit.Language</_Parameter1>
    <_Parameter2>ENU</_Parameter2>
  </AssemblyAttribute>
</ItemGroup>
```

</details>

<details><summary>How the force to open a new Revit process ?</summary><br>

By default `TestAdapter` uses the Revit process opened with the same version to run the tests.
To overwrite and force to open a new process, you can use the `AssemblyMetadataAttribute` property with `NUnit.Open` in the test project, like this:

In the `.cs` file:
```csharp
[assembly: System.Reflection.AssemblyMetadata("NUnit.Open", "true")]
```
Or in the `.csproj` file:
```xml
<ItemGroup>
  <AssemblyAttribute Include="System.Reflection.AssemblyMetadataAttribute">
    <_Parameter1>NUnit.Open</_Parameter1>
    <_Parameter2>true</_Parameter2>
  </AssemblyAttribute>
</ItemGroup>
```

</details>

<details><summary>How the force to close Revit after the test finish ?</summary><br>

By default `TestAdapter` does not closes Revit after finish a test.
To overwrite and force to close Revit, you can use the `AssemblyMetadataAttribute` property with `NUnit.Close` in the test project, like this:

In the `.cs` file:
```csharp
[assembly: System.Reflection.AssemblyMetadata("NUnit.Close", "true")]
```
Or in the `.csproj` file:
```xml
<ItemGroup>
  <AssemblyAttribute Include="System.Reflection.AssemblyMetadataAttribute">
    <_Parameter1>NUnit.Close</_Parameter1>
    <_Parameter2>true</_Parameter2>
  </AssemblyAttribute>
</ItemGroup>
```

</details>

<details><summary>How to enable log in the TestAdapter ?</summary><br>

The log verbosity has two levels `1`(Normal) and `2`(Debug), to enable you can use the `AssemblyMetadataAttribute` property with `NUnit.Verbosity` in the test project, like this:

In the `.cs` file:
```csharp
[assembly: System.Reflection.AssemblyMetadata("NUnit.Verbosity", "1")]
```
Or in the `.csproj` file:
```xml
<ItemGroup>
  <AssemblyAttribute Include="System.Reflection.AssemblyMetadataAttribute">
    <_Parameter1>NUnit.Verbosity</_Parameter1>
    <_Parameter2>1</_Parameter2>
  </AssemblyAttribute>
</ItemGroup>
```

</details>

<details><summary>How change the timeout for the TestAdapter ?</summary><br>

By default `TestAdapter` have a timeout of `10` minutes.
To set the timeout you can use the `AssemblyMetadataAttribute` property with `NUnit.Timeout` in the test project, like this:

In the `.cs` file:
```csharp
[assembly: System.Reflection.AssemblyMetadata("NUnit.Timeout", "10")]
```
Or in the `.csproj` file:
```xml
<ItemGroup>
  <AssemblyAttribute Include="System.Reflection.AssemblyMetadataAttribute">
    <_Parameter1>NUnit.Timeout</_Parameter1>
    <_Parameter2>10</_Parameter2>
  </AssemblyAttribute>
</ItemGroup>
```

</details>

<details><summary>How the force Revit to open with <b>Viewer Mode</b> ?</summary><br>

To force the `TestAdapter` to open Revit open with `Viewer Mode`, you can use the `AssemblyMetadataAttribute` property with `NUnit.Language` in the test project to inject the `/viewer` command, like this:

In the `.cs` file:
```csharp
[assembly: System.Reflection.AssemblyMetadata("NUnit.Language", "ENU /viewer")]
```
Or in the `.csproj` file:
```xml
<ItemGroup>
  <AssemblyAttribute Include="System.Reflection.AssemblyMetadataAttribute">
    <_Parameter1>NUnit.Language</_Parameter1>
    <_Parameter2>ENU /viewer</_Parameter2>
  </AssemblyAttribute>
</ItemGroup>
```

The dialog box will be closed automatically when Revit is opened using the `Viewer Mode` when using `TestAdapter`.

![Revit 2025 - viewer mode dialog](https://github.com/user-attachments/assets/d18020f7-c3bf-41ec-8ab9-e73e9884bef7)
**Viewer mode allows all functionality of Revit, except the following: save or save as in all cases; exporting or publishing modified projects; exporting or publishing any projects to a format containing model data that can be modified; or printing projects after changes are made.**


</details>

## License

This project is [licensed](LICENSE) under the [MIT License](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this project? Please [star this project on GitHub](https://github.com/ricaun-io/RevitTest//stargazers)!