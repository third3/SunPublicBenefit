
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/07/2017 16:48:26
-- Generated from EDMX file: C:\Users\zero\Source\Repos\SunPublicBenefit\SunPublicBenefit\SunPublicBenefit\Models\SunShine.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SunPublicBenefit];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'User1Set'
CREATE TABLE [dbo].[User1Set] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(20)  NOT NULL,
    [UserPassword] nvarchar(20)  NOT NULL,
    [RoleID] int  NOT NULL,
    [RoleName] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'ProjectSet'
CREATE TABLE [dbo].[ProjectSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ProjectName] nvarchar(50)  NOT NULL,
    [UserID] int  NOT NULL,
    [UserName] nvarchar(20)  NOT NULL,
    [StartProjectTime] datetime  NOT NULL,
    [EndProjectTime] datetime  NOT NULL,
    [Moneyd] decimal(11,2)  NOT NULL,
    [Isstatus] smallint  NOT NULL,
    [UserNumber] int  NOT NULL
);
GO

-- Creating table 'ProjectRecordSet'
CREATE TABLE [dbo].[ProjectRecordSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ProjectID] int  NOT NULL
);
GO

-- Creating table 'FinanceSet'
CREATE TABLE [dbo].[FinanceSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PreMoney] decimal(11,2)  NOT NULL,
    [IsIn] bit  NOT NULL,
    [MoneyL] decimal(11,2)  NOT NULL,
    [UserID] int  NOT NULL,
    [ProjectID] int  NOT NULL,
    [OutMoney] decimal(11,2)  NOT NULL,
    [UserName] nvarchar(20)  NOT NULL,
    [ProjectName] nvarchar(50)  NOT NULL,
    [LDateTime] datetime  NOT NULL
);
GO

-- Creating table 'PublicBenefitRecordSet'
CREATE TABLE [dbo].[PublicBenefitRecordSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(20)  NOT NULL,
    [UserID] int  NOT NULL
);
GO

-- Creating table 'PublicBenefitSet'
CREATE TABLE [dbo].[PublicBenefitSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [BenefitName] nvarchar(50)  NOT NULL,
    [BenefitInitiator] nvarchar(50)  NOT NULL,
    [IsOnLine] bit  NOT NULL,
    [ApplyStartDate] datetime  NULL,
    [Site] nvarchar(100)  NULL,
    [ApplyAbortDate] datetime  NOT NULL,
    [ApplyCount] int  NOT NULL,
    [ActivityProfile] nvarchar(200)  NULL,
    [UserID] int  NOT NULL,
    [ConsentApply] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'User1Set'
ALTER TABLE [dbo].[User1Set]
ADD CONSTRAINT [PK_User1Set]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [PK_ProjectSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ProjectRecordSet'
ALTER TABLE [dbo].[ProjectRecordSet]
ADD CONSTRAINT [PK_ProjectRecordSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FinanceSet'
ALTER TABLE [dbo].[FinanceSet]
ADD CONSTRAINT [PK_FinanceSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PublicBenefitRecordSet'
ALTER TABLE [dbo].[PublicBenefitRecordSet]
ADD CONSTRAINT [PK_PublicBenefitRecordSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PublicBenefitSet'
ALTER TABLE [dbo].[PublicBenefitSet]
ADD CONSTRAINT [PK_PublicBenefitSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------