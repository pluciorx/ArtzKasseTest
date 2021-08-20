USE [DrugsDB]
GO
/****** Object:  Table [dbo].[Drugs]    Script Date: 20/08/2021 15:56:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drugs](
	[DrugID] [int] IDENTITY(1,1) NOT NULL,
	[Tenantid] [int] NOT NULL,
	[Code] [varchar](30) NOT NULL,
	[Label] [varchar](100) NOT NULL,
	[Description] [varchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Drugs] PRIMARY KEY CLUSTERED 
(
	[DrugID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Drugs] ADD  CONSTRAINT [DF_Drugs_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Drugs]  WITH CHECK ADD  CONSTRAINT [CK_Drugs] CHECK  (([Price]>=(0)))
GO
ALTER TABLE [dbo].[Drugs] CHECK CONSTRAINT [CK_Drugs]
GO
/****** Object:  StoredProcedure [dbo].[spGetDrugList]    Script Date: 20/08/2021 15:56:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetDrugList] 
	@code varchar(30) = null,
	@label varchar(100) = null
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
    FROM dbo.Drugs
    WHERE (Code like '%'+@code+'%' or @code is null)
    AND ([Label] like '%'+@label+'%' or @label is null)


END
GO
