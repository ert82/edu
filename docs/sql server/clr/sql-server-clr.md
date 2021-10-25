SQLCLR allows you to create Stored Procedures, Functions, Aggregates, Types, and Triggers to do things that either cannot be done, or cannot be done as efficiently, in T-SQL.

The first category is functionality that simply cannot be done either in T-SQL User-Defined Functions or in T-SQL Stored Procedures. The second category is functionality that, at least to a degree, could be done in T-SQL UDFs, but only via OPENQUERY / OPENROWSET, or in two cases, also through a view. The third category is performance.



xp_cmdshell - Spawns a Windows command shell and passes in a string for execution. Any output is returned as rows of text.

```
EXEC xp_cmdshell 'dir *.exe'; 
```
