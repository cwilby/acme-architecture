# Acme Architecture

An example .NET project that utilizes best practices including an IoC container, usage of the Data Transfer Object (DTO) pattern and usage of the Repository/Unit of Work pattern.

**Table of Contents**

- [Introduction](#introduction)
- [Data Model](#data-model)
- [Solution Layout](#solution-layout)
	- [Acme.Core](#acme.core)
	- [Acme.Data](#acme.data)
	- [Acme.Api](#acme.api)
- [Design Patterns](#design-patterns)
	- [Repository Pattern](#repository-pattern)
	- [Unit of Work](#unit-of-work)
	- [Inversion of Control](#inversion-of-control)
	- [Service Layer](#service-layer)
	- [Data Transfer Objects](#data-transfer-objects)
	- [Domain Layer](#domain-layer)
	- [Database Factory](#database-factory)
	- [Database Migrations](#database-migrations)
	- [Interface Segregation Principle](#interface-segregation-principle)
- [Roadmap](#roadmap)

## Introduction

This architecture is the product of learned best practices from the industry at large. This document aims to be a high level overview of these best practices, with references to the original sources where appropriate.

This architecture works best for scenarios where complex business logic needs to be organized and contained for better maintenance by a development team, and can be scaled either horizontally or vertically with ease when paired with the Azure platform.

As an added note, the patterns that are in use here (such as [Repository](#repository-pattern), [Unit of Work](#unit-of-work) and [Inversion of Control](#inversion-of-control) could also be paired with a Microservices architecture to provide finer granularity for scaling. Part of the [Roadmap](#roadmap) includes adding an example of microservices paired with this architecture.

## Data Model

## Solution Layout

```
Acme
|__ Acme.Api
	|__ App_Start
	|__ Controllers
	|__ Infrastructure
	|__ Injection
|__ Acme.Core
	|__ Domain
	|__ DTO
	|__ Exceptions
	|__ Extensions
	|__ Infrastructure
	|__ Mapping
	|__ Repository
	|__ Service
|__ Acme.Data
	|__ Configuration
	|__ Context
	|__ Identity
	|__ Infrastructure
	|__ Migrations
	|__ Repository
```

## Acme.Core
> The Core project is the heart of the application. Every project depends on Core.

Acme.Core contains all of the interfaces that are necessary for operation of the application. It is also where all of the business logic should be contained inside of services.

#### Nuget Packages
**[AutoMapper 5.1.1](https://github.com/AutoMapper/AutoMapper)** - A convention based object-object mapper. Used for converting Entity objects into Data Transfer Objects.

**[ASP.Identity.Core](https://www.asp.net/identity)** - The heart of the ASP Identity system. Used to bind `IUser` and `IRole` to Entity objects and expose the `UserManager` class to manage membership.

#### Acme.Core.Domain
- This is where you store your entity definitions.

  *Why?*: Placing entities in `Core` allows you to write multiple data layers and/or make it easier to swap out your data layer for another.
  
#### Acme.Core.DTO
- This is where you store your Data Transfer Object definitions. (See [Data Transfer Object](#data-transfer-objects) for an explanation of these classes)

#### Acme.Core.Exceptions
- This is where you store your custom application exceptions.

#### Acme.Core.Extensions
- This is where you store your [C# Extension methods](http://csharp.net-tutorials.com/csharp-3.0/extension-methods/).

#### Acme.Core.Infrastructure
- This is where the "plumbing" for the Core project resides. The majority of interfaces should reside in this folder.

#### Acme.Core.Mapping
- This is where your [AutoMapper Profiles](https://github.com/AutoMapper/AutoMapper/wiki/Configuration#profile-instances) reside.

#### Acme.Core.Repository
- This is where your Entity repository interfaces reside. (See [Interface Segregation Principle](http://www.oodesign.com/interface-segregation-principle.html))

#### Acme.Core.Service
- This is where your [Business Logic](https://en.wikipedia.org/wiki/Business_logic) resides, encapsulated in Service classes.

## Acme.Data
> The Data project is where your data access code resides. 
> 
> **Business logic is banned from this project.**

The Data project is solely responsible for data access operations. It provides implementations of the IRepository/IUnitOfWork interfaces found in the Core project.

**No business logic allowed!**

*Why?*: If you opt for another database technology (Moving from SQL Server to Postgres/MongoDB etc), you will have to rewrite business logic to work with that particular data access logic. 

*Keep Business Logic In The Core™*!

#### Nuget Packages
**[Entity Framework 6.1.3](https://github.com/aspnet/EntityFramework6)** - A convention based object-object mapper. Used for converting Entity objects into Data Transfer Objects.

**[ASP.Identity.Core](https://www.asp.net/identity)** - The heart of the ASP Identity system. Used to implement the `IUserStore` interface for `UserManager` to consume in the Core project.

#### Acme.Data.Configuration
- This is where your [Entity Framework Configurations](http://odetocode.com/blogs/scott/archive/2011/11/28/composing-entity-framework-fluent-configurations.aspx) reside.

#### Acme.Data.Context
- This is where your Data Contexts reside. Currently this project has one data context, but you could have multiple data contexts here to support a multi-database application.

#### Acme.Data.Identity
- This is where the implementation of `IUserStore` resides.

#### Acme.Data.Infrastructure
- This is where the "plumbing" for the Data project resides. Implementations for the `IRepository<TEntity>` and `IUnitOfWork` interfaces found in `Acme.Core.Infrastructure` reside in this folder.

#### Acme.Data.Migrations
- This is where your [Entity Framework Migrations](http://www.entityframeworktutorial.net/code-first/code-based-migration-in-code-first.aspx) reside.

#### Acme.Data.Repository
- This is where the implementations of your Entity interfaces found in Core reside. See (See [Interface Segregation Principle](http://www.oodesign.com/interface-segregation-principle.html))

## Acme.Api
> The API project is where you expose your application data to your clients and bind all your interfaces to their matching implementations.
> 
> **Business logic is banned from this project**

The API project is solely responsible for transporting [Data Transfer Objects](#data-transfer-objects) to and from your [Service Layer](#service-layer) and front-end clients. 

**No business logic allowed!**

*Why?*: If you opt for another REST API technology (Moving from ASP Web API 2 to Nancy, ASP.NET Core etc), you will have to rewrite business logic to work with that particular technology. 

*Keep Business Logic In The Core™*!

#### Nuget Packages <small>(Other than the usual Web API nuget packages)</small>

**[AutoMapper 5.1.1](https://github.com/AutoMapper/AutoMapper)** - A convention based object-object mapper. Residual dependency necessary for injecting `IMapper` into the [Service Layer](#service-layer)

**[Microsoft.Owin.Cors](https://www.nuget.org/packages/Microsoft.Owin.Cors/)** - Enables [Cross Origin Resource Sharing](https://developer.mozilla.org/en-US/docs/Web/HTTP/Access_control_CORS) for the API.

**[SimpleInjector](https://simpleinjector.org/index.html)** - Used as the IoC container for the application.

#### Acme.Api.App_Start
This is where your OWIN configuration code resides, split among several [partial classes](https://www.dotnetperls.com/partial). This is done to improve maintainability when your configuration code inevitably grows larger.

#### Acme.Api.Controllers
This is where your API controllers reside. These should only ever have Services injected into them, **never repositories**.

*Why?:* If repositories are injected into your controllers, it's a good indicator that business logic is about to be performed in your controller. Even basic CRUD actions are considered to be business logic, *because these actions are operating on entities, which represent your business*.

#### Acme.Api.Infrastructure
- This is where the "plumbing" for the API project resides. Currently there is a single class in this folder - an implementation of a `Session` class to make the current user available to every project (even all the way down to the data access layer!)

#### Acme.Api.Injection
- This is where your IoC configuration resides. Configuration is split among several `Packages` to improve maintability in the inevitable event that more types of services are created. See [this stack overflow answer](https://www.nuget.org/packages/SimpleInjector.Packaging) for discussion on this topic.

## Design Patterns

### Repository Pattern
> Mediates between the domain and data mapping layers using a collection-like interface for accessing domain objects.
> 
[http://martinfowler.com/eaaCatalog/repository.html](http://martinfowler.com/eaaCatalog/repository.html)

### Unit of Work
> Maintains a list of objects affected by a business transaction and coordinates the writing out of changes and the resolution of concurrency problems.
> 
> [http://martinfowler.com/eaaCatalog/unitOfWork.html](http://martinfowler.com/eaaCatalog/unitOfWork.html)

### Inversion of Control
>The Inversion of Control (IoC) and Dependency Injection (DI) patterns are all about softening dependencies in your code.
>
[http://joelabrahamsson.com/inversion-of-control-an-introduction-with-examples-in-net/](http://joelabrahamsson.com/inversion-of-control-an-introduction-with-examples-in-net/)

>[http://stackoverflow.com/a/3140](http://stackoverflow.com/a/3140)

### Service Layer
> Defines an application's boundary with a layer of services that establishes a set of available operations and coordinates the application's response in each operation.
> 
> Used to store Business Logic
> 
> [http://martinfowler.com/eaaCatalog/serviceLayer.html](http://martinfowler.com/eaaCatalog/serviceLayer.html)

### Data Transfer Objects
> An object that carries data between processes in order to reduce the number of method calls.
> 
> [http://martinfowler.com/eaaCatalog/dataTransferObject.html](http://martinfowler.com/eaaCatalog/dataTransferObject.html)
> 
> [http://stackoverflow.com/a/725365](http://stackoverflow.com/a/725365)
> 
> [http://www.aspnetboilerplate.com/Pages/Documents/Data-Transfer-Objects](http://www.aspnetboilerplate.com/Pages/Documents/Data-Transfer-Objects)

### Domain Layer
> An object model of the domain that incorporates both behavior and data.
> 
> [http://martinfowler.com/eaaCatalog/domainModel.html](http://martinfowler.com/eaaCatalog/domainModel.html)

**Important Note about the Domain Layer**<br />
You'll see a lot of times in this document the saying `Keep Business Logic In The Core!`. This does *not* mean `Keep Business Logic in the Service Layer!`.

You can, and you absolutely should write business logic in the Domain model as well as the service layer.

Keeping your domain layer void of any business logic can lead to an [Anemic Domain Model](http://www.martinfowler.com/bliki/AnemicDomainModel.html) as described my Martin Fowler.

### Database Factory
The Database Factory is an Entity Framework specific solution for the [Stale Context](http://mehdi.me/ambient-dbcontext-in-ef6/) problem. It allows the DataContexts in use in the application to be scoped to the current request lifecycle, while hiding this fact from the rest of the architecture.

### Database Migrations
> Migrations help you maintain the state of a Database schema inside of your application codebase.
> 
> [http://www.entityframeworktutorial.net/code-first/migration-in-code-first.aspx](http://www.entityframeworktutorial.net/code-first/migration-in-code-first.aspx)

### Interface Segregation Principle

> The interface-segregation principle (ISP) states that no client should be forced to depend on methods it does not use.[1] ISP splits interfaces that are very large into smaller and more specific ones so that clients will only have to know about the methods that are of interest to them.
>
> [https://en.wikipedia.org/wiki/Interface_segregation_principle](https://en.wikipedia.org/wiki/Interface_segregation_principle)

## Roadmap

- Add an example of Microservices architecture using Azure Surface Fabric.