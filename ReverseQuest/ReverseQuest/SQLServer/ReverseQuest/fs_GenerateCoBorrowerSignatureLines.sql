-- =============================================
-- Author:		Jon Culp
-- Create date: November 7, 2016
-- Description:	Generate co-borrower signature lines based on number provided.
-- =============================================
CREATE FUNCTION [dbo].[fs_GenerateCoBorrowerSignatureLines]
(
	@ai_NumberOfSignatureLines	Int
)
RETURNS VarChar(500) AS
BEGIN
	DECLARE
	@lvc_Text	VarChar(500)= 'Co-Borrower Signature: _____________________________________ Date: _____________________'
	,@lvc_Return Varchar(500)

	
	IF @ai_NumberOfSignatureLines > 0
	BEGIN
		SET @lvc_Return = @lvc_Text

		WHILE @ai_NumberOfSignatureLines > 1
		BEGIN
			SET @lvc_Return = @lvc_Return + Char(13)+Char(10) + ' ' + Char(13)+Char(10) + @lvc_Text
			SET @ai_NumberOfSignatureLines = @ai_NumberOfSignatureLines-1
		END

	END

	RETURN	IsNull( @lvc_Return, '' )
END


