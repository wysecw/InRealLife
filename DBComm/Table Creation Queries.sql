-- create scenario table
/*

CREATE TABLE [dbo].[Scenario] (
    [ScenarioID]          int           NOT NULL IDENTITY(1,1),
    [ScenarioName]        VARCHAR (30)  NOT NULL,
    [ScenarioDescription] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Scenario] PRIMARY KEY CLUSTERED ([ScenarioID] ASC));

*/


-- create stage table
/*

CREATE TABLE [dbo].[Stage] (
    [StageID]          int           NOT NULL IDENTITY(1,1),
    [ScenarioID]       int           NULL,
    [StageName]        VARCHAR (30)  NOT NULL,
    [AudioFilePath]    VARCHAR (50)  NULL,
    [ImageFilePath]    VARCHAR (50)  NULL,
    [StageDescription] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Stage] PRIMARY KEY CLUSTERED ([StageID] ASC),
    CONSTRAINT [FK_Stage_Scenario] FOREIGN KEY ([ScenarioID]) REFERENCES [dbo].[Scenario] ([ScenarioID]) ON DELETE CASCADE);

*/


-- create answer table
/*

CREATE TABLE [dbo].[Answer] (
    [AnswerID]          int           NOT NULL IDENTITY(1,1),
    [StageID]           int           NULL,
    [AnswerName]        VARCHAR (30)  NOT NULL,
    [AnswerDescription] VARCHAR (MAX) NULL,
    [NextStageID]       int           NULL,
    CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED ([AnswerID] ASC),
    CONSTRAINT [FK_Answer_Stage] FOREIGN KEY ([StageID]) REFERENCES [dbo].[Stage] ([StageID]) ON DELETE CASCADE);

*/