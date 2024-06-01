# Simplify.Web.MessageBox

[![Nuget Version](https://img.shields.io/nuget/v/Simplify.Web.MessageBox)](https://www.nuget.org/packages/Simplify.Web.MessageBox/)
[![Nuget Download](https://img.shields.io/nuget/dt/Simplify.Web.MessageBox)](https://www.nuget.org/packages/Simplify.Web.MessageBox/)
[![Build Package](https://github.com/SimplifyNet/Simplify.Web.MessageBox/actions/workflows/build.yml/badge.svg)](https://github.com/SimplifyNet/Simplify.Web.MessageBox/actions/workflows/build.yml)
[![Libraries.io dependency status for latest release](https://img.shields.io/librariesio/release/nuget/Simplify.Web.MessageBox)](https://libraries.io/nuget/Simplify.Web.MessageBox)
[![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/SimplifyNet/Simplify.Web.MessageBox)](https://www.codefactor.io/repository/github/simplifynet/simplify.web.MessageBox)
![Platform](https://img.shields.io/badge/platform-.NET%206.0%20%7C%20.NET%20Standard%202.1%20%7C%20.NET%20Standard%202.0-lightgrey)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen)](http://makeapullrequest.com)

`Simplify.Web.MessageBox` is a package which provides non-interactive server side message box for [Simplify.Web](https://github.com/SimplifyNet/Simplify.Web) web-framework.

## Quick Start

### Setup message box templates

There are different template file for different message box statuses.
Inline templates intended to use as API responses but stylized with HTML.

![Template files](https://raw.githubusercontent.com/SimplifyNet/Simplify.Web.MessageBox/master/images/template-files.png)

### Displaying message box

#### Default message box which will be added to 'MainContent' variable

```csharp
public class MyController : Controller2
{
    public ControllerResponse Invoke() =>
        new MessageBox("your string");
}
```

#### Inline message box

Framework execution will be stopped, message box will be returned to client without rest of the website content

```csharp
public class MyController : Controller2
{
    public ControllerResponse Invoke() =>
        new MessageBoxInline("your string");
}
```
