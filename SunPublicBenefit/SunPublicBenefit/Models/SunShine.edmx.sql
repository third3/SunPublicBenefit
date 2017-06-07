
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/07/2017 17:21:59
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

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'User1Set'
CREATE TABLE [dbo].[User1Set] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(20)  NOT NULL,
    [UserPassword] nvarchar(20)  NOT NULL,
    [Project_ID] int  NOT NULL,
    [DoNationRecord_ID] int  NOT NULL,
    [PublicBenefitRecord_ID] int  NOT NULL,
    [PublicBenefit_ID] int  NOT NULL
);
GO

-- Creating table 'ProjectSet'
CREATE TABLE [dbo].[ProjectSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ProjectName] nvarchar(50)  NOT NULL,
    [StartProjectTime] datetime  NOT NULL,
    [EndProjectTime] datetime  NOT NULL,
    [Moneyd] decimal(11,2)  NOT NULL,
    [Isstatus] smallint  NOT NULL,
    [UserNumber] int  NOT NULL,
    [ProjectRecord_ID] int  NOT NULL,
    [Finance_ID] int  NOT NULL,
    [DoNationRecord_ID] int  NOT NULL
);
GO

-- Creating table 'ProjectRecordSet'
CREATE TABLE [dbo].[ProjectRecordSet] (
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'FinanceSet'
CREATE TABLE [dbo].[FinanceSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PreMoney] decimal(11,2)  NOT NULL,
    [IsIn] bit  NOT NULL,
    [MoneyL] decimal(11,2)  NOT NULL,
    [OutMoney] decimal(11,2)  NOT NULL,
    [LDateTime] datetime  NOT NULL
);
GO

-- Creating table 'PublicBenefitRecordSet'
CREATE TABLE [dbo].[PublicBenefitRecordSet] (
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'PublicBenefitSet'
CREATE TABLE [dbo].[PublicBenefitSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [BenefitName] nvarchar(50)  NOT NULL,
    [IsOnLine] bit  NOT NULL,
    [ApplyStartDate] datetime  NULL,
    [Site] nvarchar(100)  NULL,
    [ApplyAbortDate] datetime  NOT NULL,
    [ApplyCount] int  NOT NULL,
    [ActivityProfile] nvarchar(200)  NULL,
    [ConsentApply] bit  NOT NULL,
    [PublicBenefitRecord_ID] int  NOT NULL
);
GO

-- Creating table 'RoleSet'
CREATE TABLE [dbo].[RoleSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(20)  NOT NULL,
    [User1_ID] int  NOT NULL
);
GO

-- Creating table 'DoNationRecordSet'
CREATE TABLE [dbo].[DoNationRecordSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DonationDate] nvarchar(max)  NOT NULL,
    [DonationAmout] nvarchar(max)  NOT NULL
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

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User1_ID] in table 'RoleSet'
ALTER TABLE [dbo].[RoleSet]
ADD CONSTRAINT [FK_User1Role]
    FOREIGN KEY ([User1_ID])
    REFERENCES [dbo].[User1Set]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User1Role'
CREATE INDEX [IX_FK_User1Role]
ON [dbo].[RoleSet]
    ([User1_ID]);
GO

-- Creating foreign key on [Project_ID] in table 'User1Set'
ALTER TABLE [dbo].[User1Set]
ADD CONSTRAINT [FK_ProjectUser1]
    FOREIGN KEY ([Project_ID])
    REFERENCES [dbo].[ProjectSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectUser1'
CREATE INDEX [IX_FK_ProjectUser1]
ON [dbo].[User1Set]
    ([Project_ID]);
GO

-- Creating foreign key on [ProjectRecord_ID] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [FK_ProjectRecordProject]
    FOREIGN KEY ([ProjectRecord_ID])
    REFERENCES [dbo].[ProjectRecordSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectRecordProject'
CREATE INDEX [IX_FK_ProjectRecordProject]
ON [dbo].[ProjectSet]
    ([ProjectRecord_ID]);
GO

-- Creating foreign key on [DoNationRecord_ID] in table 'User1Set'
ALTER TABLE [dbo].[User1Set]
ADD CONSTRAINT [FK_DoNationRecordUser1]
    FOREIGN KEY ([DoNationRecord_ID])
    REFERENCES [dbo].[DoNationRecordSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoNationRecordUser1'
CREATE INDEX [IX_FK_DoNationRecordUser1]
ON [dbo].[User1Set]
    ([DoNationRecord_ID]);
GO

-- Creating foreign key on [PublicBenefitRecord_ID] in table 'User1Set'
ALTER TABLE [dbo].[User1Set]
ADD CONSTRAINT [FK_PublicBenefitRecordUser1]
    FOREIGN KEY ([PublicBenefitRecord_ID])
    REFERENCES [dbo].[PublicBenefitRecordSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PublicBenefitRecordUser1'
CREATE INDEX [IX_FK_PublicBenefitRecordUser1]
ON [dbo].[User1Set]
    ([PublicBenefitRecord_ID]);
GO

-- Creating foreign key on [PublicBenefitRecord_ID] in table 'PublicBenefitSet'
ALTER TABLE [dbo].[PublicBenefitSet]
ADD CONSTRAINT [FK_PublicBenefitRecordPublicBenefit]
    FOREIGN KEY ([PublicBenefitRecord_ID])
    REFERENCES [dbo].[PublicBenefitRecordSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PublicBenefitRecordPublicBenefit'
CREATE INDEX [IX_FK_PublicBenefitRecordPublicBenefit]
ON [dbo].[PublicBenefitSet]
    ([PublicBenefitRecord_ID]);
GO

-- Creating foreign key on [Finance_ID] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [FK_FinanceProject]
    FOREIGN KEY ([Finance_ID])
    REFERENCES [dbo].[FinanceSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FinanceProject'
CREATE INDEX [IX_FK_FinanceProject]
ON [dbo].[ProjectSet]
    ([Finance_ID]);
GO

-- Creating foreign key on [PublicBenefit_ID] in table 'User1Set'
ALTER TABLE [dbo].[User1Set]
ADD CONSTRAINT [FK_PublicBenefitUser1]
    FOREIGN KEY ([PublicBenefit_ID])
    REFERENCES [dbo].[PublicBenefitSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PublicBenefitUser1'
CREATE INDEX [IX_FK_PublicBenefitUser1]
ON [dbo].[User1Set]
    ([PublicBenefit_ID]);
GO

-- Creating foreign key on [DoNationRecord_ID] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [FK_DoNationRecordProject]
    FOREIGN KEY ([DoNationRecord_ID])
    REFERENCES [dbo].[DoNationRecordSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoNationRecordProject'
CREATE INDEX [IX_FK_DoNationRecordProject]
ON [dbo].[ProjectSet]
    ([DoNationRecord_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------