USE LibraryDB;
GO

CREATE TABLE Books (
    Id      INT IDENTITY(1,1) PRIMARY KEY,  -- Chave primária autoincrementada
    Title   NVARCHAR(255) NOT NULL,         -- Título do livro
    Author  NVARCHAR(255) NOT NULL,         -- Autor do livro
    Year    INT NOT NULL                    -- Ano de publicação
);
GO