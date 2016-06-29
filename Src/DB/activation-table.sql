CREATE TABLE [dbo].[Activation] (
    [IDActivation] [int] NOT NULL,
    [Code] [varchar](100) NOT NULL,
	[DateRequest] [DateTime] NOT NULL,
    [IDUser] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Activation] PRIMARY KEY ([IDActivation])
)
CREATE INDEX [IX_IDActivation] ON [dbo].[Activation]([IDActivation])
CREATE INDEX IX_Code ON Activation (Code)
ALTER TABLE [dbo].[Activation] ADD CONSTRAINT [FK_dbo.Activation_dbo.User_IDActivation] FOREIGN KEY ([IDActivation]) REFERENCES [dbo].[User] ([IDUser])
