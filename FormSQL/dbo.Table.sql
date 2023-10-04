CREATE TABLE [dbo].[Table] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [SurName]  NVARCHAR (50) NULL,
    [Name]     NVARCHAR (50) NULL,
    [Patronym] NVARCHAR (50) NULL,
    [BirthDay] DATE          NULL,
    [AvgMark]  FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

