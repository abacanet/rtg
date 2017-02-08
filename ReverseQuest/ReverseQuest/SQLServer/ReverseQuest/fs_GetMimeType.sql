-- =============================================
-- Author:		Jon Culp
-- Create date: November 9, 2016
-- Description:	Returns the mime type for a provided file extension to be used for SSRS image rendering.
-- =============================================
CREATE FUNCTION [ssrs].[fs_GetMimeType](
	@ac_FileType	Char(10)
)
RETURNS Char(20) AS
BEGIN
	DECLARE
	@lc_MimeType Char(20)

	SET @lc_MimeType = 
		(
		SELECT TOP 1 rmt.mime_type
		FROM ssrs.ref_mime_type rmt
		WHERE rmt.fileType = @ac_FileType
		)

	RETURN @lc_MimeType
END