create procedure DeleteAppLog
@appname nvarchar(100)
AS
set nocount on

delete from ApplicationLog where application_name = @appname

GO
