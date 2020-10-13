CREATE DATABASE [Memo_maslim];
GO

CREATE DATABASE [Memo_maslim];
GO

USE [Memo_maslim];
GO

CREATE TABLE [Syfte] (
[SyfteId] int NOT NULL IDENTITY,
[Topic] nvarchar(max) NOT NULL,
CONSTRAINT [PK_Syfte] PRIMARY KEY ([SyfteId])
);
GO

CREATE TABLE [Post] (
[PostId] int NOT NULL IDENTITY,
[SyfteId] int NOT NULL,
[Innehall] nvarchar(max),
[Title] nvarchar(max),
[Bild] nvarchar(max),
CONSTRAINT [OK_Post] PRIMARY KEY ([PostId]),
CONSTRAINT [FK_Post_Syfte_SyfteId] FOREIGN KEY ([SyfteId]) REFERENCES [Syfte] ([SyfteId]) ON DELETE CASCADE
);
GO

INSERT INTO [Syfte] (Topic) VALUES
('Privat'),
('Jobbrelaterat'),
('Fotografi')
GO