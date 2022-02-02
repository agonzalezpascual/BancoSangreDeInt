CREATE TABLE [dbo].[Donacion] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [DNI]          CHAR (9)     NOT NULL,
    [CodSanitario] CHAR (5)     NOT NULL,
    [centro]       VARCHAR (50) NULL,
    [fecha]        VARCHAR (50) NULL,
    [cantidad]     VARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CodSan] FOREIGN KEY ([CodSanitario]) REFERENCES [dbo].[Sanitario] ([CodSanitario])
);