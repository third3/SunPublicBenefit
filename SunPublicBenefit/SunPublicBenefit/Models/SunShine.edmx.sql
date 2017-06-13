
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/12/2017 16:16:13
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

IF OBJECT_ID(N'[dbo].[FK_RoleUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User1Set] DROP CONSTRAINT [FK_RoleUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_User1PublicBenefitRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PublicBenefitRecordSet] DROP CONSTRAINT [FK_User1PublicBenefitRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_User1UserApprove]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserApproveSet] DROP CONSTRAINT [FK_User1UserApprove];
GO
IF OBJECT_ID(N'[dbo].[FK_User1DoNationRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DoNationRecordSet] DROP CONSTRAINT [FK_User1DoNationRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectDoNationRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DoNationRecordSet] DROP CONSTRAINT [FK_ProjectDoNationRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectProjectRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectRecordSet] DROP CONSTRAINT [FK_ProjectProjectRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectFinance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FinanceSet] DROP CONSTRAINT [FK_ProjectFinance];
GO
IF OBJECT_ID(N'[dbo].[FK_PublicBenefitPublicBenefitRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PublicBenefitRecordSet] DROP CONSTRAINT [FK_PublicBenefitPublicBenefitRecord];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[User1Set]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User1Set];
GO
IF OBJECT_ID(N'[dbo].[ProjectSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectSet];
GO
IF OBJECT_ID(N'[dbo].[ProjectRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectRecordSet];
GO
IF OBJECT_ID(N'[dbo].[FinanceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FinanceSet];
GO
IF OBJECT_ID(N'[dbo].[PublicBenefitRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PublicBenefitRecordSet];
GO
IF OBJECT_ID(N'[dbo].[PublicBenefitSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PublicBenefitSet];
GO
IF OBJECT_ID(N'[dbo].[RoleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleSet];
GO
IF OBJECT_ID(N'[dbo].[DoNationRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DoNationRecordSet];
GO
IF OBJECT_ID(N'[dbo].[UserApproveSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserApproveSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'User1Set'
CREATE TABLE [dbo].[User1Set] (
    [ID] nvarchar(20)  NOT NULL,
    [UserName] nvarchar(20)  NOT NULL,
    [UserPassword] nvarchar(20)  NOT NULL,
    [Role_ID] nvarchar(20)  NULL
);
GO

-- Creating table 'ProjectSet'
CREATE TABLE [dbo].[ProjectSet] (
    [ID] nvarchar(20)  NOT NULL,
    [ProjectName] nvarchar(50)  NOT NULL,
    [StartProjectTime] datetime  NOT NULL,
    [EndProjectTime] datetime  NOT NULL,
    [Moneyd] decimal(11,2)  NOT NULL,
    [Isstatus] smallint  NOT NULL,
    [UserNumber] int  NOT NULL,
    [Details] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProjectRecordSet'
CREATE TABLE [dbo].[ProjectRecordSet] (
    [ID] nvarchar(20)  NOT NULL,
    [Project_ID] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'FinanceSet'
CREATE TABLE [dbo].[FinanceSet] (
    [ID] nvarchar(20)  NOT NULL,
    [PreMoney] decimal(11,2)  NOT NULL,
    [IsIn] bit  NOT NULL,
    [MoneyL] decimal(11,2)  NOT NULL,
    [OutMoney] decimal(11,2)  NOT NULL,
    [LDateTime] datetime  NOT NULL,
    [Project_ID] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'PublicBenefitRecordSet'
CREATE TABLE [dbo].[PublicBenefitRecordSet] (
    [ID] nvarchar(20)  NOT NULL,
    [User1_ID] nvarchar(20)  NOT NULL,
    [PublicBenefit_ID] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'PublicBenefitSet'
CREATE TABLE [dbo].[PublicBenefitSet] (
    [ID] nvarchar(20)  NOT NULL,
    [BenefitName] nvarchar(50)  NOT NULL,
    [IsOnLine] bit  NOT NULL,
    [ApplyStartDate] datetime  NULL,
    [Site] nvarchar(100)  NULL,
    [ApplyAbortDate] datetime  NOT NULL,
    [ApplyCount] int  NOT NULL,
    [ActivityProfile] nvarchar(200)  NULL,
    [ConsentApply] bit  NOT NULL
);
GO

-- Creating table 'RoleSet'
CREATE TABLE [dbo].[RoleSet] (
    [ID] nvarchar(20)  NOT NULL,
    [RoleName] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'DoNationRecordSet'
CREATE TABLE [dbo].[DoNationRecordSet] (
    [ID] nvarchar(20)  NOT NULL,
    [DonationDate] nvarchar(max)  NOT NULL,
    [DonationAmout] nvarchar(max)  NOT NULL,
    [User1_ID] nvarchar(20)  NOT NULL,
    [Project_ID] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'UserApproveSet'
CREATE TABLE [dbo].[UserApproveSet] (
    [ID] nvarchar(20)  NOT NULL,
    [RealName] nvarchar(10)  NOT NULL,
    [IdentityNumber] nchar(18)  NOT NULL,
    [User1_ID] nvarchar(20)  NOT NULL
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

-- Creating primary key on [ID] in table 'RoleSet'
ALTER TABLE [dbo].[RoleSet]
ADD CONSTRAINT [PK_RoleSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DoNationRecordSet'
ALTER TABLE [dbo].[DoNationRecordSet]
ADD CONSTRAINT [PK_DoNationRecordSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserApproveSet'
ALTER TABLE [dbo].[UserApproveSet]
ADD CONSTRAINT [PK_UserApproveSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Role_ID] in table 'User1Set'
ALTER TABLE [dbo].[User1Set]
ADD CONSTRAINT [FK_RoleUser1]
    FOREIGN KEY ([Role_ID])
    REFERENCES [dbo].[RoleSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleUser1'
CREATE INDEX [IX_FK_RoleUser1]
ON [dbo].[User1Set]
    ([Role_ID]);
GO

-- Creating foreign key on [User1_ID] in table 'PublicBenefitRecordSet'
ALTER TABLE [dbo].[PublicBenefitRecordSet]
ADD CONSTRAINT [FK_User1PublicBenefitRecord]
    FOREIGN KEY ([User1_ID])
    REFERENCES [dbo].[User1Set]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User1PublicBenefitRecord'
CREATE INDEX [IX_FK_User1PublicBenefitRecord]
ON [dbo].[PublicBenefitRecordSet]
    ([User1_ID]);
GO

-- Creating foreign key on [User1_ID] in table 'UserApproveSet'
ALTER TABLE [dbo].[UserApproveSet]
ADD CONSTRAINT [FK_User1UserApprove]
    FOREIGN KEY ([User1_ID])
    REFERENCES [dbo].[User1Set]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User1UserApprove'
CREATE INDEX [IX_FK_User1UserApprove]
ON [dbo].[UserApproveSet]
    ([User1_ID]);
GO

-- Creating foreign key on [User1_ID] in table 'DoNationRecordSet'
ALTER TABLE [dbo].[DoNationRecordSet]
ADD CONSTRAINT [FK_User1DoNationRecord]
    FOREIGN KEY ([User1_ID])
    REFERENCES [dbo].[User1Set]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User1DoNationRecord'
CREATE INDEX [IX_FK_User1DoNationRecord]
ON [dbo].[DoNationRecordSet]
    ([User1_ID]);
GO

-- Creating foreign key on [Project_ID] in table 'DoNationRecordSet'
ALTER TABLE [dbo].[DoNationRecordSet]
ADD CONSTRAINT [FK_ProjectDoNationRecord]
    FOREIGN KEY ([Project_ID])
    REFERENCES [dbo].[ProjectSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectDoNationRecord'
CREATE INDEX [IX_FK_ProjectDoNationRecord]
ON [dbo].[DoNationRecordSet]
    ([Project_ID]);
GO

-- Creating foreign key on [Project_ID] in table 'ProjectRecordSet'
ALTER TABLE [dbo].[ProjectRecordSet]
ADD CONSTRAINT [FK_ProjectProjectRecord]
    FOREIGN KEY ([Project_ID])
    REFERENCES [dbo].[ProjectSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectProjectRecord'
CREATE INDEX [IX_FK_ProjectProjectRecord]
ON [dbo].[ProjectRecordSet]
    ([Project_ID]);
GO

-- Creating foreign key on [Project_ID] in table 'FinanceSet'
ALTER TABLE [dbo].[FinanceSet]
ADD CONSTRAINT [FK_ProjectFinance]
    FOREIGN KEY ([Project_ID])
    REFERENCES [dbo].[ProjectSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectFinance'
CREATE INDEX [IX_FK_ProjectFinance]
ON [dbo].[FinanceSet]
    ([Project_ID]);
GO

-- Creating foreign key on [PublicBenefit_ID] in table 'PublicBenefitRecordSet'
ALTER TABLE [dbo].[PublicBenefitRecordSet]
ADD CONSTRAINT [FK_PublicBenefitPublicBenefitRecord]
    FOREIGN KEY ([PublicBenefit_ID])
    REFERENCES [dbo].[PublicBenefitSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PublicBenefitPublicBenefitRecord'
CREATE INDEX [IX_FK_PublicBenefitPublicBenefitRecord]
ON [dbo].[PublicBenefitRecordSet]
    ([PublicBenefit_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------