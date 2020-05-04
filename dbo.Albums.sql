CREATE TABLE [dbo].[Albums] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX)  NULL,
    [Releasedate] NVARCHAR (MAX)  NULL,
    [Price]       DECIMAL (18, 2) NOT NULL,
    [MachineId]   INT             NOT NULL,
    CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Albums_Machines_MachineId] FOREIGN KEY ([MachineId]) REFERENCES [dbo].[Machines] ([MachineId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Albums_MachineId]
    ON [dbo].[Albums]([MachineId] ASC);

