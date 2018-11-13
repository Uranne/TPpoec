
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/13/2018 12:11:55
-- Generated from EDMX file: C:\Users\M.PETIT\source\repos\TPpoec\eCommerce\TireLireCorps.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBTirelire];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO
IF SCHEMA_ID(N'Tab') IS NULL EXECUTE(N'CREATE SCHEMA [Tab]');
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

-- Creating table 'Client'
CREATE TABLE [Tab].[Client] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(20)  NOT NULL,
    [Prenom] nvarchar(20)  NOT NULL,
    [Skin] nvarchar(10)  NOT NULL,
    [DateNaissance] datetime  NOT NULL,
    [Status] bit  NOT NULL,
    [Telephone] nvarchar(13)  NOT NULL,
    [Identifiant] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [email] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Commande'
CREATE TABLE [Tab].[Commande] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateCommande] datetime  NOT NULL,
    [DatePreparation] datetime  NOT NULL,
    [DateEnvoi] datetime  NOT NULL,
    [IdClient] int  NOT NULL,
    [IdAdresse] int  NOT NULL
);
GO

-- Creating table 'DetailCommande'
CREATE TABLE [Tab].[DetailCommande] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PrixDiscount] decimal(18,0)  NOT NULL,
    [Qty] bigint  NOT NULL,
    [IdCommande] int  NOT NULL,
    [IdProduit] int  NOT NULL
);
GO

-- Creating table 'Produit'
CREATE TABLE [Tab].[Produit] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(20)  NOT NULL,
    [Poids] float  NOT NULL,
    [Prix] decimal(18,0)  NOT NULL,
    [Status] bit  NOT NULL,
    [Hauteur] bigint  NOT NULL,
    [Longueur] bigint  NOT NULL,
    [Largeur] bigint  NOT NULL,
    [Capacite] float  NOT NULL,
    [Description] nvarchar(256)  NOT NULL,
    [Couleur] nvarchar(20)  NOT NULL,
    [IdFabricant] int  NOT NULL
);
GO

-- Creating table 'AdresseClient'
CREATE TABLE [Tab].[AdresseClient] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Voie] nvarchar(50)  NOT NULL,
    [numero] nvarchar(10)  NOT NULL,
    [codePostal] nvarchar(10)  NOT NULL,
    [Ville] nvarchar(20)  NOT NULL,
    [Pays] nvarchar(20)  NOT NULL,
    [InfoSup] nvarchar(10)  NOT NULL,
    [Nom] nvarchar(50)  NOT NULL,
    [IdClient] int  NOT NULL
);
GO

-- Creating table 'Fabriquant'
CREATE TABLE [Tab].[Fabriquant] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(20)  NOT NULL,
    [Description] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'Photo'
CREATE TABLE [Tab].[Photo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ImagePath] nvarchar(50)  NOT NULL,
    [Type] nvarchar(20)  NOT NULL,
    [IdProduit] int  NOT NULL
);
GO

-- Creating table 'Avis'
CREATE TABLE [Tab].[Avis] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Message] nvarchar(512)  NOT NULL,
    [IdModerateur] int  NOT NULL,
    [IdProduit] int  NOT NULL,
    [IdClient] int  NOT NULL,
    [Note] smallint  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'BackOffice'
CREATE TABLE [Tab].[BackOffice] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Identifiant] nvarchar(50)  NOT NULL,
    [password] nvarchar(50)  NOT NULL,
    [role] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'AdresseFabricant'
CREATE TABLE [Tab].[AdresseFabricant] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Voie] nvarchar(50)  NOT NULL,
    [numero] nvarchar(10)  NOT NULL,
    [codePostal] nvarchar(10)  NOT NULL,
    [Ville] nvarchar(20)  NOT NULL,
    [Pays] nvarchar(20)  NOT NULL,
    [InfoSup] nvarchar(10)  NOT NULL,
    [Nom] nvarchar(50)  NOT NULL,
    [IdFabricant] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Client'
ALTER TABLE [Tab].[Client]
ADD CONSTRAINT [PK_Client]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Commande'
ALTER TABLE [Tab].[Commande]
ADD CONSTRAINT [PK_Commande]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetailCommande'
ALTER TABLE [Tab].[DetailCommande]
ADD CONSTRAINT [PK_DetailCommande]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Produit'
ALTER TABLE [Tab].[Produit]
ADD CONSTRAINT [PK_Produit]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdresseClient'
ALTER TABLE [Tab].[AdresseClient]
ADD CONSTRAINT [PK_AdresseClient]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Fabriquant'
ALTER TABLE [Tab].[Fabriquant]
ADD CONSTRAINT [PK_Fabriquant]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Photo'
ALTER TABLE [Tab].[Photo]
ADD CONSTRAINT [PK_Photo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Avis'
ALTER TABLE [Tab].[Avis]
ADD CONSTRAINT [PK_Avis]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BackOffice'
ALTER TABLE [Tab].[BackOffice]
ADD CONSTRAINT [PK_BackOffice]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdresseFabricant'
ALTER TABLE [Tab].[AdresseFabricant]
ADD CONSTRAINT [PK_AdresseFabricant]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdClient] in table 'Commande'
ALTER TABLE [Tab].[Commande]
ADD CONSTRAINT [FK_ClientCommande]
    FOREIGN KEY ([IdClient])
    REFERENCES [Tab].[Client]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientCommande'
CREATE INDEX [IX_FK_ClientCommande]
ON [Tab].[Commande]
    ([IdClient]);
GO

-- Creating foreign key on [IdCommande] in table 'DetailCommande'
ALTER TABLE [Tab].[DetailCommande]
ADD CONSTRAINT [FK_CommandeDetailCommande]
    FOREIGN KEY ([IdCommande])
    REFERENCES [Tab].[Commande]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommandeDetailCommande'
CREATE INDEX [IX_FK_CommandeDetailCommande]
ON [Tab].[DetailCommande]
    ([IdCommande]);
GO

-- Creating foreign key on [IdProduit] in table 'DetailCommande'
ALTER TABLE [Tab].[DetailCommande]
ADD CONSTRAINT [FK_ProduitDetailCommande]
    FOREIGN KEY ([IdProduit])
    REFERENCES [Tab].[Produit]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduitDetailCommande'
CREATE INDEX [IX_FK_ProduitDetailCommande]
ON [Tab].[DetailCommande]
    ([IdProduit]);
GO

-- Creating foreign key on [IdClient] in table 'Avis'
ALTER TABLE [Tab].[Avis]
ADD CONSTRAINT [FK_ClientAvis]
    FOREIGN KEY ([IdClient])
    REFERENCES [Tab].[Client]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientAvis'
CREATE INDEX [IX_FK_ClientAvis]
ON [Tab].[Avis]
    ([IdClient]);
GO

-- Creating foreign key on [IdFabricant] in table 'Produit'
ALTER TABLE [Tab].[Produit]
ADD CONSTRAINT [FK_FabriquantProduit]
    FOREIGN KEY ([IdFabricant])
    REFERENCES [Tab].[Fabriquant]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FabriquantProduit'
CREATE INDEX [IX_FK_FabriquantProduit]
ON [Tab].[Produit]
    ([IdFabricant]);
GO

-- Creating foreign key on [IdProduit] in table 'Photo'
ALTER TABLE [Tab].[Photo]
ADD CONSTRAINT [FK_ProduitPhoto]
    FOREIGN KEY ([IdProduit])
    REFERENCES [Tab].[Produit]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduitPhoto'
CREATE INDEX [IX_FK_ProduitPhoto]
ON [Tab].[Photo]
    ([IdProduit]);
GO

-- Creating foreign key on [IdProduit] in table 'Avis'
ALTER TABLE [Tab].[Avis]
ADD CONSTRAINT [FK_ProduitAvis]
    FOREIGN KEY ([IdProduit])
    REFERENCES [Tab].[Produit]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduitAvis'
CREATE INDEX [IX_FK_ProduitAvis]
ON [Tab].[Avis]
    ([IdProduit]);
GO

-- Creating foreign key on [IdAdresse] in table 'Commande'
ALTER TABLE [Tab].[Commande]
ADD CONSTRAINT [FK_AdresseCommande]
    FOREIGN KEY ([IdAdresse])
    REFERENCES [Tab].[AdresseClient]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdresseCommande'
CREATE INDEX [IX_FK_AdresseCommande]
ON [Tab].[Commande]
    ([IdAdresse]);
GO

-- Creating foreign key on [IdClient] in table 'AdresseClient'
ALTER TABLE [Tab].[AdresseClient]
ADD CONSTRAINT [FK_ClientAdresse]
    FOREIGN KEY ([IdClient])
    REFERENCES [Tab].[Client]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientAdresse'
CREATE INDEX [IX_FK_ClientAdresse]
ON [Tab].[AdresseClient]
    ([IdClient]);
GO

-- Creating foreign key on [IdFabricant] in table 'AdresseFabricant'
ALTER TABLE [Tab].[AdresseFabricant]
ADD CONSTRAINT [FK_FabriquantAdresseFabricant]
    FOREIGN KEY ([IdFabricant])
    REFERENCES [Tab].[Fabriquant]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FabriquantAdresseFabricant'
CREATE INDEX [IX_FK_FabriquantAdresseFabricant]
ON [Tab].[AdresseFabricant]
    ([IdFabricant]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------