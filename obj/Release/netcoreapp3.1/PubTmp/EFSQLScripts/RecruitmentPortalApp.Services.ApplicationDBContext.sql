IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [Discriminator] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [Jobs] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(max) NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [JobRoles] nvarchar(max) NULL,
        [Category] nvarchar(max) NULL,
        [ClosingDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Jobs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [OrganizationDocuments] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Url] nvarchar(max) NOT NULL,
        [Created_at] datetime2 NOT NULL,
        CONSTRAINT [PK_OrganizationDocuments] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [Stages] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [NumberOfQuestions] int NOT NULL,
        [Duration] nvarchar(max) NULL,
        [TotalScore] int NOT NULL,
        [Created_at] datetime2 NOT NULL,
        CONSTRAINT [PK_Stages] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [Profiles] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [MiddleName] nvarchar(max) NULL,
        [Gender] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [HighestEducation] nvarchar(max) NULL,
        [UserID] nvarchar(450) NULL,
        [Created_at] datetime2 NOT NULL,
        CONSTRAINT [PK_Profiles] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Profiles_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [StaffDocuments] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Url] nvarchar(max) NOT NULL,
        [UserID] nvarchar(450) NULL,
        [Created_at] datetime2 NOT NULL,
        CONSTRAINT [PK_StaffDocuments] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_StaffDocuments_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [Applications] (
        [Id] int NOT NULL IDENTITY,
        [FullName] nvarchar(max) NOT NULL,
        [Resume] nvarchar(max) NOT NULL,
        [Status] nvarchar(max) NULL,
        [Reason] nvarchar(max) NULL,
        [JobID] int NULL,
        [UserID] nvarchar(450) NULL,
        [Created_at] datetime2 NOT NULL,
        CONSTRAINT [PK_Applications] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Applications_Jobs_JobID] FOREIGN KEY ([JobID]) REFERENCES [Jobs] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Applications_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [JobStages] (
        [JobId] int NOT NULL,
        [StageId] int NOT NULL,
        CONSTRAINT [PK_JobStages] PRIMARY KEY ([JobId], [StageId]),
        CONSTRAINT [FK_JobStages_Jobs_JobId] FOREIGN KEY ([JobId]) REFERENCES [Jobs] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_JobStages_Stages_StageId] FOREIGN KEY ([StageId]) REFERENCES [Stages] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [Questions] (
        [Id] int NOT NULL IDENTITY,
        [Content] nvarchar(max) NOT NULL,
        [Type] nvarchar(max) NULL,
        [Point] int NOT NULL,
        [Active] nvarchar(max) NULL,
        [Created_at] datetime2 NOT NULL,
        [StagesId] int NULL,
        [StageId] int NULL,
        CONSTRAINT [PK_Questions] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Questions_Stages_StageId] FOREIGN KEY ([StageId]) REFERENCES [Stages] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [ScoreBoards] (
        [Id] int NOT NULL IDENTITY,
        [StageId] int NOT NULL,
        [ApplicationId] int NOT NULL,
        [Score] int NOT NULL,
        [Created_at] datetime2 NOT NULL,
        CONSTRAINT [PK_ScoreBoards] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ScoreBoards_Applications_ApplicationId] FOREIGN KEY ([ApplicationId]) REFERENCES [Applications] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ScoreBoards_Stages_StageId] FOREIGN KEY ([StageId]) REFERENCES [Stages] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [Answers] (
        [Id] int NOT NULL IDENTITY,
        [Content] nvarchar(max) NOT NULL,
        [IsCorrect] bit NOT NULL,
        [QuestionId] int NOT NULL,
        [Created_at] datetime2 NOT NULL,
        CONSTRAINT [PK_Answers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Answers_Questions_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Questions] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE TABLE [ApplicantResponses] (
        [Id] int NOT NULL IDENTITY,
        [Content] nvarchar(max) NOT NULL,
        [QuestionId] int NULL,
        [ApplicationId] int NULL,
        [Created_at] datetime2 NOT NULL,
        CONSTRAINT [PK_ApplicantResponses] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ApplicantResponses_Applications_ApplicationId] FOREIGN KEY ([ApplicationId]) REFERENCES [Applications] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ApplicantResponses_Questions_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Questions] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N'1', NULL, N'Admin', N'ADMIN'),
    (N'2', NULL, N'Applicant', N'APPLICANT'),
    (N'3', NULL, N'Onboarding', N'ONBOARDING'),
    (N'4', NULL, N'Staff', N'STAFF');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Discriminator', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Discriminator], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES (N'a18be9c0-aa65-4af8-bd17-00bd9344e575', 0, N'f16c5b97-3a0f-4b24-9d10-3ab6f48629b8', N'UserModel', N'admin@gmail.com', CAST(1 AS bit), CAST(0 AS bit), NULL, N'admin@gmail.com', N'admin', N'AQAAAAEAACcQAAAAEFTty5qTI0Hsibsg3YSNBcUbupDnV975z7Q+Hi80AW0gmQpN6uo5Vj/7ZXcVLjWc3A==', NULL, CAST(0 AS bit), N'', CAST(0 AS bit), N'admin');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Discriminator', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'RoleId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    INSERT INTO [AspNetUserRoles] ([UserId], [RoleId])
    VALUES (N'a18be9c0-aa65-4af8-bd17-00bd9344e575', N'1');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'RoleId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [IX_Answers_QuestionId] ON [Answers] ([QuestionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [IX_ApplicantResponses_ApplicationId] ON [ApplicantResponses] ([ApplicationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [IX_ApplicantResponses_QuestionId] ON [ApplicantResponses] ([QuestionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [IX_Applications_JobID] ON [Applications] ([JobID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [IX_Applications_UserID] ON [Applications] ([UserID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [IX_JobStages_StageId] ON [JobStages] ([StageId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [IX_Profiles_UserID] ON [Profiles] ([UserID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [IX_Questions_StageId] ON [Questions] ([StageId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [IX_ScoreBoards_ApplicationId] ON [ScoreBoards] ([ApplicationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [IX_ScoreBoards_StageId] ON [ScoreBoards] ([StageId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    CREATE INDEX [IX_StaffDocuments_UserID] ON [StaffDocuments] ([UserID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200514145652_Initial-DB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200514145652_Initial-DB', N'3.1.3');
END;

GO

