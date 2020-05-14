IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE TABLE [Jobs] (
        [Id] int NOT NULL IDENTITY,
        [Code] nvarchar(max) NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [Roles] nvarchar(max) NULL,
        [Category] nvarchar(max) NULL,
        [ClosingDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Jobs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE TABLE [JobStages] (
        [Id] int NOT NULL IDENTITY,
        [JobId] int NULL,
        [StageId] int NULL,
        CONSTRAINT [PK_JobStages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_JobStages_Jobs_JobId] FOREIGN KEY ([JobId]) REFERENCES [Jobs] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_JobStages_Stages_StageId] FOREIGN KEY ([StageId]) REFERENCES [Stages] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE TABLE [Questions] (
        [Id] int NOT NULL IDENTITY,
        [Content] nvarchar(max) NOT NULL,
        [Type] nvarchar(max) NULL,
        [Point] int NOT NULL,
        [Active] nvarchar(max) NULL,
        [StageId] int NULL,
        [Created_at] datetime2 NOT NULL,
        CONSTRAINT [PK_Questions] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Questions_Stages_StageId] FOREIGN KEY ([StageId]) REFERENCES [Stages] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE TABLE [ScoreBoards] (
        [Id] int NOT NULL IDENTITY,
        [StageId] int NULL,
        [ApplicationId] int NULL,
        [Score] int NOT NULL,
        [Created_at] datetime2 NOT NULL,
        CONSTRAINT [PK_ScoreBoards] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ScoreBoards_Applications_ApplicationId] FOREIGN KEY ([ApplicationId]) REFERENCES [Applications] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ScoreBoards_Stages_StageId] FOREIGN KEY ([StageId]) REFERENCES [Stages] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE TABLE [Answers] (
        [Id] int NOT NULL IDENTITY,
        [Content] nvarchar(max) NOT NULL,
        [IsCorrect] bit NOT NULL,
        [QuestionId] int NULL,
        [Created_at] datetime2 NOT NULL,
        CONSTRAINT [PK_Answers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Answers_Questions_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Questions] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Discriminator', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Discriminator], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES (N'a18be9c0-aa65-4af8-bd17-00bd9344e575', 0, N'10a12f53-af30-42f2-b7bb-686c971458be', N'UserModel', N'admin@gmail.com', CAST(1 AS bit), CAST(0 AS bit), NULL, N'admin@gmail.com', N'admin', N'AQAAAAEAACcQAAAAEOWlSmumgOn0wsb0VZQOQSKU9/EDrP37V0Cmvn9svlnHYiZKzs3wqq32v+AIIa8rJA==', NULL, CAST(0 AS bit), N'', CAST(0 AS bit), N'admin');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Discriminator', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'RoleId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    INSERT INTO [AspNetUserRoles] ([UserId], [RoleId])
    VALUES (N'a18be9c0-aa65-4af8-bd17-00bd9344e575', N'1');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'RoleId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_Answers_QuestionId] ON [Answers] ([QuestionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_ApplicantResponses_ApplicationId] ON [ApplicantResponses] ([ApplicationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_ApplicantResponses_QuestionId] ON [ApplicantResponses] ([QuestionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_Applications_JobID] ON [Applications] ([JobID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_Applications_UserID] ON [Applications] ([UserID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_JobStages_JobId] ON [JobStages] ([JobId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_JobStages_StageId] ON [JobStages] ([StageId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_Profiles_UserID] ON [Profiles] ([UserID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_Questions_StageId] ON [Questions] ([StageId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_ScoreBoards_ApplicationId] ON [ScoreBoards] ([ApplicationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_ScoreBoards_StageId] ON [ScoreBoards] ([StageId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    CREATE INDEX [IX_StaffDocuments_UserID] ON [StaffDocuments] ([UserID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511012131_Initial-CreateDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200511012131_Initial-CreateDB', N'3.1.3');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511154607_Modify-JobTable')
BEGIN
    UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'7f5ab9d3-f782-4bf1-a1ec-f1064006053a', [PasswordHash] = N'AQAAAAEAACcQAAAAENyBA6qUXsc3o/riV6Vd/aiijhOsx3cmZJ/IgFijvUNfTk3Bkp4jIFK4eGQumfCFqA=='
    WHERE [Id] = N'a18be9c0-aa65-4af8-bd17-00bd9344e575';
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511154607_Modify-JobTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200511154607_Modify-JobTable', N'3.1.3');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511161431_Modify-DBContext')
BEGIN
    ALTER TABLE [JobStages] DROP CONSTRAINT [FK_JobStages_Jobs_JobId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511161431_Modify-DBContext')
BEGIN
    ALTER TABLE [JobStages] DROP CONSTRAINT [FK_JobStages_Stages_StageId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511161431_Modify-DBContext')
BEGIN
    ALTER TABLE [JobStages] DROP CONSTRAINT [PK_JobStages];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511161431_Modify-DBContext')
BEGIN
    DROP INDEX [IX_JobStages_JobId] ON [JobStages];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511161431_Modify-DBContext')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[JobStages]') AND [c].[name] = N'Id');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [JobStages] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [JobStages] DROP COLUMN [Id];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511161431_Modify-DBContext')
BEGIN
    DROP INDEX [IX_JobStages_StageId] ON [JobStages];
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[JobStages]') AND [c].[name] = N'StageId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [JobStages] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [JobStages] ALTER COLUMN [StageId] int NOT NULL;
    CREATE INDEX [IX_JobStages_StageId] ON [JobStages] ([StageId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511161431_Modify-DBContext')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[JobStages]') AND [c].[name] = N'JobId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [JobStages] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [JobStages] ALTER COLUMN [JobId] int NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511161431_Modify-DBContext')
BEGIN
    ALTER TABLE [JobStages] ADD CONSTRAINT [PK_JobStages] PRIMARY KEY ([JobId], [StageId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511161431_Modify-DBContext')
BEGIN
    UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'39649594-4ede-49c1-b56d-7a5c4070861a', [PasswordHash] = N'AQAAAAEAACcQAAAAEKV4Su7B1xz5CBAma4Gl1bXWVo0e52R8HEgjLhN4uXYLsP32N32wVOsY5Ua/b1n8+w=='
    WHERE [Id] = N'a18be9c0-aa65-4af8-bd17-00bd9344e575';
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511161431_Modify-DBContext')
BEGIN
    ALTER TABLE [JobStages] ADD CONSTRAINT [FK_JobStages_Jobs_JobId] FOREIGN KEY ([JobId]) REFERENCES [Jobs] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511161431_Modify-DBContext')
BEGIN
    ALTER TABLE [JobStages] ADD CONSTRAINT [FK_JobStages_Stages_StageId] FOREIGN KEY ([StageId]) REFERENCES [Stages] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200511161431_Modify-DBContext')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200511161431_Modify-DBContext', N'3.1.3');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200512192250_Change-Column-Roles-in-Jobs')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'Roles');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Jobs] DROP COLUMN [Roles];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200512192250_Change-Column-Roles-in-Jobs')
BEGIN
    ALTER TABLE [Jobs] ADD [JobRoles] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200512192250_Change-Column-Roles-in-Jobs')
BEGIN
    UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'28b0b7e8-e9d2-49b1-b056-275eb932abc5', [PasswordHash] = N'AQAAAAEAACcQAAAAEOy56r3heZSxKtBYAvIF+O6N8znQ8UFSZgaIdWnzM0FUXBxo0Gzmh76RdCge2u/2uQ=='
    WHERE [Id] = N'a18be9c0-aa65-4af8-bd17-00bd9344e575';
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200512192250_Change-Column-Roles-in-Jobs')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200512192250_Change-Column-Roles-in-Jobs', N'3.1.3');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [Answers] DROP CONSTRAINT [FK_Answers_Questions_QuestionId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [ApplicantResponses] DROP CONSTRAINT [FK_ApplicantResponses_Applications_ApplicationId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [ApplicantResponses] DROP CONSTRAINT [FK_ApplicantResponses_Questions_QuestionId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [Applications] DROP CONSTRAINT [FK_Applications_Jobs_JobID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [JobStages] DROP CONSTRAINT [FK_JobStages_Jobs_JobId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [JobStages] DROP CONSTRAINT [FK_JobStages_Stages_StageId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [Questions] DROP CONSTRAINT [FK_Questions_Stages_StageId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [ScoreBoards] DROP CONSTRAINT [FK_ScoreBoards_Applications_ApplicationId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [ScoreBoards] DROP CONSTRAINT [FK_ScoreBoards_Stages_StageId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DROP INDEX [IX_ScoreBoards_ApplicationId] ON [ScoreBoards];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DROP INDEX [IX_ScoreBoards_StageId] ON [ScoreBoards];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DROP INDEX [IX_Questions_StageId] ON [Questions];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [JobStages] DROP CONSTRAINT [PK_JobStages];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DROP INDEX [IX_Applications_JobID] ON [Applications];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DROP INDEX [IX_ApplicantResponses_ApplicationId] ON [ApplicantResponses];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DROP INDEX [IX_ApplicantResponses_QuestionId] ON [ApplicantResponses];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DROP INDEX [IX_Answers_QuestionId] ON [Answers];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ScoreBoards]') AND [c].[name] = N'ApplicationId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ScoreBoards] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [ScoreBoards] DROP COLUMN [ApplicationId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ScoreBoards]') AND [c].[name] = N'StageId');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [ScoreBoards] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [ScoreBoards] DROP COLUMN [StageId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Questions]') AND [c].[name] = N'StageId');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Questions] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Questions] DROP COLUMN [StageId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Applications]') AND [c].[name] = N'JobID');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Applications] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Applications] DROP COLUMN [JobID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ApplicantResponses]') AND [c].[name] = N'ApplicationId');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [ApplicantResponses] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [ApplicantResponses] DROP COLUMN [ApplicationId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ApplicantResponses]') AND [c].[name] = N'QuestionId');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [ApplicantResponses] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [ApplicantResponses] DROP COLUMN [QuestionId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Answers]') AND [c].[name] = N'QuestionId');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Answers] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [Answers] DROP COLUMN [QuestionId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [ScoreBoards] ADD [ApplicationsId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [ScoreBoards] ADD [StagesId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [Questions] ADD [StagesId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[JobStages]') AND [c].[name] = N'StageId');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [JobStages] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [JobStages] ALTER COLUMN [StageId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[JobStages]') AND [c].[name] = N'JobId');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [JobStages] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [JobStages] ALTER COLUMN [JobId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [JobStages] ADD [JobsId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [JobStages] ADD [StagesId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [Applications] ADD [JobsID] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [ApplicantResponses] ADD [ApplicationsId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [ApplicantResponses] ADD [QuestionsId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [Answers] ADD [QuestionsId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [JobStages] ADD CONSTRAINT [PK_JobStages] PRIMARY KEY ([JobsId], [StagesId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    UPDATE [AspNetUsers] SET [ConcurrencyStamp] = N'd4f93785-c4cb-428a-9367-d673c8db840a', [PasswordHash] = N'AQAAAAEAACcQAAAAEH2LGGQhgwP5JM4jvUwUOm24qmGGRjQOkFDCBKDw+Vzsb/svHa+LX+tVFMiNKbrJsA=='
    WHERE [Id] = N'a18be9c0-aa65-4af8-bd17-00bd9344e575';
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    CREATE INDEX [IX_ScoreBoards_ApplicationsId] ON [ScoreBoards] ([ApplicationsId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    CREATE INDEX [IX_ScoreBoards_StagesId] ON [ScoreBoards] ([StagesId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    CREATE INDEX [IX_Questions_StagesId] ON [Questions] ([StagesId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    CREATE INDEX [IX_JobStages_JobId] ON [JobStages] ([JobId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    CREATE INDEX [IX_Applications_JobsID] ON [Applications] ([JobsID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    CREATE INDEX [IX_ApplicantResponses_ApplicationsId] ON [ApplicantResponses] ([ApplicationsId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    CREATE INDEX [IX_ApplicantResponses_QuestionsId] ON [ApplicantResponses] ([QuestionsId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    CREATE INDEX [IX_Answers_QuestionsId] ON [Answers] ([QuestionsId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [Answers] ADD CONSTRAINT [FK_Answers_Questions_QuestionsId] FOREIGN KEY ([QuestionsId]) REFERENCES [Questions] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [ApplicantResponses] ADD CONSTRAINT [FK_ApplicantResponses_Applications_ApplicationsId] FOREIGN KEY ([ApplicationsId]) REFERENCES [Applications] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [ApplicantResponses] ADD CONSTRAINT [FK_ApplicantResponses_Questions_QuestionsId] FOREIGN KEY ([QuestionsId]) REFERENCES [Questions] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [Applications] ADD CONSTRAINT [FK_Applications_Jobs_JobsID] FOREIGN KEY ([JobsID]) REFERENCES [Jobs] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [JobStages] ADD CONSTRAINT [FK_JobStages_Jobs_JobId] FOREIGN KEY ([JobId]) REFERENCES [Jobs] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [JobStages] ADD CONSTRAINT [FK_JobStages_Stages_StageId] FOREIGN KEY ([StageId]) REFERENCES [Stages] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [Questions] ADD CONSTRAINT [FK_Questions_Stages_StagesId] FOREIGN KEY ([StagesId]) REFERENCES [Stages] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [ScoreBoards] ADD CONSTRAINT [FK_ScoreBoards_Applications_ApplicationsId] FOREIGN KEY ([ApplicationsId]) REFERENCES [Applications] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    ALTER TABLE [ScoreBoards] ADD CONSTRAINT [FK_ScoreBoards_Stages_StagesId] FOREIGN KEY ([StagesId]) REFERENCES [Stages] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200513134900_Modify-Models')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200513134900_Modify-Models', N'3.1.3');
END;

GO

