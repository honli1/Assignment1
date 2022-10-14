
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/14/2022 11:51:57
-- Generated from EDMX file: C:\Users\20458\source\repos\Assignment1.4 - 副本\Assignment1\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FoodCalories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FoodCalories];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'FoodCalories'
CREATE TABLE [dbo].[FoodCalories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FoodCatergory] nvarchar(max)  NOT NULL,
    [CalorieAmount] nvarchar(max)  NOT NULL,
    [NutritionLevel] nvarchar(max)  NOT NULL,
    [FoodName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NutritionAdvices'
CREATE TABLE [dbo].[NutritionAdvices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AdviceTitle] nvarchar(max)  NOT NULL,
    [AdviceContent] nvarchar(max)  NOT NULL,
    [AdviceImage] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'FoodCalories'
ALTER TABLE [dbo].[FoodCalories]
ADD CONSTRAINT [PK_FoodCalories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NutritionAdvices'
ALTER TABLE [dbo].[NutritionAdvices]
ADD CONSTRAINT [PK_NutritionAdvices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------