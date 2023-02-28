# CQRS_BankApplication
This is the application of Bank with using CQRS(Command Query Responsibility Segregation) is a pattern that separates the responsibility for handling read and write operations. 
In this pattern, the write operations are handled by Commands, and read operations are handled by Queries.

In our example, we will be using Mediator pattern to implement the CQRS and Clean architecture. Mediator pattern is a behavioral design pattern that allows objects to communicate with each other through a mediator object, which centralizes communication between objects and decouples them from each other.

# Application Fundamental
Requirement Statement : We need to create application on Bank. In This application admin can create Branch, Bank, Customer, Account and other side customers can do transection between their account and show their balance in differnet account.

Brif Of Application : This application built using .Net core 6.0 and application have api to manage request and response. So in This Application Created different different module like below 
 1> Branch : using this module admin can create branch of bank
 2> Bank : using this module admin can create bank for specific branch as bank is always assoisiated with branch. 
 3> Customer : generallly bank have customers sales person Rm department and so on but here we consider customer only, through which user can create customer which is belong from perticular bank so this entity is unique for bank module as bank have unique customer identity.
 4> Account : now within bank, customer can have multipal bank account like saving, current ,Recurring , Fixed Deposite etc.. so this is multipal entity for customer by its account type but each account has single accounttype entity so this is also handle in application 
  so lets say customer "sam" come to bank and want to open account so he may have saving ,current , recurring account within bank. 
 5> Transection : now this module contain daily transection entry suppose transection from customer account "a" to account "b" or transection from customer account "a" to customer two account "b" this entity will have this kind of one way entry in this module. in back scene it will increment and decrement amount from respective account. 
 6> Transection history : this module is used to maintain history of transection between two account now here in this account we will have two entry for each trasectrion 
      1> source transection
      2> destination transection 
    now if admin/customer want to show history of transection then , they can see in two way
      1> transection by transection id individual transection can view
      2> transection by account id to see each account vise transection

so this is basic brif of application one will have better idea once we run the application. so lets start.
      
# TechStack which is required to run application

  .Net Core 6.0
  MediatR 12.0.1
  FluentValidation 11.5.1
  Entity Framework Core 7.0.3
  Microsoft.EntityFrameworkCore.InMemory 7.0.3
  Shouldly 4.1.0
  xunit 2.4.1

# IDE for application
  Visual Studio 2022
  SQL Server 2019
  Visual Code (Optional)

# Find below packages that needs to be install to run application

    FluentValidation 11.5.1
    FluentValidation.DependencyInjectionExtensions 11.5.1
    MediatR 12.0.1
    MediatR.Extensions.Microsoft.DependencyInjection 11.0.0
    Microsoft.EntityFrameworkCore 7.0.3
    Microsoft.EntityFrameworkCore.SqlServer 7.0.3
    Microsoft.EntityFrameworkCore.Tools 7.0.3
    Newtonsoft.Json 13.0.2
    Microsoft.EntityFrameworkCore.InMemory 7.0.3
    Shouldly 4.1.0
    xunit 2.4.1
    xunit.runner.visualstudio 2.4.3
    
# Project Structure
    Bank.ERP.sln
        Bank.Application
            Behaviour
            Container
            Controllers
            Extention
            SystemActors
                AccountFeature
                    Command
                    CommandHandler
                    Query
                    QueryHandler
                    BankFeature
                    -----
                    BranchFeature
                    -----
                    CustomerFeature
                    -----
                    TransectionFeatrure
                    -----
                    TransectionHistoryFeature
                    Query
                    QueryHandler
            Validators
        Bank.Core
            Context
            Entity
            Interface
            Migration (Optional one can delete and again migrate)
            Repository
            ViewModel
        Bank.Domain
            Nothing inside this but 
            if we want to integrate Thirdparty message handler then we can do it over her
        Bank.InfraStructure
            Enum
            Extention
        Bank.XunitTest.Test
            Infrastructure
            TestList

# How to run application
  Open Visual Studio
  Build solution it will download required package
  Run attached SQlscript in Database or Open terminal , run migrartion script 1> add-migration "initial" 2> update-database, it will create database automatically in SQL
  now run application on IIS it will show swagger page with apis as per requirement , here there is no any authentication
  now if you want to see log of logger then need to run application by selecting project name and it will run on kestral through which we can see our logging behaviour logs in command prompt

  Happy Coding.  


    
