CREATE TABLE ApplicationLog(
id	int	IDENTITY(1,1) primary key,
date_added datetime not null default(getutcdate()),
comment ntext not null,
application_name nvarchar(100));