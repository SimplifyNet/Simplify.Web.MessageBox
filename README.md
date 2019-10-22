# Simplify.Web.MessageBox

`Simplify.Web.MessageBox` is a package which provides non-interactive server side message box for [Simplify.Web](https://github.com/SimplifyNet/Simplify.Web) web-framework.

## Package status

| Latest version | [![Nuget version](http://img.shields.io/badge/nuget-v1.2-blue.png)](https://www.nuget.org/packages/Simplify.Web.MessageBox/) |
| :------ | :------: |
| **Dependencies** | [![Libraries.io dependency status for latest release](https://img.shields.io/librariesio/release/nuget/Simplify.Web.MessageBox.svg)](https://libraries.io/nuget/Simplify.Web.MessageBox) |
| **Target Frameworks** | 4.6.2, Standard 2.0 |

## Build status

| Branch | Status |
| :------ | :------ |
| **master** | [![AppVeyor Build status](https://ci.appveyor.com/api/projects/status/2h8jh563pwsf283i/branch/master?svg=true)](https://ci.appveyor.com/project/i4004/simplify-web-messagebox/branch/master) |

## Examples

### Setup message box templates

There are different template file for different message box statuses.
Inline templates intended to use as API responses but stylized with HTML.

![Template files](https://raw.githubusercontent.com/SimplifyNet/Simplify.Web.MessageBox/master/images/template-files.png)

### Displaying message box

#### Default message box which will be added to 'MainContent' variable

```csharp
public class MyController : Controller
{
	public override ControllerResponse Invoke()
	{
		return new MessageBox("your string");
	}
}
```

#### Inline message box

Framework execution will be stopped, message box will be returned to client without rest of the website content
```csharp
public class MyController : Controller
{
	public override ControllerResponse Invoke()
	{
		return new MessageBoxInline("your string");
	}
}
```
