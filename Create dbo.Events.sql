USE [master]
GO

/****** Object: Table [dbo].[Events] Script Date: 31-03-2020 20:41:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Events] (
    [EventId]     INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NOT NULL,
    [Date]        DATETIME       NOT NULL,
    [StartTime]   DATETIME       NOT NULL,
    [Location]    NVARCHAR (MAX) NOT NULL,
    [Type]        INT            NOT NULL,
    [Duration]    INT            NOT NULL,
    [Description] NVARCHAR (50)  NULL,
    [Others]      NVARCHAR (500) NULL,
    [User_UserId] INT            NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_User_UserId]
    ON [dbo].[Events]([User_UserId] ASC);


GO
ALTER TABLE [dbo].[Events]
    ADD CONSTRAINT [PK_dbo.Events] PRIMARY KEY CLUSTERED ([EventId] ASC);


GO
ALTER TABLE [dbo].[Events]
    ADD CONSTRAINT [FK_dbo.Events_dbo.Users_User_UserId] FOREIGN KEY ([User_UserId]) REFERENCES [dbo].[Users] ([UserId]);


Insert into dbo.Events (Title, [Date], StartTime, [Location], [Type], [Duration] )
values ('First', '12-mar-2013', '12-mar-2013', 'Gurgoan', 1, 2);