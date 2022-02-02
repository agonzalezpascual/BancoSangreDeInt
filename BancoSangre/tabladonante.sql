CREATE TABLE [dbo].[Donante] (
    [DNI]        CHAR (9)     NOT NULL,
    [nombre]     VARCHAR (50) NULL,
    [apellido]   VARCHAR (50) NULL,
    [direccion]  VARCHAR (50) NULL,
    [telefono]   CHAR (9)     NULL,
    [nacimiento] CHAR (10)     NULL,
    [email]      VARCHAR (25)   NULL,
    [grupo]      VARCHAR (2)  NULL,
    [rh]         CHAR (1)     NULL,
    PRIMARY KEY CLUSTERED ([DNI] ASC)
);