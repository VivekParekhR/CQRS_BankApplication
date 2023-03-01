# CQRS_BankApplication
    This is the application of Bank with using CQRS(Command Query Responsibility Segregation) is a pattern that separates the responsibility for handling read and write operations. 
    In this pattern, the write operations are handled by Commands, and read operations are handled by Queries.

    In our example, we will be using Mediator pattern to implement the CQRS and Clean architecture. Mediator pattern is a behavioural design pattern that allows objects to communicate with each other through a mediator object, which centralizes communication between objects and decouples them from each other.

# Application Fundamental
    Requirement Statement: We need to create application on Bank. In This application admin can create Branch, Bank, Customer, Account and other side customers can do Transaction between their account and show their balance in different account.

    Brief Of Application : This application built using .Net core 6.0 and application have api to manage request and response. So in This Application Created different module like below 
    
    1> Branch : using this module admin can create branch of bank
    
    2> Bank : using this module admin can create bank for specific branch as bank is always associated with branch. 
    
    3> Customer : generally bank have customers sales person Rm department and so on but here we consider customer only, through which user can create customer which is belong from particular bank so this entity is unique for bank module as bank have unique customer identity.
    
    4> Account: now within bank, customer can have multiple bank account like saving, current ,Recurring , Fixed Deposited etc.. so this is multiple entity for customer by its account type but each account has single account type entity so this is also handle in application 
    so lets say customer "sam" come to bank and want to open account so he may have saving, current, recurring account within bank. 
    
    5> Transaction : now this module contain daily Transaction entry suppose Transaction from customer account "a" to account "b" or Transaction from customer account "a" to customer two account "b" this entity will have this kind of one way entry in this module. in back scene it will increment and decrement amount from respective account. 
    
    6> Transaction history : this module is used to maintain history of Transaction between two account now here in this account we will have two entry for each transaction 
        1> source Transaction
        2> destination Transaction 
    now if admin/customer want to show history of Transaction then , they can see in two way
        1> Transaction by Transaction id individual Transaction can view
        2> Transaction by account id to see each account vies Transaction

    so this is basic brief of application one will have better idea once we run the application. so lets start.
      
# Tec Stack which is required to run application
    
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
            Extension
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
                    TransactionFeatrure
                    -----
                    TransactionHistoryFeature
                    Query
                    QueryHandler
            Validators
        Bank.Core
            Context
            Entity
            Interface
            Migration (Optional one can delete and again migrate)
            Repository
            View Model
        Bank. Domain
            Nothing inside this but 
            if we want to integrate Third-party message handler then we can do it over her
        Bank.Infrastructure
            Enum
            Extension
        Bank.XunitTest.Test
            Infrastructure
            Test List

# How to run application
    1> Open Visual Studio
    2> Build solution it will download required package
    3> Run attached SQL script in Database or Open terminal , run migration script 1> add-migration "initial" 2> update-database, it will create database automatically in SQL
    4> now run application on IIS it will show swagger page with apis as per requirement, here there is no any authentication
    5> now if you want to see log of logger then need to run application by selecting project name and it will run on kestrel through which we can see our logging behaviour logs in command prompt

Happy Coding.  


    
