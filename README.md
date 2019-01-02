# Common Models
.net framework 4.5+: [![NuGet](https://img.shields.io/nuget/v/nlog.svg)](https://www.nuget.org/packages/Valco.Common.Models)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/valeev/Common/blob/master/LICENSE)

.net core: [![NuGet](https://img.shields.io/nuget/v/nlog.svg)](https://www.nuget.org/packages/Valco.Common.Core.Models)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/valeev/Common/blob/master/LICENSE)

Common.Models is a free library with common classes for Data layer in microservices. It contains common init classes for repositories and unit of work. Also common base classes for db entities.

UPD: .net core lib doesn't contain repo interfaces anymore. DbContext in ef core = UoW.

# Common Contracts
.net framework 4.5+: [![NuGet](https://img.shields.io/nuget/v/nlog.svg)](https://www.nuget.org/packages/Valco.Common.Contracts)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/valeev/Common/blob/master/LICENSE)
.net core: [![NuGet](https://img.shields.io/nuget/v/nlog.svg)](https://www.nuget.org/packages/Valco.Common.Core.Contracts)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/valeev/Common/blob/master/LICENSE)

Common.Contracts is a free library with common classes for Contracts layer in microservices. It contains abstract request and response classes for building structured service. Also this library contains common interface for all microservices with common method(ServiceInfo) model which should be provided by all services.

# Common Contracts for WCF
.net framework 4.5+: [![NuGet](https://img.shields.io/nuget/v/nlog.svg)](https://www.nuget.org/packages/Valco.Common.Contracts.WCF)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/valeev/Common/blob/master/LICENSE)

Common.Contracts.WCF is a free library with common classes for Contracts layer in microservices for realization by WCF.

# Common WebApi helpers
.net framework 4.5+: [![NuGet](https://img.shields.io/nuget/v/nlog.svg)](https://www.nuget.org/packages/Valco.Common.WebApi)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/valeev/Common/blob/master/LICENSE)

Common.WebApi is a free library with helpers for converting ServiceResponse to proper HTTP status, common library for logging all requests and responses.

For registration logger for all REST requests and responses add next code to App_Start/WebApiConfig.cs to Register method

	// Custom log handler for every REST request
	config.MessageHandlers.Add(new CustomLogHandler());
