USE BDPizza;


CREATE TABLE [dbo].[Pizza]
(
    [IdPizza]      INT IDENTITY (1,1) NOT NULL,
    [Nome]         VARCHAR(100)       NOT NULL,
    [Ingredientes] VARCHAR(255)       NOT NULL,
    [Valor]        INT                NOT NULL,
    CONSTRAINT [PK_Pizza] PRIMARY KEY CLUSTERED
        ([IdPizza] ASC)
);

SELECT *
FROM Pizza;

