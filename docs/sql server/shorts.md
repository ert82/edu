
## SET ANSI_NULLS ON

Keep it ON, it will be disabled in the future.

```SQL
create table #tempTable (sn int, ename varchar(50))

insert into #tempTable
values (1, 'Manoj'), (2, 'Pankaj'), (3, NULL), (4, 'Lokesh'), (5, 'Gopal')

SET ANSI_NULLS ON

select * from #tempTable where ename is NULL -- (1 row(s) affected)
select * from #tempTable where ename = NULL -- (0 row(s) affected)
select * from #tempTable where ename is not NULL -- (4 row(s) affected)
select * from #tempTable where ename <> NULL -- (0 row(s) affected)

SET ANSI_NULLS OFF

select * from #tempTable where ename is NULL -- (1 row(s) affected)
select * from #tempTable where ename = NULL -- (1 row(s) affected)
select * from #tempTable where ename is not NULL -- (4 row(s) affected)
select * from #tempTable where ename <> NULL -- (4 row(s) affected)
```




SET QUOTED_IDENTIFIER ON
SET NOCOUNT ON
```

## Configuration advanced options (here, disable clr strict security)

```SQL
EXEC sp_configure 'show advanced options', 1;
RECONFIGURE;

EXEC sp_configure 'clr strict security', 0;
RECONFIGURE;
```