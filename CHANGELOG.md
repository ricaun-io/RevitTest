# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [1.10.0] / 2025-04-04
- Update to [ricaun.RevitTest.TestAdapter 1.10.0](https://www.nuget.org/packages/ricaun.RevitTest.TestAdapter)
- Video [RevitTest Version 1.10.0 - dotnet test --filter](https://youtu.be/rXmxdQFAKnk)
### Features
- Support `dotnet test --filter` with properties `FullyQualifiedName` and `Name`. (Fix: #30)
- Example: [dotnet-test | Filter option details](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test?tabs=dotnet-test-with-vstest#filter-option-details)
	```bash
	dotnet test .\RevitTest.Samples\RevitTest.Samples.csproj --filter "FullyQualifiedName~VersionBuild"
	```
### Tests
- Add `RevitTests_VersionBuild` with `VersionBuild`.

## [1.1.0] / 2025-02-19
- Update to [ricaun.RevitTest.TestAdapter 1.9.0](https://www.nuget.org/packages/ricaun.RevitTest.TestAdapter)
- Video [RevitTest Version 1.9.0 - TestFixture](https://youtu.be/sxE7dfBK5Ok)
### Features
- Support `TestFixture/TestFixtureSource` (Fix: #25)
### Tests
- Add `Tests_OpenFileDocuments` to open `Project.rvt` samples.

## [1.0.9] / 2024-12-19
- Update to [ricaun.RevitTest.TestAdapter 1.8.0](https://www.nuget.org/packages/ricaun.RevitTest.TestAdapter)
- Video [RevitTest Version 1.8.0 - Open-Source](https://youtube.com/live/_lsmvQtGftE)

## [1.0.8] / 2024-12-10
- Update to [ricaun.RevitTest.TestAdapter 1.7.1](https://www.nuget.org/packages/ricaun.RevitTest.TestAdapter)
- Video [RevitTest Version 1.7.1 - Run async Revit Tests](https://youtu.be/wnNVmGcEp2o)

## [1.0.7] / 2024-12-05
- Update to [ricaun.RevitTest.TestAdapter 1.7.0](https://www.nuget.org/packages/ricaun.RevitTest.TestAdapter)
- Video [RevitTest Version 1.7.* - Run async Revit Tests [Obsolete]](https://youtu.be/6-iBk96ifPE)

## [1.0.6] / 2024-10-12
- Update to [ricaun.RevitTest.TestAdapter 1.6.0](https://www.nuget.org/packages/ricaun.RevitTest.TestAdapter)
- Video [RevitTest Version 1.6.* - Fake.RevitAPIUI reference](https://youtu.be/kgpfJQzA4r8)
- Version `1.6.0` features:
	- RevitAPIUI.Fake assembly to use in discovery (Fix: #17)

## [1.0.5] / 2024-09-20
- Update to [ricaun.RevitTest.TestAdapter 1.5.0](https://www.nuget.org/packages/ricaun.RevitTest.TestAdapter)
- Video [RevitTest Version 1.5.* - TestCaseSource](https://youtu.be/8ZP5bhP_18M)
- Version `1.5.0` features:
	- Support `TestCaseSource` (Fix: #13)

## [1.0.4] / 2024-09-06
- Update to [ricaun.RevitTest.TestAdapter 1.4.1](https://www.nuget.org/packages/ricaun.RevitTest.TestAdapter)
- Video [RevitTest Version 1.4.* - Timeout and Viewer Mode](https://youtu.be/qDIxW0DUKSI)
- Version `1.4.1` features:
	- Option `NUnit.Timeout` to set timeout for application, default is 10 minutes.
	- Auto close `Viewer Mode` dialog box when Revit using `/viewer`.
	- RevitTest Icon for light and dark theme.
	- ![RevitTest Panel](https://github.com/user-attachments/assets/1f5c2801-962d-4388-86c6-63a65bcf1c56)

## [1.0.3] / 2024-05-27
- Fix `TestCase` issue in version `1.3.2`.
- Add `Tests_Utils` with test cases for convert meters from internal.
- Update to [ricaun.RevitTest.TestAdapter 1.3.4](https://www.nuget.org/packages/ricaun.RevitTest.TestAdapter)
- Video [RevitTest Version 1.3.4 - Revit API](https://youtu.be/B4xETYY8ft8)

## [1.0.2] / 2024-05-14
- Update to [ricaun.RevitTest.TestAdapter 1.3.2](https://www.nuget.org/packages/ricaun.RevitTest.TestAdapter)
- Video [RevitTest Version 1.3.2 - Revit API](https://youtu.be/SFMzeS2XtuI)

## [1.0.1] / 2024-04-16
- Update project to support .Net Framework and .Net Core
- Update to [ricaun.RevitTest.TestAdapter 1.3.1](https://www.nuget.org/packages/ricaun.RevitTest.TestAdapter)
- Video [Update RevitTest.Samples unit test to Revit 2025](https://youtu.be/2wmkGzM4Dms)

## [1.0.0] / 2024-03-28
- First Release - [ricaun.RevitTest.TestAdapter 1.3.0](https://www.nuget.org/packages/ricaun.RevitTest.TestAdapter)

[vNext]: ../../compare/1.0.0...HEAD
[1.10.0]: ../../compare/1.1.0...1.10.0
[1.1.0]: ../../compare/1.0.9...1.1.0
[1.0.9]: ../../compare/1.0.8...1.0.9
[1.0.8]: ../../compare/1.0.7...1.0.8
[1.0.7]: ../../compare/1.0.6...1.0.7
[1.0.6]: ../../compare/1.0.5...1.0.6
[1.0.5]: ../../compare/1.0.4...1.0.5
[1.0.4]: ../../compare/1.0.3...1.0.4
[1.0.3]: ../../compare/1.0.2...1.0.3
[1.0.2]: ../../compare/1.0.1...1.0.2
[1.0.1]: ../../compare/1.0.0...1.0.1
[1.0.0]: ../../compare/1.0.0